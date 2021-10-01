using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using GitKeeper;
using GitKeeper.Data;
using GitKeeper.Utilities;
using GitKeeper.Utilities.Electron;

namespace GitKeeper.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { set; get; }

        [Inject]
        public WindowManagerService windowManagerService { set; get; }

        [Inject]
        public RepositoryService Repositories { set; get; }

        [Inject]
        public IJSRuntime JSRuntime { set; get; }

        [Inject]
        public ThemesService themesService { get; set; }

        [Inject]
        public AppConfig appConfig { get; set; }

        private bool isDark = false;

        public string BaseClass
        {
            get
            {
                return ClassBuilder.Default("flex-auto")
                    .Add("flex-container-center")
                    .Add(themesService?.Theme().Default)
                    .Build();
            }
        }

        public string TitleClass => new ClassBuilder(string.Empty)
            .Add(themesService?.Theme().Primary)
            .Build();

        public string CardButtonClass => new ClassBuilder("card")
            .Add(themesService?.Theme().Surface)
            .Build();

        public void ChangeTheme()
        {
            themesService.ChangeTheme(isDark ? "dark": "light");
            isDark = !isDark;
        }

        async void ShowOpenDialog()
        {
            if (JSRuntime == null ) return;
            var result = await JSRuntime.ShowOpenDialog(new OpenDialogOption {
                    Title = "フォルダを開く",
                    ButtonLabel = "開く",
                    // DefaultPath = appConfig.ApplicationPath,
                    Properties = new string[] { "openDirectory" },
                    });
            if (!result.Canceled) {
                windowManagerService.IsLoading = true;
                try
                {
                  var repositoryInfo = Repositories.AddRepository(result.FilePaths.FirstOrDefault());
                  NavigationManager.NavigateTo($"repository/{repositoryInfo.ID}");
                }
                catch
                {
                  StateHasChanged();
                  return;
                }
                finally
                {
                    windowManagerService.IsLoading = false;
                }
            }
        }

        async void Loading()
        {
            windowManagerService.IsLoading = !windowManagerService.IsLoading;
            StateHasChanged();
        }
    }
}
