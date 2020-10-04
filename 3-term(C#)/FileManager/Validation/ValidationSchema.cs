using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Validation
{
    static class ValidationSchema
    {
        static public bool IsDirectory(string path)
        {
            return Directory.Exists(path);
        }
    }
}
