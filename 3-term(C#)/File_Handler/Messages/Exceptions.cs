using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Types
{
    static class Exceptions
    {
        public static string CannotFindDrivesError = "На вашем компьютере нету дисков";
        public static string AccessError = "Нет прав доступа";
        public static string NotDirectoryError = "Это не папка";
        public static string NotSelectedError = "Вы не выбрали файл/папку для операции";
        public static string NotInOneDiskError = "Папки находятся в разных разделах";
        public static string CannotCopyFolderError = "Нельзя копировать папки";
        public static string UnarchiveError = "Можно разархивировать только файлы с расширением .gzip";
        public static string ArchiveError = "Можно архивировать только файлы";
        public static string IsNotTextFileError = "Этот файл не является текстовым и его нельзя редактировать";
    }
}
