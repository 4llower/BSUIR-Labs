using ETL_Extract.Explorers;
using ETL_Extract.Helpers;
using System;
using System.IO;
using System.Security.Cryptography;

namespace ETL_Extract.Lib
{
    public class TargetWatcher
    {
        private readonly FileSystemWatcher watcher;

        public TargetWatcher(FileSystemWatcher watcher)
        {
            this.watcher = watcher;
        }

        public string WatchPath { get; set; }

        public FileSystemWatcher Watcher => watcher;

        public TargetWatcher(string watchPath)
        {
            WatchPath = watchPath;

            watcher = new FileSystemWatcher()
            {
                Path = WatchPath,
                EnableRaisingEvents = true
            };
        }
        public void Run()
        {
            FileSystemWatcher watcher = new FileSystemWatcher
            {
                Path = WatchPath,
                EnableRaisingEvents = true
            };

            Transfer.InitializeTargetFolder(WatchPath);
            watcher.Created += OnCreated;
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            var folderExplorer = new FolderExplorer();
            if (folderExplorer.IsExists(e.FullPath)) return;

            using Aes tempAes = Aes.Create();

            using var createdFileReader = new StreamReader(e.FullPath);
            var sourceText = createdFileReader.ReadToEnd();

            // get encrypted text
            var encryptedText = Encryption.Encrypt(sourceText, tempAes.Key, tempAes.IV);

            Console.WriteLine(tempAes.Key);

            // create a file in target directory and write encrypted byte array there
            var fileExplorer = new FileExplorer();
            var pathToTargetFile = (string)EnvSettings.Env.TARGET_DIRECTORY + "/" + fileExplorer.GenerateExtractFileName(e.FullPath);
            var transferFile = (FileStream)fileExplorer.Create(pathToTargetFile);
            transferFile.Write(encryptedText);
            transferFile.Dispose();

            Console.WriteLine(tempAes.Key);

            // decrypt the file
            var decryptedText = Encryption.Decrypt(File.ReadAllBytes(pathToTargetFile), tempAes.Key, tempAes.IV);
            File.WriteAllText(pathToTargetFile, decryptedText);
        }
    }
}
