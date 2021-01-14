using ETL_Extract.Explorers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ETL_Extract.Explorers
{
    public class FileExplorer : Explorer
    {
        public override object Create(string path)
        {
            return File.Create(GenerateUniqueName(path), (int)FileMode.CreateNew);
        }

        public override bool IsExists(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                return file.Exists;
            } 
            catch (Exception)
            {
                return false;
            }
        }

        public override bool IsExplorerSubject(string path)
        {
            return IsExists(path);
        }

        public string GenerateExtractFileName(string path)
        {
            //[name]_[year]_[month]_[day].[extension]
            var date = DateTime.Now;
            var name = path.Substring(path.LastIndexOf('/') + 1, path.LastIndexOf('.') - path.LastIndexOf('/') - 1);
            var extension = path.Substring(path.LastIndexOf('.') + 1);
            return String.Format("{0}_{1}_{2}_{3}.{4}", name, date.Year, date.Month, date.Day, extension);
        }
    }
}
