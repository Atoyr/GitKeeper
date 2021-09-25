using System;
using System.Runtime.InteropServices;

namespace GitKeeper
{
    public class AppConfig
    {
        const string USERPROFILE = "USERPROFILE";
        const string HOME = "USERPROFILE";
        const string ConfigFileName = "config";
        const string ThemeFolderName = "Theme";

        public string AppName { get; private set; }
        public string Path { get; private set; }
        public string ThemeDirectory
        {
            get => System.IO.Path.Combine(Path, ThemeFolderName);
        }


        private AppConfig() { }

        public AppConfig(string appName)
        {
            AppName = appName;
            Initialize();
        }

        protected void Initialize()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Path = System.IO.Path.Combine(Environment.GetEnvironmentVariable(USERPROFILE), "." + AppName);
            }
            else
            {
                Path = System.IO.Path.Combine(Environment.GetEnvironmentVariable(HOME), "." + AppName);
            }

            if (!System.IO.Directory.Exists(Path))
            {
                System.IO.Directory.CreateDirectory(Path);
            }

            ThemeInitialize();
        }

        protected void ThemeInitialize()
        {
            if (!System.IO.Directory.Exists(ThemeDirectory))
            {
                System.IO.Directory.CreateDirectory(ThemeDirectory);
            }
        }
    }
}

