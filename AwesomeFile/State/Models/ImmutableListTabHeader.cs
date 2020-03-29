using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StateManagement;

namespace AwesomeFile.State.Models
{
    class ImmutableListTabHeader : List<Components.TabHeader>, IState<ImmutableListTabHeader>
    {
        public ImmutableListTabHeader Clone()
        {
            ImmutableListTabHeader newObject = new ImmutableListTabHeader();
            newObject.AddRange(this);
            return newObject;
        }
    }
}
