using System;

namespace GitKeeper
{
    public class AppConfig
    {
        private string appName { get; set;  }

        // public string ApplicationPath { get; } = System.Reflection.Assembly.GetExecutingAssembly().Location;

        private AppConfig() { }

        public AppConfig(string appName)
        {
            this.appName = appName;
        }
    }
}

