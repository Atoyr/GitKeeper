using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Events;
using Prism.Unity;
using Unity;
using Reactive.Bindings;
using Prism.Services.Dialogs;
using MahApps.Metro.Controls.Dialogs;
using System.Reactive.Subjects;
using GitKeeper.Common.ViewModels;

namespace GitKeeper.Main.ViewModels
{
  public class RepositoryPanelViewModel : ViewModelBase, INavigationAware
  {
    public RepositoryPanelViewModel() : base()
    {
    }

    public LibGit2Sharp.Repository Repository {get; private set;}
    public ReactiveProperty<string> Branch {get; private set;} = new ReactiveProperty<string>();

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
    }
    
  }
}

