using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_18._03._2023
{
    public class Catalog
    {
        public string Parent { get; private set; }
        public string SelectDirectoryPath { get; private set; }
        public List<string> Directories = new();
        /// <summary>
        /// Модель, хранящая в себе свойства каталога
        /// </summary>
        public Catalog() => GetRootCatalog();
        //public Catalog() => Test();
        public void GetRootCatalog()
        {
            Directories = DriveInfo.GetDrives().Select(item=>item.Name).ToList();
            Parent = "root";
            SelectDirectoryPath = Parent;
            /* Directories = new List <string>();
             var dir = DriveInfo.GetDrives();
             // Directories = DriveInfo.GetDrives(); //получаем списоок дисков компьютера
             foreach (var item in dir)
             {
                 Directories.Add(item.Name);
             }*/
        }

        public void Test()
        {
            var dir= DriveInfo.GetDrives().Select(item => item.Name).ToList();
            var dirinfo = Directory.GetFileSystemEntries(dir.First()).ToList();
            Directories = dirinfo;
        }
    }
}
