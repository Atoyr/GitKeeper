using System;
using Newtonsoft.Json;

namespace GitKeeper.Themes
{
    public class Theme
    {
        public Color Default { get; set; }
        public Color Surface { get; set; }
        public Color Primary { get; set; }
        public Color PrimaryVariant { get; set; }
        public Color Secondary { get; set; }
        public Color SecondaryVariant { get; set; }

        public Color Success { get; set; }
        public Color Info { get; set; }
        public Color Warning { get; set; }
        public Color Error { get; set; }

        public Theme()
        {
            Initialize();
        }

        protected void Initialize()
        {
            Default = new Color();
            Surface = new Color();
            Primary = new Color();
            PrimaryVariant = new Color();
            Secondary = new Color();
            SecondaryVariant = new Color();

            Success = new Color();
            Info = new Color();
            Warning = new Color();
            Error = new Color();
        }
    }
}