using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagement
{
    public interface IState<T>
    {
        T Clone();
    }
}
