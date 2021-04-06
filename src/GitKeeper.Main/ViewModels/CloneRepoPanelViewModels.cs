using System;
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
  public class CloneRepoPanelViewModel : ViewModelBase
  {
    public ReactiveProperty<string> RepoUrl { get; } = new ReactiveProperty<string>();
    public ReactiveProperty<string> FolderPath { get; } = new ReactiveProperty<string>();

    public ReactiveCommand NavigateNext { get; private set; }
    private Subject<bool> NavigateNextSource { get; set; }

    public CloneRepoPanelViewModel() : base()
    {

      NavigateNextSource = new Subject<bool>();
      NavigateNext = NavigateNextSource.ToReactiveCommand(true);
      NavigateNext.Subscribe(NavigateAction);
    }

    public override void InitializeRegion(IRegionManager regionManager)
    {
    }

    public override void InitializeEvent(IEventAggregator eventAggregator)
    {
    }
    
    public void NavigateAction()
    {
        RegionManager.RequestNavigate("ContentRegion", "MainPanel");
    }
  }
}
