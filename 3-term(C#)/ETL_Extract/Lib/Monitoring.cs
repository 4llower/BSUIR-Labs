using ETL_Extract.Explorers;
using ETL_Extract.Helpers;
using System;
using System.IO;
using System.Security.Cryptography;

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
            var folderExplorer = new Folder();
            if (folderExplorer.IsExists(e.FullPath)) return;

            using Aes tempAes = Aes.Create();
            var createdFileReader = new StreamReader(e.FullPath);
            var sourceText = createdFileReader.ReadToEnd();
            createdFileReader.Dispose();

            var encryptedText = Encryption.Encrypt(sourceText, tempAes.Key, tempAes.IV);
            var createdFileWriter = new StreamWriter(e.FullPath);
            createdFileWriter.Write(System.Text.Encoding.UTF8.GetString(encryptedText));
            createdFileWriter.Dispose();
        }
    }
}
