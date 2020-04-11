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

namespace AwesomeFile.Controls
{
    /// <summary>
    /// Interaction logic for FluentListViewHeader.xaml
    /// </summary>
    public partial class FluentListViewHeader : UserControl
    {
        public static DependencyProperty HeaderNameProperty = DependencyProperty.Register("HeaderName",
            typeof(string),
            typeof(FluentListViewHeader),
            new FrameworkPropertyMetadata("Header Name", (sender,e)=> {
                FluentListViewHeader header = sender as FluentListViewHeader;
                if (header != null)
                {
                    header.HeaderNameChange(e.NewValue.ToString());
                }
            }));

        private string headerName;
        public string HeaderName
        {
            get => GetValue(HeaderNameProperty).ToString();
            set
            {
                headerName = value;
                SetValue(HeaderNameProperty, headerName);
            }
        }

        public static DependencyProperty HeaderWidthProperty = DependencyProperty.Register("HeaderWidth",
            typeof(double),
            typeof(FluentListViewHeader),
            new FrameworkPropertyMetadata(160d, (sender, e) =>
            {
                FluentListViewHeader header = sender as FluentListViewHeader;
                header.Width = (double)e.NewValue;
            }
            ));
        public double HeaderWidth
        {
            get => (double)GetValue(HeaderWidthProperty);
            set => SetValue(HeaderWidthProperty, value);
        }
       
        protected virtual void HeaderNameChange(String headerName)
        {
            textHeaderName.Text = headerName;
        }
        bool isMouseDown = false;
        public FluentListViewHeader()
        {
            InitializeComponent();

            MouseUp += (s, e) =>
            {
                Cursor = Cursors.Arrow;
                isMouseDown = false;
            };

            MouseLeave += (s, e) =>
            {
                isMouseDown = false;
            };

            resizeBar.MouseMove += (s, e) =>
            {
                Cursor = Cursors.SizeWE;
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    isMouseDown = true;
                }
            };
            MouseMove += (s, e) =>
            {
               
            };
            MouseDown += (s, e) =>
            {
                if (isMouseDown)
                {
                    this.Width += (e.GetPosition(this).X - this.Width) * 2;
                }
            };

        }
    }
}
