using System;
using System.IO;
using GitKeeper;

namespace GitKeeper.Themes
{
    public class Color
    {
        private string foreground;
        public string Foreground
        {
            get
            {
                if (string.IsNullOrEmpty(foreground))
                {
                    return string.Empty;
                }
                return Colors.Foreground(foreground);
            }
            set
            {
                foreground = value;
            }
        }

        private string background;
        public string Background
        {
            get
            {
                if (string.IsNullOrEmpty(background))
                {
                    return string.Empty;
                }
                return Colors.Background(background);
            }
            set
            {
                background = value;
            }
        }

        private string onForeground;
        public string OnForeground
        {
            get
            {
                if (string.IsNullOrEmpty(onForeground))
                {
                    return string.Empty;
                }
                return Colors.Foreground(onForeground);
            }
            set
            {
                onForeground = value;
            }
        }

        private string onBackground;
        public string OnBackground
        {
            get
            {
                if (string.IsNullOrEmpty(onBackground))
                {
                    return string.Empty;
                }
                return Colors.HoverBackground(onBackground);
            }
            set
            {
                onBackground = value;
            }
        }

        public void SetColor(string fg, string bg)
        {
            Foreground = fg;
            Background = bg;
        }

        public void SetColor(string fg, string bg, string onFg, string onBg)
        {
            Foreground = fg;
            Background = bg;
            OnForeground = onFg;
            OnBackground = onBg;
        }
    }
}

