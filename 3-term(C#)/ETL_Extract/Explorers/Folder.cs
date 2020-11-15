using ETL_Extract.Explorers.Interfaces;
using System;
using System.IO;

namespace ETL_Extract.Explorers
{
    public class Folder : Explorer
    {
        public override void Create(string path)
        {
            Directory.CreateDirectory(GenerateUniqueName(path));
        }

        public override bool IsExists(string path)
        {
            try
            {
                DirectoryInfo folder = new DirectoryInfo(path);
                return folder.Exists;
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
