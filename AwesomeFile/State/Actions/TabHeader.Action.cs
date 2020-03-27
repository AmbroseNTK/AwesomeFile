using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StateManagement;

namespace AwesomeFile.State.Actions
{
    public class TabHeaderAddNew : IAction
    {
        private string title;
        private bool isSelected;
        public TabHeaderAddNew(string title, bool isSelected)
        {
            this.title = title;
            this.isSelected = isSelected;
        }
        public string GetName()
        {
            return "[TAB HEADER] -> Add New";
        }

        public object[] GetPayload()
        {
            return new object[] { title,isSelected };
        }
    }

    public class TabHeaderSelect : IAction
    {
        private string tabId;
        public TabHeaderSelect(string tabId)
        {
            this.tabId = tabId;
        }
        public string GetName()
        {
            return "[TAB HEADER] -> Select Tab";
        }

        public object[] GetPayload()
        {
            return new object[] { tabId };
        }
    }
    public class TabHeaderClose : IAction
    { 
        private string tabId;
        public TabHeaderClose(string tabId)
        {
            this.tabId = tabId;
        }

        public string GetName()
        {
            return "[TAB HEADER] -> Close Tab"; 
        }

        public object[] GetPayload()
        {
            return new object[] { tabId };
        }
    }
        
}
