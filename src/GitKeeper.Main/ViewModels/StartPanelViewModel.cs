using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Events;
using Prism.Unity;
using Prism.Commands;
using Unity;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using MahApps.Metro.Controls.Dialogs;
using GitKeeper.Common.ViewModels;


namespace GitKeeper.Main.ViewModels
{
  public class StartPanelViewModel : ViewModelBase, INavigationAware
  {

    public ReactiveProperty<string> OpenRepoTitle { get; } = new ReactiveProperty<string>();
    public ReactiveProperty<string> OpenRepoDtil { get; } = new ReactiveProperty<string>();

    public ReactiveCommand<string> Navigate { get; private set; }
    private Subject<bool> NavigateSource { get; set; }

    public override void Initialize()
    {

      OpenRepoTitle.Value = "フォルダを開く";
      OpenRepoDtil.Value = "リポジトリのあるフォルダを開きます";

      NavigateSource = new Subject<bool>();
      Navigate = NavigateSource.ToReactiveCommand<string>(true);
      Navigate.Subscribe(NavigateAction);
    }


    public void NavigateAction(string title)
    {
      if(title == OpenRepoTitle.Value ) 
      {
          RegionManager.RequestNavigate("ContentRegion", "OpenRepoPanel");
      }

    }

    public bool IsNavigationTarget(NavigationContext context)
    {

      return false;
    }

    public void OnNavigatedFrom(NavigationContext context) { }
    public void OnNavigatedTo(NavigationContext context) { }
  }
}

