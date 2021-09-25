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
using GitKeeper.Utilities;

namespace GitKeeper.Components
{
    public enum Themes
    {
        Filled, // Default
        Outlined,
        Rounded,
        TwoTone,
        Sharp
    }

    public partial class MaterialIcon
    {
        [Parameter]
        public Themes Theme { get; set; }

        [Parameter]
        public string Kind { get; set; }

        [Parameter]
        public int Size { get; set; } = 24;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Color { get; set; } = "fg-black";

        [Parameter]
        public string BackgroundColor { get; set; } = "";

        protected string Class
        {
            get
            {
                return ClassBuilder.Default(themeString)
                    .Add(Color)
                    .Add(BackgroundColor)
                    .Build();
            }
        }

        protected string Style
        {
            get
            {
                return StyleBuilder.Empty()
                    .AddStyle("font-size", $"{Size}px")
                    .Build();
            }
        }

        private string themeString
        {
            get
            {
                switch (Theme)
                {
                    case Themes.Filled : return "material-icons";
                    case Themes.Outlined : return "material-icons-outlined";
                    case Themes.Rounded : return "material-icons-round";
                    case Themes.TwoTone : return "material-icons-two-tone";
                    case Themes.Sharp : return "material-icons-sharp";
                    default: return string.Empty;
                }
            }
        }
    }
}

