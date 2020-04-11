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
    /// Interaction logic for FluentListView.xaml
    /// </summary>
    public partial class FluentListView : UserControl
    {
        public static DependencyProperty HeadersProperty =
            DependencyProperty.Register("Headers",
                typeof(List<FluentListViewHeader>),
                typeof(FluentListView),
                new FrameworkPropertyMetadata(new List<FluentListViewHeader>(),FrameworkPropertyMetadataOptions.AffectsRender,new PropertyChangedCallback((sender,e)=> {
                   FluentListView headers = sender as FluentListView;
                    if (headers !=null)
                    {
                        headers.HeadersChange(e.NewValue as List<FluentListViewHeader>);
                        
                    }
                })));

        private List<FluentListViewHeader> headers = new List<FluentListViewHeader>();
        public List<FluentListViewHeader> Headers
        {
            get => (List<FluentListViewHeader>)GetValue(HeadersProperty);
            set
            {
                headers = value;
                SetValue(HeadersProperty, value);
               
            }
        }

        protected virtual void HeadersChange(List<FluentListViewHeader> headerList)
        {
            this.headers = headerList;
            stackHeader.Children.Clear();
            headers.ForEach((header) => stackHeader.Children.Add(header));
        }

        public FluentListView()
        {
            InitializeComponent();
           
        }

    }
}
