using ETL_Extract.Explorers;
using ETL_Extract.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETL_Extract.Lib
{
    public static class Transfer
    {
        public static void InitializeTargetFolder(string path)
        {
            FolderExplorer folder = new FolderExplorer();
            if (!folder.IsExists(path))
            {
                folder.Create(path);
            }
        }
    }
}
