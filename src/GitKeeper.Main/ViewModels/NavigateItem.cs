using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Events;
using Prism.Unity;
using Prism.Commands;
using Unity;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using MahApps.Metro.Controls.Dialogs;

namespace GitKeeper.Main.ViewModels
{
  public class NavigateItem
  {
    public ReactiveProperty<string> Icon { get; } = new ReactiveProperty<string>();
    public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>();
    public ReactiveProperty<string> Dtil { get; } = new ReactiveProperty<string>();
    public ReactiveProperty<string> ID { get; } = new ReactiveProperty<string>();
    public ReactiveCommand<string> NavigateCommand { set; get; }
  }
}
