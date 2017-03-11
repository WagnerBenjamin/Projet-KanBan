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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private bool Expanded = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        void ExpandCollapse_Click(object sender, RoutedEventArgs e)
        {
            if (Expanded)
            {
                var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.3));
                anim.Completed += (s, _) => Expanded = false;
                ToolBox.BeginAnimation(ContentControl.WidthProperty, anim);
            }
            else
            { 
                var anim = new DoubleAnimation(300, (Duration)TimeSpan.FromSeconds(0.3));
                anim.Completed += (s, _) => Expanded = true;
                ToolBox.BeginAnimation(ContentControl.WidthProperty, anim);
            }
        }
    }
}
