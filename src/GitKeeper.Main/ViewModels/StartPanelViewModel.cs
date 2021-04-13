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
  public class StartPanelViewModel : ViewModelBase, INavigationAware
  {
    public ReactiveCollection<NavigateItem> NavigateItems { get; } = new ReactiveCollection<NavigateItem>();
    public ReactiveCommand<string> NavigateCommand { get; private set; }
    private Subject<bool> NavigateSource { get; set; }
    public string ID {get; private set;}

    public override void Initialize()
    {
      NavigateSource = new Subject<bool>();

      var cloneRepositoryItem = new NavigateItem();
      cloneRepositoryItem.Title.Value = "リポジトリンのクローン";
      cloneRepositoryItem.Dtil.Value = "オンラインリポジトリからコードを取得します。";
      cloneRepositoryItem.NavigateCommand = NavigateSource.ToReactiveCommand<string>(true);
      cloneRepositoryItem.NavigateCommand.Subscribe(x => NavigateAction("CloneRepoPanel", new NavigationParameters()));
          
      var openRepositoryItem = new NavigateItem();
      openRepositoryItem.Title.Value = "ローカルフォルダを開く";
      openRepositoryItem.Dtil.Value = "任意のフォルダ内のコードに移動します。";
      openRepositoryItem.NavigateCommand = NavigateSource.ToReactiveCommand<string>(true);
      openRepositoryItem.NavigateCommand.Subscribe(x => {
          var dialog = new System.Windows.Forms.FolderBrowserDialog();
          var result = dialog.ShowDialog();
          if (result == System.Windows.Forms.DialogResult.OK) 
          {
            var param = new NavigationParameters();
            param.Add("Path", dialog.SelectedPath);
            NavigateAction("MainPanel", param);
          }
        });

      NavigateItems.Add(cloneRepositoryItem);
      NavigateItems.Add(openRepositoryItem);
    }


    public void NavigateAction(string name , NavigationParameters param)
    {
      RegionManager.RequestNavigate("MainRegion", name, param);
    }

    public bool IsNavigationTarget(NavigationContext context)
    {
      return string.IsNullOrEmpty(ID) || ID == (context.Parameters["ID"] as string );
    }

    public void OnNavigatedFrom(NavigationContext context) { }
    public void OnNavigatedTo(NavigationContext context) 
    { 
      if (string.IsNullOrEmpty(ID))
      {
        ID = context.Parameters["ID"] as string;
      }
    }
  }
}

