using ETL_Extract.Explorers;
using ETL_Extract.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETL_Extract.Lib
{
    public static class Transfer
    {
        public static void InitializeTargetFolder()
        {
            Folder folder = new Folder();
            if (!folder.IsExists(Convert.ToString(EnvSettings.Env.TARGET_DIRECTORY)))
            {
                folder.Create(Convert.ToString(EnvSettings.Env.TARGET_DIRECTORY));
            }
        }
    }
}
