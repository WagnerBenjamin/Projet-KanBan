using MahApps.Metro.Controls;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KanBan
{
    /// <summary>
    /// Logique d'interaction pour MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : MetroWindow
    {
        private bool Expanded = false;
        private TextBlock _lastSelectedListBoxItem;

        // Using a DependencyProperty as the backing store for XCoordinate.  This enables animation, styling, binding, etc...
        /// <summary>
        /// http://stackoverflow.com/questions/32127272/wpf-mvvm-get-usercontrol-actual-position-via-a-dependencyproperty
        /// https://msdn.microsoft.com/fr-fr/library/ms597495(v=vs.110).aspx
        /// </summary>
        //public static readonly DependencyProperty XCoordinateProperty = DependencyProperty.RegisterAttached("XCoordinate", typeof(double), typeof(CustomProperties), new PropertyMetadata(0.0));

        public MainWindowView()
        {
            InitializeComponent();
        }

        void ExpandCollapse_Click(object sender, RoutedEventArgs e)
        {
            if (Expanded)
            {
                AnimUiElement(0, ContentControl.WidthProperty, ToolBox, null);
                //AnimUiElement(0, ContentControl.left, ToolBox, null);
            }
            else
            {
                AnimUiElement(300, ContentControl.WidthProperty, ToolBox, null);
            }
            Expanded = !Expanded;
        }
        
        private void MenuProjectName_OnMouseLeave(object sender, MouseEventArgs e)
        {
            AnimUiElement(50, ContentControl.WidthProperty, sender as UIElement, null);
        }

        private void MenuProjectName_OnMouseEnter(object sender, MouseEventArgs e)
        {
            AnimUiElement(150, ContentControl.WidthProperty, sender as UIElement, null);
        }

        private void AnimUiElement(int intToApply, DependencyProperty  dependencyProperty, UIElement uiElement, EventHandler subTaskToExec)
        {
            var anim = new DoubleAnimation(intToApply, (Duration)TimeSpan.FromSeconds(0.3));
            if (subTaskToExec != null) anim.Completed += subTaskToExec;
            //anim.Completed += (s, _) => Expanded = false;
            uiElement?.BeginAnimation(dependencyProperty, anim);
        }

        //public static void SetXCoordinate(DependencyObject obj, double value)
        //{
        //    obj.SetValue(XCoordinateProperty, value);
        //}

        private void HighLightProjectSelected_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_lastSelectedListBoxItem != null)
            {
                _lastSelectedListBoxItem.Background = Brushes.Red;
                _lastSelectedListBoxItem.Foreground = Brushes.Black;
            }
            _lastSelectedListBoxItem = ProjectListBox.ItemContainerGenerator.ContainerFromItem(e.AddedItems[0]).FindChild<TextBlock>("ProjectName");
            if (_lastSelectedListBoxItem != null)
            {
                _lastSelectedListBoxItem.Background = Brushes.DarkRed;
                _lastSelectedListBoxItem.Foreground = Brushes.White;
            }
        }
    }
}
