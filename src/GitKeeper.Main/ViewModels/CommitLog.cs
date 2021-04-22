using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
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

namespace GitKeeper.Main.ViewModels
{

  public class CommitLog
  {
    public string Graph { set; get; }
    public string SHA { set; get; }
    public string AuthorName { set; get; }
    public string AuthorEmail { set; get; }
    public DateTime CommitTime { set; get; }
    public string Message { set; get; }
    public string MessageShort { set; get; }

  }

  public class GraphPoint
  {
    public string VisualString { set; get; }
    public string Prev {set;get;}
    public string Next {set;get;}
    public bool IsCommit {set;get;}

    public bool IsEmpty() 
    {
      return string.IsNullOrEmpty(Next) && string.IsNullOrEmpty(Prev);
    }

    public void Clear()
    {
      VisualString = string.Empty;
      Prev = string.Empty;
      Next = string.Empty;
      IsCommit = false;
    }
  }
}

