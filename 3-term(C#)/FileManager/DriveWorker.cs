using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    static class DriveWorker
    {
        public static string[] GetAllDrives()
        {
            string[] result = DriveInfo.GetDrives().Select((drive) => drive.Name).ToArray();
            return result;
        }
    }
}
