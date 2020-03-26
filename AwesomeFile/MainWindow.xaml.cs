using StateManagement;
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

namespace AwesomeFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Init store should happen before init all components
            Store.Instance().Init();
            Store.Instance().Add("TabHeader", new List<Components.TabHeader>());
            Store.Instance().AddReducer("TabHeader", new State.Reducers.TabHeaderReducer());

            InitializeComponent();

            mainTab.OnDragTitle += () =>
            {
                DragMove();
            };

            
        }
    }
}
