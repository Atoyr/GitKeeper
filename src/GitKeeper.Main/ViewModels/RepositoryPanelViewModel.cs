using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Events;
using Prism.Unity;
using Unity;
using Reactive.Bindings;
using Prism.Services.Dialogs;
using MahApps.Metro.Controls.Dialogs;

namespace GitKeeper.Main.ViewModels
{
  public class RepositoryPanelViewModel : ViewModelBase, INavigationAware
  {
    public RepositoryPanelViewModel() : base()
    {
    }

    public LibGit2Sharp.Repository Repository {get; private set;}
    public ReactiveProperty<string> Branch {get; private set;} = new ReactiveProperty<string>();
    public Subject<CollectionChanged<CommitLog>> CommitLogsSubject { get; private set; }
    public ReadOnlyReactiveCollection<CommitLog> CommitLogs { get; private set;}
    public Subject<CollectionChanged<LibGit2Sharp.TreeEntry>> TreeEntrysSubject { get; private set; }
    public ReadOnlyReactiveCollection<LibGit2Sharp.TreeEntry> TreeEntrys { get; private set;}

    public override void Initialize()
    {
      CommitLogsSubject = new Subject<CollectionChanged<CommitLog>>();
      CommitLogs = CommitLogsSubject.ToReadOnlyReactiveCollection<CommitLog>();
      TreeEntrysSubject = new Subject<CollectionChanged<LibGit2Sharp.TreeEntry>>();
      TreeEntrys = TreeEntrysSubject.ToReadOnlyReactiveCollection<LibGit2Sharp.TreeEntry>();
    }

    public override void InitializeRegion(IRegionManager regionManager)
    {
    }

    public override void InitializeEvent(IEventAggregator eventAggregator)
    {
    }

    public bool IsNavigationTarget(NavigationContext context)
    {
      var path = context.Parameters["Path"] as string;
      if (string.IsNullOrEmpty(path)) return false;
      return path.Equals(Repository.Info.Path);
    }

    public void OnNavigatedFrom(NavigationContext context) 
    {
    }

    public void OnNavigatedTo(NavigationContext context) 
    { 
      var path = context.Parameters["Path"] as string;

      while (!Directory.Exists(Path.Combine(path,".git")))
      {
        var di = Directory.GetParent(path);
        if(di == null)
        {
          return;
        }

        path = di.FullName;
      }
      Repository = new LibGit2Sharp.Repository(path);

      Branch.Value = Repository.Head.FriendlyName;
      AddCommits(Repository, string.Empty);
    }
    
    private void AddCommits(LibGit2Sharp.Repository repo, string appendStr)
    {
      var commits = repo.Commits;
      var graph = new List<GraphPoint>();
      var filter = new LibGit2Sharp.CommitFilter { IncludeReachableFrom = repo.Refs };

      foreach(var commit in commits.QueryBy(filter))
      {
        // データきれいきれい
        for(var i = 0; i < graph.Count(); i++)
        {
          if (graph[i].Next == string.Empty)
          {
              graph[i].Clear();
          }
        }

        bool isFirst = true;
        bool isCommit = true;
        // 次データ作成
        for(var i = 0; i < graph.Count(); i++)
        {
          if (graph[i].Next == commit.Sha)
          {
            if (isCommit)
            {
              foreach(var (item, index) in commit.Parents.Select((index,item) => (index, item)))
              {
                if(index == 0)
                {
                  graph[i].Prev = commit.Sha;
                  graph[i].Next = item.Sha;
                  graph[i].IsCommit = true;
                  graph[i].VisualString = commit.Parents.Count() == 1 ? "○" : "●";
                }
                else 
                {
                  var p = graph.FirstOrDefault(x => x.IsEmpty());
                  if (p == null)
                  {
                    p = new GraphPoint();
                    graph.Add(p);
                  }
                  p.Prev = commit.Sha;
                  p.Next = item.Sha;
                  p.IsCommit = false;
                  p.VisualString = "＋";
                }
              }
              isFirst = false;
              isCommit = false;
            }
            else
            {
              graph[i].Prev = string.Empty;
              graph[i].Next = string.Empty;
              graph[i].IsCommit = false;
              graph[i].VisualString = "  ";
            }
          }
          else if (string.IsNullOrEmpty(graph[i].Next ))
          {
            graph[i].Prev = string.Empty;
            graph[i].Next = string.Empty;
            graph[i].IsCommit = false;
            graph[i].VisualString = "  ";
          }
          else 
          {
            graph[i].IsCommit = false;
            graph[i].VisualString = "｜";
          }
        }
        if(isFirst)
        {
          foreach(var (item, index) in commit.Parents.Select((index,item) => (index, item)))
          {
            var p = new GraphPoint();
            graph.Add(p);
            p.Prev = commit.Sha;
            p.Next = item.Sha;
            p.IsCommit = false;
            p.VisualString = "★";
          }
        }

        var c = new CommitLog();
        c.AuthorName = commit.Author.Name;
        c.AuthorEmail = commit.Author.Email;
        c.CommitTime = commit.Author.When.DateTime;
        c.Message = commit.Message;
        c.MessageShort = appendStr + commit.MessageShort;
        c.SHA = commit.Sha;
        foreach(var s in graph)
        {
          c.Graph = c.Graph + s.VisualString;
        }

        CommitLogsSubject.OnNext(CollectionChanged<CommitLog>.Add(CommitLogs.Count(), c));
      }
    }
  }
}

