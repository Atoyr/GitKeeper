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

namespace GitKeeper.Components
{
    public partial class Spinner
    {
        [Parameter]
        public int Size { get; set; } = 66;

        [Parameter]
        public string Color { get; set; } = Colors.Red.Default;

        [Parameter]
        public string style { get; set; }

        public Spinner() { }

        protected string Class
        {
            get
            {
                return ClassBuilder.Default("spinner")
                    .Add(Colors.Stroke(Color))
                    .Build();
            }
        }

        protected string RemSize
        {
            get
            {
                return ((decimal)Size / 10).ToString("#.#") + "rem";
            }
        }
    }
}

