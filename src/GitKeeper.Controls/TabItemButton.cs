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
  /// <summary>
  /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
  ///
  /// Step 1a) Using this custom control in a XAML file that exists in the current project.
  /// Add this XmlNamespace attribute to the root element of the markup file where it is 
  /// to be used:
  ///
  ///     xmlns:MyNamespace="clr-namespace:GitKeeper.Controls"
  ///
  ///
  /// Step 1b) Using this custom control in a XAML file that exists in a different project.
  /// Add this XmlNamespace attribute to the root element of the markup file where it is 
  /// to be used:
  ///
  ///     xmlns:MyNamespace="clr-namespace:GitKeeper.Controls;assembly=GitKeeper.Controls"
  ///
  /// You will also need to add a project reference from the project where the XAML file lives
  /// to this project and Rebuild to avoid compilation errors:
  ///
  ///     Right click on the target project in the Solution Explorer and
  ///     "Add Reference"->"Projects"->[Select this project]
  ///
  ///
  /// Step 2)
  /// Go ahead and use your control in the XAML file.
  ///
  ///     <MyNamespace:TabItemButton/>
  ///
  /// </summary>
  public partial class TabItemButton : Button
  {
    static TabItemButton()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(TabItemButton), new FrameworkPropertyMetadata(typeof(TabItemButton)));
    }

    public static readonly DependencyProperty TitleProperty =
      DependencyProperty.Register( 
          "Title", 
          typeof(string), 
          typeof(TabItemButton),
          new FrameworkPropertyMetadata( string.Empty));

    public string Title
    {
      get { return (string)GetValue(TitleProperty); }
      set { SetValue(TitleProperty, value); }
    }


    public static readonly DependencyProperty DtilProperty =
      DependencyProperty.Register( 
          "Dtil", 
          typeof(string), 
          typeof(TabItemButton),
          new FrameworkPropertyMetadata( string.Empty));

    public string Dtil
    {
      get { return (string)GetValue(DtilProperty); }
      set { SetValue(DtilProperty, value); }
    }
  }
}


