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

namespace GitKeeper.Pages
{
  public partial class Index
  {
    [Inject]
    public RepositoryService Repositories { set; get; }

    [Inject]
    public ColorSchemeService ColorSchemes { set; get; }

    public string BaseClass = ClassBuilder
                                .Default("flex-auto")
                                .Add(ColorSchemes.Light.Background, ColorSchemes.Light.Foreground)
                                .Build();
  }
}
