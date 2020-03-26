using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AwesomeFile.Components;
using StateManagement;

namespace AwesomeFile.State.Reducers
{
    class TabHeaderReducer : IReducer<List<TabHeader>>
    {
        public List<TabHeader> GetDefault()
        {
            return new List<TabHeader>();
        }

        public string GetId()
        {
            return "TabHeader";
        }

        public List<TabHeader> Reduce(IAction action, List<TabHeader> state)
        {
            if(action is Actions.TabHeaderAddNew)
            {
                TabHeader tabHeader = new TabHeader();
                tabHeader.ID = Guid.NewGuid().ToString("N");
                tabHeader.Title = action.GetPayload()[0].ToString();
                tabHeader.Selected = (bool)action.GetPayload()[1];
                state.Add(tabHeader);
                return state;
            }
            return state;
        }
    }
}
