using StateManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeFile.State.Models
{
    class FileList : List<FileListItem>, IState<FileList>
    {
        public FileList() : base() { }
        public FileList(IEnumerable<FileListItem> collection) : base(collection) { }
        public FileList Clone()
        {

            return new FileList(this);
        }
    }
}
