using StateManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeFile.State.Models
{
    class FileListItem
    {
        public bool IsSelected { get; set; }
        public System.IO.FileInfo Info { get; set; }
       /* public FileListItem Clone()
        {
            return new FileListItem()
            {
                IsSelected = IsSelected,
                Name = Name,
                Type = Type,
                ModifiedDate = ModifiedDate,
                Size = Size
            };
        }*/
    }
}
