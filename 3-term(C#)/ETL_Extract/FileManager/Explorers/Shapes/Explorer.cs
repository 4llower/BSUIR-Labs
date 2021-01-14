using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ETL_Extract.Explorers.Interfaces
{
    public class Explorer
    {
        public virtual bool IsExists(string path) => false;
        public virtual bool IsExplorerSubject(string path) => false;
        public virtual object Create(string path) => new object();
        public virtual string GenerateUniqueName(string path)
        {
            if (!IsExists(path)) return path;

            string extension = "";
            if (path.Contains('.') && path.IndexOf('.') > path.IndexOf('/'))
            {
                extension = path.Substring(path.IndexOf('.'));
                path = path.Substring(0, path.LastIndexOf('.'));
            }

            int counter = 1;
            while (IsExists(path + counter.ToString() + extension))
            {
                counter++;
            }

            return path + counter.ToString() + extension;
        }
    }
}
