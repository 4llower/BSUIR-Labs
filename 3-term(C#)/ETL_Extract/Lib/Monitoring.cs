using ETL_Extract.Explorers;
using ETL_Extract.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace ETL_Extract.Lib
{
    static public class Monitoring
    {
        public static void Run()
        {
            FileSystemWatcher watcher = new FileSystemWatcher
            {
                Path = EnvSettings.Env.SOURCE_DIRECTORY,
                EnableRaisingEvents = true
            };

            Transfer.InitializeTargetFolder();

            watcher.Created += OnCreated;
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }
    }
}
