using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagement
{
    public class Store
    {
        private Store() {}

        private static Store instance;
        private Dictionary<string,object> store;
        private List<object> reducers;
        public static Store Instance()
        {
            if (instance == null)
            {
                instance = new Store();
            }
            return instance;
        }
        public void Init()
        {
            this.store = new Dictionary<string, object>();
            this.reducers = new List<object>();
        }
        public void Add<T>(string id, T state)
        {
            this.store.Add(id, new Tuple<object, Type>(state,state.GetType()));
        }

        public T Select<T>(string id)
        {
            T data = (T)Convert.ChangeType(store[id],typeof(T));
            return data;
        }

        public void AddReducer<T>(string id, IReducer<T> reducer)
        {
            this.store[id] = reducer.GetDefault();
            this.reducers.Add(reducer);
        }

        public void Dispatch<T>(IAction action)
        {
            foreach(IReducer<T> reducer in reducers)
            {
                this.store[reducer.GetId()] = reducer.Reduce(action,Select<T>(reducer.GetId()));
            }
        }

    }
}
