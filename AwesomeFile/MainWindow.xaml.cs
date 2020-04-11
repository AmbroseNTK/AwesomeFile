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
            Store.Instance().Add("TabHeader", new State.Models.ImmutableListTabHeader());
            Store.Instance().Add("TabHeaderControlData", new State.Models.TabHeaderControlData());
            Store.Instance().Add("FileList", new State.Models.FileList());
            Store.Instance().AddReducer("TabHeader", new State.Reducers.TabHeaderReducer());
            Store.Instance().AddReducer("TabHeaderControlData", new State.Reducers.TabHeaderControlReducer());
            Store.Instance().AddReducer("FileList", new State.Reducers.FileListReducer());
            InitializeComponent();

            mainTab.OnDragTitle += () =>
            {
                DragMove();
            };

            Store.Instance().Dispatch<State.Models.FileList>(new State.Actions.FileListFetch("D:\\"));
          
        }
    }
}
