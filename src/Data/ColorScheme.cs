using System;
using System.IO;

namespace GitKeeper.Data
{
    public class ColorScheme
    {
        public Color Base { get; set; }
        public Color Primary { get; set; }
        public Color Secondary { get; set; }
        public Color Accent { get; set; }
        public Color Error { get; set; }
        public Color Info { get; set; }
        public Color Success { get; set; }
        public Color Warning { get; set; }

        public ColorScheme()
        {
            Base = new Color();
            Primary = new Color();
            Secondary = new Color();
            Accent = new Color();
            Error = new Color();
            Info = new Color();
            Success = new Color();
            Warning = new Color();
        }
    }

}

