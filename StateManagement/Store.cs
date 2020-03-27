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
        private Dictionary<string, List<Subscriber>> subscribers;
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
            this.subscribers = new Dictionary<string, List<Subscriber>>();
        }
        public void Add<T>(string id, T state)
        {
            this.store.Add(id, state);
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
            // Before take action
            foreach(Subscriber subscriber in subscribers[action.GetName()])
            {
                subscriber.Invoke(action, true);
            }
            for(int i=0;i<reducers.Count;i++)
            {
                try
                {
                    IReducer<T> reducer = (IReducer<T>)reducers[i];
                    this.store[reducer.GetId()] = reducer.Reduce(action, Select<T>(reducer.GetId()));
                }
                catch { }
            }
            // After take action
            foreach (Subscriber subscriber in subscribers[action.GetName()])
            {
                subscriber.Invoke(action, false);
            }
        }

        public void Subscribe(string actionName, Subscriber subscriber)
        {
            if (!subscribers.ContainsKey(actionName))
            {
                subscribers.Add(actionName, new List<Subscriber>());
            }
            subscribers[actionName].Add(subscriber);
        }

    }
}
