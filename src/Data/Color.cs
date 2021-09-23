using System;
using System.IO;

namespace GitKeeper.Data
{
    public static class Colors
    {
        public const string Red = "red";
        public const string RedLighten5 = "red-lighten-5";
        public const string RedLighten4 = "red-lighten-4";
        public const string RedLighten3 = "red-lighten-3";
        public const string RedLighten2 = "red-lighten-2";
        public const string RedLighten1 = "red-lighten-1";
        public const string RedDarken1 = "red-darken-1";
        public const string RedDarken2 = "red-darken-2";
        public const string RedDarken3 = "red-darken-3";
        public const string RedDarken4 = "red-darken-4";
        public const string RedAccent1 = "red-accent-1";
        public const string RedAccent2 = "red-accent-2";
        public const string RedAccent3 = "red-accent-3";
        public const string RedAccent4 = "red-accent-4";

        public const string Pink = "pink";
        public const string PinkLighten5 = "pink-lighten-5";
        public const string PinkLighten4 = "pink-lighten-4";
        public const string PinkLighten3 = "pink-lighten-3";
        public const string PinkLighten2 = "pink-lighten-2";
        public const string PinkLighten1 = "pink-lighten-1";
        public const string PinkDarken1 = "pink-darken-1";
        public const string PinkDarken2 = "pink-darken-2";
        public const string PinkDarken3 = "pink-darken-3";
        public const string PinkDarken4 = "pink-darken-4";
        public const string PinkAccent1 = "pink-accent-1";
        public const string PinkAccent2 = "pink-accent-2";
        public const string PinkAccent3 = "pink-accent-3";
        public const string PinkAccent4 = "pink-accent-4";

        public const string Purple = "purple";
        public const string PurpleLighten5 = "purple-lighten-5";
        public const string PurpleLighten4 = "purple-lighten-4";
        public const string PurpleLighten3 = "purple-lighten-3";
        public const string PurpleLighten2 = "purple-lighten-2";
        public const string PurpleLighten1 = "purple-lighten-1";
        public const string PurpleDarken1 = "purple-darken-1";
        public const string PurpleDarken2 = "purple-darken-2";
        public const string PurpleDarken3 = "purple-darken-3";
        public const string PurpleDarken4 = "purple-darken-4";
        public const string PurpleAccent1 = "purple-accent-1";
        public const string PurpleAccent2 = "purple-accent-2";
        public const string PurpleAccent3 = "purple-accent-3";
        public const string PurpleAccent4 = "purple-accent-4";

        public const string DeepPurple = "deep-purple";
        public const string DeepPurpleLighten5 = "deep-purple-lighten-5";
        public const string DeepPurpleLighten4 = "deep-purple-lighten-4";
        public const string DeepPurpleLighten3 = "deep-purple-lighten-3";
        public const string DeepPurpleLighten2 = "deep-purple-lighten-2";
        public const string DeepPurpleLighten1 = "deep-purple-lighten-1";
        public const string DeepPurpleDarken1 = "deep-purple-darken-1";
        public const string DeepPurpleDarken2 = "deep-purple-darken-2";
        public const string DeepPurpleDarken3 = "deep-purple-darken-3";
        public const string DeepPurpleDarken4 = "deep-purple-darken-4";
        public const string DeepPurpleAccent1 = "deep-purple-accent-1";
        public const string DeepPurpleAccent2 = "deep-purple-accent-2";
        public const string DeepPurpleAccent3 = "deep-purple-accent-3";
        public const string DeepPurpleAccent4 = "deep-purple-accent-4";

        public const string Indigo = "indigo";
        public const string IndigoLighten5 = "indigo-lighten-5";
        public const string IndigoLighten4 = "indigo-lighten-4";
        public const string IndigoLighten3 = "indigo-lighten-3";
        public const string IndigoLighten2 = "indigo-lighten-2";
        public const string IndigoLighten1 = "indigo-lighten-1";
        public const string IndigoDarken1 = "indigo-darken-1";
        public const string IndigoDarken2 = "indigo-darken-2";
        public const string IndigoDarken3 = "indigo-darken-3";
        public const string IndigoDarken4 = "indigo-darken-4";
        public const string IndigoAccent1 = "indigo-accent-1";
        public const string IndigoAccent2 = "indigo-accent-2";
        public const string IndigoAccent3 = "indigo-accent-3";
        public const string IndigoAccent4 = "indigo-accent-4";

        public const string Blue = "blue";
        public const string BlueLighten5 = "blue-lighten-5";
        public const string BlueLighten4 = "blue-lighten-4";
        public const string BlueLighten3 = "blue-lighten-3";
        public const string BlueLighten2 = "blue-lighten-2";
        public const string BlueLighten1 = "blue-lighten-1";
        public const string BlueDarken1 = "blue-darken-1";
        public const string BlueDarken2 = "blue-darken-2";
        public const string BlueDarken3 = "blue-darken-3";
        public const string BlueDarken4 = "blue-darken-4";
        public const string BlueAccent1 = "blue-accent-1";
        public const string BlueAccent2 = "blue-accent-2";
        public const string BlueAccent3 = "blue-accent-3";
        public const string BlueAccent4 = "blue-accent-4";

        public const string Green = "green";
        public const string GreenLighten5 = "green-lighten-5";
        public const string GreenLighten4 = "green-lighten-4";
        public const string GreenLighten3 = "green-lighten-3";
        public const string GreenLighten2 = "green-lighten-2";
        public const string GreenLighten1 = "green-lighten-1";
        public const string GreenDarken1 = "green-darken-1";
        public const string GreenDarken2 = "green-darken-2";
        public const string GreenDarken3 = "green-darken-3";
        public const string GreenDarken4 = "green-darken-4";
        public const string GreenAccent1 = "green-accent-1";
        public const string GreenAccent2 = "green-accent-2";
        public const string GreenAccent3 = "green-accent-3";
        public const string GreenAccent4 = "green-accent-4";

        public const string LightGreen = "light-green";
        public const string LightGreenLighten5 = "light-green-lighten-5";
        public const string LightGreenLighten4 = "light-green-lighten-4";
        public const string LightGreenLighten3 = "light-green-lighten-3";
        public const string LightGreenLighten2 = "light-green-lighten-2";
        public const string LightGreenLighten1 = "light-green-lighten-1";
        public const string LightGreenDarken1 = "light-green-darken-1";
        public const string LightGreenDarken2 = "light-green-darken-2";
        public const string LightGreenDarken3 = "light-green-darken-3";
        public const string LightGreenDarken4 = "light-green-darken-4";
        public const string LightGreenAccent1 = "light-green-accent-1";
        public const string LightGreenAccent2 = "light-green-accent-2";
        public const string LightGreenAccent3 = "light-green-accent-3";
        public const string LightGreenAccent4 = "light-green-accent-4";

        public const string Lime = "lime";
        public const string LimeLighten5 = "lime-lighten-5";
        public const string LimeLighten4 = "lime-lighten-4";
        public const string LimeLighten3 = "lime-lighten-3";
        public const string LimeLighten2 = "lime-lighten-2";
        public const string LimeLighten1 = "lime-lighten-1";
        public const string LimeDarken1 = "lime-darken-1";
        public const string LimeDarken2 = "lime-darken-2";
        public const string LimeDarken3 = "lime-darken-3";
        public const string LimeDarken4 = "lime-darken-4";
        public const string LimeAccent1 = "lime-accent-1";
        public const string LimeAccent2 = "lime-accent-2";
        public const string LimeAccent3 = "lime-accent-3";
        public const string LimeAccent4 = "lime-accent-4";

        public const string Yellow = "yellow";
        public const string YellowLighten5 = "yellow-lighten-5";
        public const string YellowLighten4 = "yellow-lighten-4";
        public const string YellowLighten3 = "yellow-lighten-3";
        public const string YellowLighten2 = "yellow-lighten-2";
        public const string YellowLighten1 = "yellow-lighten-1";
        public const string YellowDarken1 = "yellow-darken-1";
        public const string YellowDarken2 = "yellow-darken-2";
        public const string YellowDarken3 = "yellow-darken-3";
        public const string YellowDarken4 = "yellow-darken-4";
        public const string YellowAccent1 = "yellow-accent-1";
        public const string YellowAccent2 = "yellow-accent-2";
        public const string YellowAccent3 = "yellow-accent-3";
        public const string YellowAccent4 = "yellow-accent-4";

        public const string Amber = "amber";
        public const string AmberLighten5 = "amber-lighten-5";
        public const string AmberLighten4 = "amber-lighten-4";
        public const string AmberLighten3 = "amber-lighten-3";
        public const string AmberLighten2 = "amber-lighten-2";
        public const string AmberLighten1 = "amber-lighten-1";
        public const string AmberDarken1 = "amber-darken-1";
        public const string AmberDarken2 = "amber-darken-2";
        public const string AmberDarken3 = "amber-darken-3";
        public const string AmberDarken4 = "amber-darken-4";
        public const string AmberAccent1 = "amber-accent-1";
        public const string AmberAccent2 = "amber-accent-2";
        public const string AmberAccent3 = "amber-accent-3";
        public const string AmberAccent4 = "amber-accent-4";

        public const string Orange = "orange";
        public const string OrangeLighten5 = "orange-lighten-5";
        public const string OrangeLighten4 = "orange-lighten-4";
        public const string OrangeLighten3 = "orange-lighten-3";
        public const string OrangeLighten2 = "orange-lighten-2";
        public const string OrangeLighten1 = "orange-lighten-1";
        public const string OrangeDarken1 = "orange-darken-1";
        public const string OrangeDarken2 = "orange-darken-2";
        public const string OrangeDarken3 = "orange-darken-3";
        public const string OrangeDarken4 = "orange-darken-4";
        public const string OrangeAccent1 = "orange-accent-1";
        public const string OrangeAccent2 = "orange-accent-2";
        public const string OrangeAccent3 = "orange-accent-3";
        public const string OrangeAccent4 = "orange-accent-4";

        public const string DeepOrange = "deep-orange";
        public const string DeepOrangeLighten5 = "deep-orange-lighten-5";
        public const string DeepOrangeLighten4 = "deep-orange-lighten-4";
        public const string DeepOrangeLighten3 = "deep-orange-lighten-3";
        public const string DeepOrangeLighten2 = "deep-orange-lighten-2";
        public const string DeepOrangeLighten1 = "deep-orange-lighten-1";
        public const string DeepOrangeDarken1 = "deep-orange-darken-1";
        public const string DeepOrangeDarken2 = "deep-orange-darken-2";
        public const string DeepOrangeDarken3 = "deep-orange-darken-3";
        public const string DeepOrangeDarken4 = "deep-orange-darken-4";
        public const string DeepOrangeAccent1 = "deep-orange-accent-1";
        public const string DeepOrangeAccent2 = "deep-orange-accent-2";
        public const string DeepOrangeAccent3 = "deep-orange-accent-3";
        public const string DeepOrangeAccent4 = "deep-orange-accent-4";

        public const string Brown = "brown";
        public const string BrownLighten5 = "brown-lighten-5";
        public const string BrownLighten4 = "brown-lighten-4";
        public const string BrownLighten3 = "brown-lighten-3";
        public const string BrownLighten2 = "brown-lighten-2";
        public const string BrownLighten1 = "brown-lighten-1";
        public const string BrownDarken1 = "brown-darken-1";
        public const string BrownDarken2 = "brown-darken-2";
        public const string BrownDarken3 = "brown-darken-3";
        public const string BrownDarken4 = "brown-darken-4";
        public const string BrownAccent1 = "brown-accent-1";
        public const string BrownAccent2 = "brown-accent-2";
        public const string BrownAccent3 = "brown-accent-3";
        public const string BrownAccent4 = "brown-accent-4";

        public const string BlueGray = "blue-gray";
        public const string BlueGrayLighten5 = "blue-gray-lighten-5";
        public const string BlueGrayLighten4 = "blue-gray-lighten-4";
        public const string BlueGrayLighten3 = "blue-gray-lighten-3";
        public const string BlueGrayLighten2 = "blue-gray-lighten-2";
        public const string BlueGrayLighten1 = "blue-gray-lighten-1";
        public const string BlueGrayDarken1 = "blue-gray-darken-1";
        public const string BlueGrayDarken2 = "blue-gray-darken-2";
        public const string BlueGrayDarken3 = "blue-gray-darken-3";
        public const string BlueGrayDarken4 = "blue-gray-darken-4";
        public const string BlueGrayAccent1 = "blue-gray-accent-1";
        public const string BlueGrayAccent2 = "blue-gray-accent-2";
        public const string BlueGrayAccent3 = "blue-gray-accent-3";
        public const string BlueGrayAccent4 = "blue-gray-accent-4";

        public const string Gray = "gray";
        public const string GrayLighten5 = "gray-lighten-5";
        public const string GrayLighten4 = "gray-lighten-4";
        public const string GrayLighten3 = "gray-lighten-3";
        public const string GrayLighten2 = "gray-lighten-2";
        public const string GrayLighten1 = "gray-lighten-1";
        public const string GrayDarken1 = "gray-darken-1";
        public const string GrayDarken2 = "gray-darken-2";
        public const string GrayDarken3 = "gray-darken-3";
        public const string GrayDarken4 = "gray-darken-4";
        public const string GrayAccent1 = "gray-accent-1";
        public const string GrayAccent2 = "gray-accent-2";
        public const string GrayAccent3 = "gray-accent-3";
        public const string GrayAccent4 = "gray-accent-4";

        public const string Black = "black";
        public const string White = "white";
        public const string Transparent = "transparent";

        public const string Darken80 = "darken-80";
        public const string Darken60 = "darken-60";
        public const string Darken40 = "darken-40";
        public const string Darken20 = "darken-20";
        public const string Lighten80 = "lighten-80";
        public const string Lighten60 = "lighten-60";
        public const string Lighten40 = "lighten-40";
        public const string Lighten20 = "lighten-20";

        public string Foreground(string color) => "fg-" + color;
        public string Background(string color) => "bg-" + color;
        public string HoverForeground(string color) => "hover-fg-" + color;
        public string HoverBackground(string color) => "hover-bg-" + color;
    }

    public class Color
    {
        public string Foreground { get; set; }
        public string Background { get; set; }
    }
}
