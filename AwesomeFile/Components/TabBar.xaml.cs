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

namespace AwesomeFile.Components
{
    public delegate void DragTitleHandler();
    /// <summary>
    /// Interaction logic for TabBar.xaml
    /// </summary>
    public partial class TabBar : UserControl
    {
        public event DragTitleHandler OnDragTitle;
        public TabBar()
        {
            InitializeComponent();
            tabTitle.MouseDown += (s,e)=> {
                if (e.ChangedButton == MouseButton.Left)
                    OnDragTitle?.Invoke();
            };

            btClose.Click += (s, e) =>
            {
                Application.Current.MainWindow.Close();
            };

            btMinimize.Click += (s, e) =>
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            };

            btMaximize.Click += ToggleWindowState;
            tabTitle.MouseDown += ToggleWindowState;

          
        }
        private void ToggleWindowState(Object sender, EventArgs e)
        {
            if(sender is DockPanel)
            {
                if((e as MouseButtonEventArgs).ClickCount != 2)
                {
                    return;
                }
            }
            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }
    }
}
