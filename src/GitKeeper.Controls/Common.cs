using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace GitKeeper.Controls
{
  public static class common{


//     public static void OnBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) 
//     {
// 
//     }
//     public static object BrushCallback(DependencyObject d, object value)
//     {
//       switch(value)
//       {
//         case Brush b:
//           return (object)b;
//         case string s:
//           SolidColorBrush brush;
//           brush = GetBrush(typeof(Colors), s);
//           if (brush != null) return brush;
//           brush = GetBrush(typeof(SystemColors), s);
//           if (brush != null) return brush;
// 
//           brush = new SolidColorBrush(Colors.Transparent);
//           if ( s.Length == 0)
//           {
//             return (object)brush;
//           }
// 
//           try
//           {
// 
//             if ( s[0] == '#')
//             {
//               Color c = new Color();
//               switch(s.Length)
//               {
//               case 4:
//                 // RGB
//                 c.R = Convert.ToByte(s.Substring(1,1) + s.Substring(1,1), 16);
//                 c.G = Convert.ToByte(s.Substring(2,1) + s.Substring(2,1), 16);
//                 c.B = Convert.ToByte(s.Substring(3,1) + s.Substring(3,1), 16);
//                 break;
//               case 5:
//                 // ARGB
//                 c.A = Convert.ToByte(s.Substring(1,1) + s.Substring(1,1), 16);
//                 c.R = Convert.ToByte(s.Substring(2,1) + s.Substring(2,1), 16);
//                 c.G = Convert.ToByte(s.Substring(3,1) + s.Substring(3,1), 16);
//                 c.B = Convert.ToByte(s.Substring(4,1) + s.Substring(4,1), 16);
//                 break;
//               case 7:
//                 // RRGGBB
//                 c.R = Convert.ToByte(s.Substring(1,2), 16);
//                 c.G = Convert.ToByte(s.Substring(3,2), 16);
//                 c.B = Convert.ToByte(s.Substring(5,2), 16);
//                 break;
// 
//               case 9:
//                 // AARRGGBB
//                 c.A = Convert.ToByte(s.Substring(1,2), 16);
//                 c.R = Convert.ToByte(s.Substring(3,2), 16);
//                 c.G = Convert.ToByte(s.Substring(5,2), 16);
//                 c.B = Convert.ToByte(s.Substring(7,2), 16);
//                 break;
//               }
// 
//               brush.Color = c;
//             }
//           }
//           catch 
//           {
//             return (object)new SolidColorBrush(Colors.Transparent);
//           }
// 
//           return (object)brush;
// 
//         default:
//             return (object)new SolidColorBrush(Colors.Transparent);
//       }
//     }
// 
//     private static SolidColorBrush GetBrush(Type t, string key)
//     {
//       if (t.GetProperties(BindingFlags.Static|BindingFlags.Public).Any(x => x.Name.ToUpper() == key.ToUpper()))
//       {
//         Color c = (Color)t.GetProperties(BindingFlags.Static|BindingFlags.Public).First(x => x.Name.ToUpper() == key.ToUpper()).GetValue(t, null);
//         return new SolidColorBrush(c);
//       }
//       return null;
//     }
  }
}
