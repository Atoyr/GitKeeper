using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using GitKeeper;
using GitKeeper.Themes;

namespace GitKeeper.Data
{
    public class ThemesService
    {
        public IDictionary<string, Theme> Themes { get; set; }
        public event Action OnUpdated;
        const string DarkTheme = "dark";
        const string LightTheme = "light";
        const string ThemeFileExtend = "json";

        private AppConfig appConfig { get; set; }
        private string themeName { get; set; }


        private ThemesService() {}

        public ThemesService(AppConfig appConfig)
        {
            this.appConfig = appConfig;
            Themes = new Dictionary<string, Theme>();
            Initialize();
        }

        public void ChangeTheme( string themeName)
        {
            if (Themes.Any(x => x.Key == themeName.ToLower()))
            {
              this.themeName = themeName.ToLower();
            }
        }
        public Theme Theme()
        {
            if (Themes.Any(x => x.Key == themeName.ToLower()))
            {
                return Themes[themeName];
            }
            else if (Themes.Any(x => x.Key == LightTheme))
            {
                return Themes[LightTheme];
            }
            else if (Themes.Count() > 0 )
            {
                return Themes.First().Value;
            }
            return null;
        }

        public void Update()
        {
            OnUpdated?.Invoke();
        }

        protected void Initialize()
        {
            Themes[LightTheme] = light;
            themeName = LightTheme;
        }

        private Theme light
        {
            get
            {
                var t = new Theme();
                t.Default.SetColor(Colors.Shades.Black, Colors.Shades.White);
                t.Surface.SetColor(Colors.Shades.Black, Colors.Shades.White);
                t.Primary.SetColor(Colors.Shades.Black, Colors.DeepOrange.Darken1);
                t.PrimaryVariant.SetColor(Colors.Shades.Black, Colors.DeepOrange.Darken4);
                t.Secondary.SetColor(Colors.Shades.White, Colors.Indigo.Darken1);
                t.SecondaryVariant.SetColor(Colors.Shades.White, Colors.Indigo.Darken4);
                t.Error.SetColor(Colors.Shades.White, Colors.Red.Accent4);
                return t;
            }
        }
    }
}
