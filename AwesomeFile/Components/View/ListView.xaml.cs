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

namespace AwesomeFile.Components.View
{
    /// <summary>
    /// Interaction logic for ListView.xaml
    /// </summary>
    public partial class ListView : UserControl
    {
        State.Models.FileList fileList;
        public ListView()
        {
            
            InitializeComponent();
            fileList = new State.Models.FileList();
            try
            {
                Store.Instance().Subscribe("[FILE LIST] -> Fetch", (action, pre) =>
                {
                    if (pre)
                    {
                        fileList.Clear();
                    }
                    else
                    {
                        fileList = Store.Instance().Select<State.Models.FileList>("FileList");
                       
                    }
                });
            }
            catch { }

            mainListView.Headers = new List<Controls.FluentListViewHeader>()
            {
                new Controls.FluentListViewHeader(){HeaderName="",Width=50},
                new Controls.FluentListViewHeader(){HeaderName="Name",Width=300},
                new Controls.FluentListViewHeader(){HeaderName= "Modified", Width=200},
                new Controls.FluentListViewHeader(){HeaderName="Type",Width=200}
            };
        }
    }
}
