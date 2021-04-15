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
  public partial class TabItemButton : ContentControl
  {
    static TabItemButton()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(TabItemButton), new FrameworkPropertyMetadata(typeof(TabItemButton)));
    }

    private Border PART_Border;

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

    public static readonly DependencyProperty IconProperty =
      DependencyProperty.Register( 
          "Icon", 
          typeof(ImageSource), 
          typeof(TabItemButton),
          new FrameworkPropertyMetadata( null));

    public ImageSource Icon
    {
      get { return (ImageSource)GetValue(IconProperty); }
      set { SetValue(IconProperty, value); }
    }

    public static readonly DependencyProperty NavigateCommandProperty =
      DependencyProperty.Register( 
          "NavigateCommand", 
          typeof(ICommand), 
          typeof(TabItemButton),
          new FrameworkPropertyMetadata(null));

    public ICommand NavigateCommand
    {
      get { return (ICommand)GetValue(NavigateCommandProperty); }
      set { SetValue(NavigateCommandProperty, value); }
    }

    public static readonly DependencyProperty CloseCommandProperty =
      DependencyProperty.Register( 
          "CloseCommand", 
          typeof(ICommand), 
          typeof(TabItemButton),
          new FrameworkPropertyMetadata(null));

    public ICommand CloseCommand
    {
      get { return (ICommand)GetValue(CloseCommandProperty); }
      set { SetValue(CloseCommandProperty, value); }
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();

      this.PART_Border = this.GetTemplateChild("PART_Border") as Border;
    }

    private static void OnMouseDown(object sender, MouseButtonEventArgs e)
    {
      TabItemButton tabItemButton = sender as TabItemButton;
      switch (e.ChangedButton)
      {
        case MouseButton.Left:
          if (tabItemButton.NavigateCommand != null && tabItemButton.NavigateCommand.CanExecute(sender))
          {
            tabItemButton.NavigateCommand.Execute(sender);
          }
          break;
        case MouseButton.Middle:
          if (tabItemButton.CloseCommand != null && tabItemButton.CloseCommand.CanExecute(sender))
          {
            tabItemButton.CloseCommand.Execute(sender);
          }
          break;
        case MouseButton.Right:
          break;
        case MouseButton.XButton1:
          break;
        case MouseButton.XButton2:
          break;
        default:
          break;
      }
    }
  }
}


