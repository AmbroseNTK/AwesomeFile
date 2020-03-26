using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagement
{
    public interface IReducer<T>
    {
        string GetId();
        T GetDefault();
        T Reduce(IAction action, T state);
    }
}
