using FileManager.Types;
using FileManager.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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
                directories.Items.Add("/" + directory);
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

        public static void MoveFromPathToPath(string sourceDirName, string destDirName)
        {
            if (ValidationSchema.IsDirectory(sourceDirName))
            {
                Directory.Move(sourceDirName, destDirName);
            }
            else
            {
                File.Move(sourceDirName, destDirName);
            }
        }

        public static void Delete(string sourceDirName)
        {

            if (ValidationSchema.IsDirectory(sourceDirName))
            {
                Directory.Delete(sourceDirName);
            }
            else
            {
                File.Delete(sourceDirName);
            }
        }

        public static void Zip(string sourceDirName, string compressTo)
        {

            if (ValidationSchema.IsDirectory(sourceDirName))
            {
                throw new Exception(Exceptions.ArchiveError);
            }
            else
            {
                using (FileStream sourceStream = new FileStream(sourceDirName, FileMode.OpenOrCreate))
                {
                    using (FileStream targetStream = File.Create(compressTo))
                    {
                        using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                        {
                            sourceStream.CopyTo(compressionStream);
                            MessageBox.Show(String.Format("Файл был заархивирован в {0}", compressTo));
                        }
                    }
                }
            }
        }

        public static void UnZip(string compressedFile, string decompressTo)
        {

            if (!ValidationSchema.IsZipArchive(compressedFile))
            {
                throw new Exception(Exceptions.UnarchiveError);
            }
            else
            {
                using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
                {
                    using (FileStream targetStream = File.Create(decompressTo))
                    {
                        using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(targetStream);
                            MessageBox.Show(String.Format("Файл был разархивирован в {0}", decompressTo));
                        }
                    }
                }
            }
        }

        public static void Copy(string sourceDirName, string destDirName)
        {
            if (ValidationSchema.IsDirectory(sourceDirName))
            {
                throw new Exception(Exceptions.CannotCopyFolderError);
            }
            else
            {
                File.Copy(sourceDirName, destDirName);
            }
        }
    }
}
