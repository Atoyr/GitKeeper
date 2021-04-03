using System;
using System.Windows;
using System.Data.Common;
using System.Data.SqlClient;
using Prism.Ioc;
using Prism.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Mvvm;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Theming;
using ControlzEx.Theming;
using Unity;
using GitKeeper.Main;
using GitKeeper.Main.Views;
using GitKeeper.Main.ViewModels;

namespace GitKeeper
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : PrismApplication
  {
    protected override Window CreateShell()
    {
      return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry) 
    {
      containerRegistry.RegisterInstance<IDialogCoordinator>(DialogCoordinator.Instance);
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
      base.ConfigureModuleCatalog(moduleCatalog);
      moduleCatalog.AddModule(typeof(Module));
      moduleCatalog.AddModule(typeof(Main.MainModule));
    }

    protected override void ConfigureViewModelLocator()
    {
        base.ConfigureViewModelLocator();
    }

    protected override IModuleCatalog CreateModuleCatalog()
    {
      return new ConfigurationModuleCatalog();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);

      // Add custom theme resource dictionaries
      // You should replace SampleApp with your application name
      // and the correct place where your custom theme lives
      var theme = ThemeManager.Current.AddLibraryTheme(
          new LibraryTheme(
            new Uri("pack://application:,,,/GitKeeper;component/Styles/Themes/Dark.Default.xaml"),
            MahAppsLibraryThemeProvider.DefaultInstance
            )
          );

      ThemeManager.Current.ChangeTheme(this, theme);

    }

    protected override void OnInitialized()
    {
      base.OnInitialized();

      Container.Resolve<IRegionManager>().RequestNavigate("ContentRegion","StartPanel" );
    }
  }
}
