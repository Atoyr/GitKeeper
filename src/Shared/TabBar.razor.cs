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
using GitKeeper.Utilities;

namespace GitKeeper.Shared
{
  public partial class TabBar: LayoutComponentBase
  {
      [Inject]
      public ThemesService themesService { get; set; }

      public List<RepositoryInfo> TabItems { get; set; }

      public string TabBarClass
      {
        get
        {
          return ClassBuilder.Default("tab-bar")
                                  .Add(themesService?.Theme().Primary)
                                  .Build();
        }
      }

      protected override void OnInitialized()
      {
          TabItems = new List<RepositoryInfo>();
      }
  }
}

