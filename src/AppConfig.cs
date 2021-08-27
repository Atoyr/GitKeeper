using System;

namespace GitKeeper
{
    public class AppConfig
    {
        private string appName { get; set;  }



        private AppConfig() { }

        public AppConfig(string appName)
        {
            this.appName = appName;
        }
    }
}

