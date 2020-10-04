using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    static class DirectoriesWorker
    {
        public static void UpdateDirectoriesListByPath(ListBox directories, string path, bool isFilesHidden)
        {
            string[] directoriesFromPath = Directory.GetDirectories(path)
                                                    .Select((directory) => new DirectoryInfo(directory))
                                                    .Select((directory) => directory.Name)
                                                    .ToArray();
            directories.Items.Clear();
            directories.Items.Add("...");
            foreach (var directory in directoriesFromPath)
            {
                directories.Items.Add(directory);
            }

            if (!isFilesHidden)
            {
                string[] files = Directory.GetFiles(path)
                                          .Select((file) => new FileInfo(file).Name)
                                          .ToArray(); 

                foreach (var file in files)
                {
                    directories.Items.Add(file);
                }
            }
        }

        public static string BackDirectory(string path) {

            if (Regex.Matches(path, "/").Count == 0)
            {
                return path;
            }
            else
            {
                return path.Substring(0, path.LastIndexOf('/'));
            }
        }
    }
}
