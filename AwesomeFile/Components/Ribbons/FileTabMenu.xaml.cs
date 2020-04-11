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

namespace AwesomeFile.Components.Ribbons
{
    /// <summary>
    /// Interaction logic for FileTabMenu.xaml
    /// </summary>
    public partial class FileTabMenu : UserControl
    {
        public FileTabMenu()
        {
            InitializeComponent();
            scrollTab.PreviewMouseWheel += ScrollTab_PreviewMouseWheel;
            SizeChanged += FileTabMenu_SizeChanged;
        }

        private void FileTabMenu_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                scrollTab.Width = Application.Current.MainWindow.Width;
            }
            catch { }
        }

        private void ScrollTab_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
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
    }
}
