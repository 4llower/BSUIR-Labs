using System;
using System.Collections.Generic;
using System.Text;

namespace ETL_Extract.Explorers.Interfaces
{
    public class Explorer
    {
        public virtual bool IsExists(string path) { return false; }

        public virtual bool IsExplorerSubject(string path) { return false; }
        public virtual void Create(string path) { }
        public virtual string GenerateUniqueName(string path)
        {
            if (!IsExists(path)) return path;

            int counter = 1;
            while (IsExists(counter.ToString() + path))
            {
                counter++;
            }

            return counter.ToString() + path;
        }
    }
}
