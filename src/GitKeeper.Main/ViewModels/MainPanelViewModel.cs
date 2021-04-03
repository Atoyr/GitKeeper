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
  public class MainPanelViewModel : ViewModelBase
  {
    public MainPanelViewModel() : base()
    {
    }

    public override void InitializeRegion(IRegionManager regionManager)
    {
    }

    public override void InitializeEvent(IEventAggregator eventAggregator)
    {
    }
    
  }
}
