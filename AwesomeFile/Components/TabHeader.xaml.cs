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
    /// <summary>
    /// Interaction logic for TabHeader.xaml
    /// </summary>
    public partial class TabHeader : UserControl
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public bool Selected {
            get
            {
                return (bool)GetValue(SelectedProperty);
            }
            set
            {
                SetValue(SelectedProperty, value);
                if (value)
                {
                    headerBorder.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    headerBorder.Background = new SolidColorBrush(Colors.Gray);
                }
            }
        }

        public static readonly DependencyProperty SelectedProperty = DependencyProperty.Register("IsSelected",typeof(bool),typeof(TabHeader),new PropertyMetadata(false));


        public TabHeader()
        {
            InitializeComponent();
        }
    }
}
