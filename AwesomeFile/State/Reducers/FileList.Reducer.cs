using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AwesomeFile.State.Models;
using StateManagement;

namespace AwesomeFile.State.Reducers
{
    class FileListReducer : IReducer<State.Models.FileList>
    {
        public FileList GetDefault()
        {
            return new FileList();
        }

        public string GetId()
        {
            return "FileList";
        }

        public FileList Reduce(IAction action, FileList state)
        {
            if(action is Actions.FileListFetch)
            {
                string path = action.GetPayload()[0].ToString();
                FileList files = new FileList();
                string[] fileNames = Directory.GetFiles(path);
                foreach (string fileName in fileNames)
                {
                    string filePath = Path.Combine(path, fileName);
                    FileInfo info = new FileInfo(filePath);
                    
                    files.Add(new FileListItem()
                    {
                        IsSelected = false,
                        Info = info,
                    });
                }
                return files;
            }
          
            return state;
        }
    }
}
