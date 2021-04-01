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

namespace GitKeeper.ViewModels
{
  public class MainPanelViewModel : ViewModelBase
  {
    public ReactiveCommand Nav { get; private set; }
    private Subject<bool> NavSource { get; set; }

    public MainPanelViewModel() : base()
    {
    }

    public override void InitializeRegion(IRegionManager regionManager)
    {
      //regionManager.RequestNavigate("ContentRegion",new Uri("StartPanel"));
      regionManager.RequestNavigate("ContentRegion","StartPanel");
      this.RegionManager = regionManager;
    }

    public override void InitializeEvent(IEventAggregator eventAggregator)
    {
      NavSource = new Subject<bool>();
      Nav = NavSource.ToReactiveCommand(true);
      Nav.Subscribe(() => RegionManager.RequestNavigate("ContentRegion","StartPanel"));
    }
    
  }
}
