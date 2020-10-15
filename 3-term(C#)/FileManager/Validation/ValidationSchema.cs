using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileManager.Validation
{
    static class ValidationSchema
    {
        static public bool IsDirectory(string path)
        {
            return Directory.Exists(path);
        }

        static public bool IsZipArchive(string path)
        {
            var regex = new Regex("[a-z0-9]+[.]gzip");
            return regex.IsMatch(path);
        }

        static public bool IsTextFile(string path)
        {
            var regex = new Regex("[a-z0-9]+[.](txt|bin|cs)");
            return regex.IsMatch(path);
        }
    }
}
