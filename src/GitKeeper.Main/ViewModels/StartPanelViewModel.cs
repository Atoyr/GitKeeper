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

    public ReactiveProperty<string> Message { get; } = new ReactiveProperty<string>();

    public ReactiveCommand Hoge { get; private set; }
    private Subject<bool> HogeSource { get; set; }

    public override void Initialize()
    {

    Message.Value = "Foo";

      HogeSource = new Subject<bool>();
      Hoge = HogeSource.ToReactiveCommand(true);
      Hoge.Subscribe(() => Message.Value = "Boo");
    }

    public bool IsNavigationTarget(NavigationContext context)
    {

      return false;
    }

    public void OnNavigatedFrom(NavigationContext context) { }
    public void OnNavigatedTo(NavigationContext context) { }
  }
}

