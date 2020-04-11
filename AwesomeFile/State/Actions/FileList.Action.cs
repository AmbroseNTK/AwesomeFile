using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StateManagement;

namespace AwesomeFile.State.Actions
{
    class FileListFetch : IAction
    {
        private string path;
        public FileListFetch(string path)
        {
            this.path = path;
        }
        public string GetName()
        {
            return "[FILE LIST] -> Fetch";
        }

        public object[] GetPayload()
        {
            return new object[] { path };
        }
    }
  
}
