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
using Prism.Services.Dialogs;
using MahApps.Metro.Controls.Dialogs;

namespace GitKeeper.ViewModels
{
  public class StartPanelViewModel : ViewModelBase, INavigationAware
  {
    public bool IsNavigationTarget(NavigationContext context)
    {

      return false;
    }

    public void OnNavigatedFrom(NavigationContext context) { }
    public void OnNavigatedTo(NavigationContext context) { }
  }
}

