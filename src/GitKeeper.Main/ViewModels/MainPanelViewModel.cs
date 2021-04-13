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
  public class MainPanelViewModel : ViewModelBase, INavigationAware
  {
    public ReactiveProperty<string> SelectedItemId { get; } = new ReactiveProperty<string>();
    public ReadOnlyReactiveCollection<NavigateItem> NavigateItems { get; private set;}
    public ReactiveCommand<NavigateItem> AddCommand { get; private set; }
    public ReactiveCommand DeleteCommand { get; private set; }

    public MainPanelViewModel() : base()
    {
        this.SelectedItemId = new ReactiveProperty<string>();

        this.AddCommand = new ReactiveCommand<NavigateItem>();
        this.DeleteCommand = this.SelectedItemId.Select(v => v != null).ToReactiveCommand();

        this.NavigateItems = Observable.Merge(
            this.AddCommand
                .Select(x => CollectionChanged<NavigateItem>.Add(this.NavigateItems.Count, x)),
            this.DeleteCommand
                .Select(_ => NavigateItems.FirstOrDefault(x => x.ID.Value == this.SelectedItemId.Value))
                .Select(v => CollectionChanged<NavigateItem>.Remove(this.NavigateItems.IndexOf(v),v)))
            .ToReadOnlyReactiveCollection<NavigateItem>();
    }

    public void AddNavigateItem(NavigateItem item)
    {
      this.AddCommand.Execute(item);
    }

    public override void InitializeRegion(IRegionManager regionManager)
    {
    }

    public override void InitializeEvent(IEventAggregator eventAggregator)
    {
    }

    public bool IsNavigationTarget(NavigationContext context)
    {
      return false;
    }

    public void OnNavigatedFrom(NavigationContext context) 
    {
    }
    public void OnNavigatedTo(NavigationContext context) 
    { 
      if(NavigateItems.Count == 0)
      {
        var item = new NavigateItem();
        item.Title.Value = "New";
        item.ID.Value = Guid.NewGuid().ToString();
        item.NavigateCommand = new ReactiveCommand<string>();
        var param = new NavigationParameters();
        param.Add("ID", item.ID.Value);
        item.NavigateCommand.Subscribe(x => RegionManager.RequestNavigate("MainRegion", "StartPanel", param));
        AddNavigateItem(item);
        RegionManager.RequestNavigate("MainRegion", "StartPanel", param);
      }
    }
  }
}
