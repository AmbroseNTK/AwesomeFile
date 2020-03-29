using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StateManagement;

namespace AwesomeFile.State.Models
{
    public class TabHeaderControlData:IState<TabHeaderControlData>
    {
        public string SelectedTabID { get; set; }
        public string DeleteTabID { get; set; }

        public TabHeaderControlData Clone()
        {
            return new TabHeaderControlData() { SelectedTabID = this.SelectedTabID, DeleteTabID = this.DeleteTabID };
        }
    }
}
