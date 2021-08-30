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
using GitKeeper.Data;
using GitKeeper.Utilities;
using GitKeeper.Utilities.Electron;

namespace GitKeeper.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public RepositoryService Repositories { set; get; }

        [Inject]
        public IJSRuntime JSRuntime { set; get; }

        [Inject]
        public ColorSchemeService colorSchemeService { get; set; }

        private bool isDark = false;

        public string BaseClass
        {
            get
            {
                return ClassBuilder.Default("flex-auto")
                    .Add("flex-container-center")
                    .Add(colorSchemeService?.ColorScheme().Base)
                    .Build();
            }
        }

        public string TitleClass => new ClassBuilder(string.Empty)
            .Add(colorSchemeService?.ColorScheme().Accent)
            .Build();

        public void ChangeTheme()
        {
            colorSchemeService.ChangeTheme(isDark ? "dark": "light");
            isDark = !isDark;
        }

        async void ShowOpenDialog()
        {
            if (JSRuntime == null ) return;
            var result = await JSRuntime.ShowOpenDialog(new OpenDialogOption {
                    Title = "フォルダを開く",
                    ButtonLabel = "開く",
                    DefaultPath = @"C:\",
                    Properties = new string[] { "openDirectory" },
                    });
            if (!result.Canceled) {
                Console.WriteLine(result.FilePaths.FirstOrDefault());
                StateHasChanged();
            }
        }
    }
}
