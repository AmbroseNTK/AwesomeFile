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
using StateManagement;

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
            btAddTab.Click += BtAddTab_Click;

            SizeChanged += TabBar_SizeChanged;
            scrollTabHeader.PreviewMouseWheel += ScrollTabHeader_PreviewMouseWheel;

            Store.Instance().Subscribe("[TAB HEADER] -> Add New", (action, pre) =>
            {
                if (!pre)
                {
                    tabHeaders = Store.Instance().Select<List<TabHeader>>("TabHeader");
                    stackHeader.Children.Add(tabHeaders[tabHeaders.Count - 1]);
                }
            });
           
        }

        private void ScrollTabHeader_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
            {
                scrollviewer.LineLeft();
            }
            else
            {
                scrollviewer.LineRight();
            }
            e.Handled = true;
        }

        private void TabBar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scrollTabHeader.Width = e.NewSize.Width - 200;
        }

        private List<TabHeader> tabHeaders;

        private void BtAddTab_Click(object sender, RoutedEventArgs e)
        {
            Store.Instance().Dispatch<List<TabHeader>>(new State.Actions.TabHeaderAddNew("File Explorer", true));
            
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
