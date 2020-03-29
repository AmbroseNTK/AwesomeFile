using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AwesomeFile.Components;
using AwesomeFile.State.Models;
using StateManagement;

namespace AwesomeFile.State.Reducers
{
    class TabHeaderReducer : IReducer<ImmutableListTabHeader>
    {
        public ImmutableListTabHeader GetDefault()
        {
            return new ImmutableListTabHeader();
        }

        public string GetId()
        {
            return "TabHeader";
        }

        public ImmutableListTabHeader Reduce(IAction action, ImmutableListTabHeader state)
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
    class TabHeaderControlReducer : IReducer<TabHeaderControlData>
    {
        public TabHeaderControlData GetDefault()
        {
            return new TabHeaderControlData() { SelectedTabID = "", DeleteTabID = "" };
        }

        public string GetId()
        {
            return "TabHeaderControlData";
        }

        public TabHeaderControlData Reduce(IAction action, TabHeaderControlData state)
        {
            if(action is Actions.TabHeaderSelect)
            {
                return new TabHeaderControlData() { SelectedTabID = action.GetPayload()[0].ToString(), DeleteTabID = state.DeleteTabID };
            }
            if(action is Actions.TabHeaderClose)
            {
                return new TabHeaderControlData() { SelectedTabID = state.SelectedTabID, DeleteTabID = action.GetPayload()[0].ToString() };
            }
            return state;
        }
    }
}
