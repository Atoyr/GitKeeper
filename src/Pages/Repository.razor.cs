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
    public partial class Repository : ComponentBase
    {
      [Parameter]
      public string ID { get; set; }

      protected RepositoryInfo repositoryInfo { get; set; } 

        [Inject]
        public RepositoryService Repositories { set; get; }

      protected override void OnInitialized()
      {
          repositoryInfo = Repositories.GetRepository(ID);
      }
    }
}

