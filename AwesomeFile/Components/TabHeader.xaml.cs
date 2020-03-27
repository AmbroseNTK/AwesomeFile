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
using SourceChord.FluentWPF;
using StateManagement;

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
                    headerBorder.BorderBrush = new SolidColorBrush(Colors.White);
                }
                else
                {
                    headerBorder.Background = defaultBrush;
                    headerBorder.BorderBrush = defaultBrush;
                }
            }
        }

        public static readonly DependencyProperty SelectedProperty = DependencyProperty.Register("IsSelected",typeof(bool),typeof(TabHeader),new PropertyMetadata(false));

        Brush defaultBrush = null;

        public TabHeader()
        {
            InitializeComponent();

            defaultBrush = headerBorder.Background;

            Store.Instance().Subscribe("[TAB HEADER] -> Select Tab", (action, pre) =>
            {
                if (!pre)
                {
                    this.Selected = (action.GetPayload()[0].ToString() == ID);
                }
            });

            MouseDown += TabHeader_MouseDown;
            storyClose.Completed += (s, e) =>
            {
                Store.Instance().Dispatch<State.Models.TabHeaderControlData>(new State.Actions.TabHeaderClose(ID));
            };
        }

        private void TabHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Store.Instance().Dispatch<State.Models.TabHeaderControlData>(new State.Actions.TabHeaderSelect(ID));
        }
    }
}
