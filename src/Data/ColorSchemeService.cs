using System;
using System.IO;
using System.Collections.Generic;

namespace GitKeeper.Data
{
    public class ColorSchemeService
    {
        public ColorScheme Light { get; set; }
        public ColorScheme Dark { get; set; }

        public ColorSchemeService()
        {
            Light = new ColorScheme();
            Dark = new ColorScheme();

            Light.Base.Background = "bg-white";
            Light.Base.Foreground = "fg-black";
            Light.Primary.Background = "bg-blue-accent-2";
            Light.Primary.Foreground = "fg-white";
            Light.Secondary.Background = "bg-blue-lighten-4";
            Light.Secondary.Foreground = "fg-black";
            Light.Accent.Background = "bg-deep-purple-darken-3";
            Light.Accent.Foreground = "fg-white";
            Light.Error.Background = "bg-red-darken-2";
            Light.Error.Foreground = "fg-white";
            Light.Success.Background = "bg-green-accent-2";
            Light.Success.Foreground = "fg-white";
            Light.Warning.Background = "bg-amber-darken-4";
            Light.Warning.Foreground = "fg-white";

            Light.Base.Background = "bg-black";
            Light.Base.Foreground = "fg-white";
            Light.Primary.Background = "bg-blue-accent-2";
            Light.Primary.Foreground = "fg-white";
            Light.Secondary.Background = "bg-blue-lighten-4";
            Light.Secondary.Foreground = "fg-black";
            Light.Accent.Background = "bg-deep-purple-darken-3";
            Light.Accent.Foreground = "fg-white";
            Light.Error.Background = "bg-red-darken-2";
            Light.Error.Foreground = "fg-white";
            Light.Success.Background = "bg-green-accent-2";
            Light.Success.Foreground = "fg-white";
            Light.Warning.Background = "bg-amber-darken-4";
            Light.Warning.Foreground = "fg-white";
        }
    }
}
