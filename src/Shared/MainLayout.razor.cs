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

namespace GitKeeper.Shared
{
  public partial class MainLayout : LayoutComponentBase
  {
      [Inject]
      public ThemesService themesService { get; set; }

      protected override void OnInitialized()
      {
      }
  }
}

