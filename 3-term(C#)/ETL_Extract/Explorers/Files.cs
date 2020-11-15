using ETL_Extract.Explorers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ETL_Extract.Explorers
{
    public class Files : Explorer
    {
        public override void Create(string path)
        {
            File.Create(GenerateUniqueName(path));
        }

        public override bool IsExists(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                return file.Exists;
            } 
            catch (Exception)
            {
                return false;
            }
        }

        public override bool IsExplorerSubject(string path)
        {
            return IsExists(path);
        }
    }
}
