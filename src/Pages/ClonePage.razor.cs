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
using GitKeeper.Utilities;
using GitKeeper.Data;
using LibGit2Sharp;


namespace GitKeeper.Pages
{
    public partial class ClonePage : ComponentBase
    {
        [Inject]
        public ThemesService themesService { get; set; }

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

        protected bool IsCloning { get; set; }

        protected string Path { get; set; }

        protected string FolderName { get; set; }

        protected string Url { get; set; }

        protected override void OnInitialized()
        {

        }

    }
}

