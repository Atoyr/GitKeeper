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
using GitKeeper.Data;
using GitKeeper.Components;
using GitKeeper.Utilities;

namespace GitKeeper.Shared
{
  public partial class MainLayout : LayoutComponentBase
  {
      [Inject]
      public ThemesService themesService { get; set; }

      [Inject]
      public WindowManagerService windowManagerService { get; set; }

      public string ToolBarClass
      {
        get{
          return ClassBuilder.Default("tool-bar")
              .Add(themesService?.Theme().PrimaryVariant)
              .Build();
        }
      }

      protected override void OnInitialized()
      {
        windowManagerService.OnIsLoadingChanged += () => InvokeAsync(() => StateHasChanged());
      }
  }
}

