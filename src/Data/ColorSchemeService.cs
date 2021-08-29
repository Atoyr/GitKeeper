using System;
using System.IO;
using System.Collections.Generic;

namespace GitKeeper.Data
{
    public class ColorSchemeService
    {
        public IDictionary<string, ColorScheme> ColorSchemes { get; set; }
        public ColorScheme Light { get; set; }
        public ColorScheme Dark { get; set; }

        private bool isDark = false;
        protected bool IsDark 
        { 
          get => isDark;
          set 
          {
            isDark = value;
            ChangeColor();
          }
        }

        public static void GetCallerInfoSample(
                      string msg,
                      [CallerMemberName] string memberName = "",
                      [CallerFilePath] string filePath = "",
                      [CallerLineNumber] int lineNumber = -1
                    )
        {
        }

        public event Action OnColorChanged;

        public ColorSchemeService()
        {
            ColorSchemes = new Dictionary<string, ColorScheme>();
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

            Dark.Base.Background = "bg-black";
            Dark.Base.Foreground = "fg-white";
            Dark.Primary.Background = "bg-blue-accent-2";
            Dark.Primary.Foreground = "fg-white";
            Dark.Secondary.Background = "bg-blue-lighten-4";
            Dark.Secondary.Foreground = "fg-black";
            Dark.Accent.Background = "bg-deep-purple-darken-3";
            Dark.Accent.Foreground = "fg-white";
            Dark.Error.Background = "bg-red-darken-2";
            Dark.Error.Foreground = "fg-white";
            Dark.Success.Background = "bg-green-accent-2";
            Dark.Success.Foreground = "fg-white";
            Dark.Warning.Background = "bg-amber-darken-4";
            Dark.Warning.Foreground = "fg-white";

            ColorSchemes["light"] = Light;
            ColorSchemes["dark"] = Dark;
        }

        public void ChangeTheme( string themeName) 
        {  
          switch ( themeName.ToLower() )
          {
          case "dark":
            IsDark = true;
            break;
          case "light":
            IsDark = false;
            break;
          default:
            IsDark = false;
            break;
          }
        }

        public void ChangeColor()
        {
            OnColorChanged?.Invoke();
        }

        public ColorScheme ColorScheme()
        {
          if ( IsDark)
          {
            ColorSchemes["dark"];
          }
          else
          {
            ColorSchemes["light"];
          }
        }
    }
}
