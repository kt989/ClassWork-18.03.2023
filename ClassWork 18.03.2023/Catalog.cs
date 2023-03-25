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
        public bool IsCatalog { get; private set; } = true;
        /// <summary>
        /// Модель, хранящая в себе свойства каталога
        /// </summary>
        public Catalog()=> GetRootCatalog();
    
        public void GetRootCatalog()
        {
            Directories = DriveInfo.GetDrives().Select(item=>item.Name).ToList(); // получаем список дисков с их свойствами и записываем только имена
            Parent = "root";
            SelectDirectoryPath = Parent;
        }

        public void UpdateCatalog(string directory)
        {
            var item = SelectDirectoryPath is not "root" && directory!=Parent
                ? SelectDirectoryPath + @"\" + directory
                : directory;
             var dir_info = new DirectoryInfo(item);
            try 
            {
                Directories = Directory.GetFileSystemEntries(item).Select(i=>Path.GetFileName(i)).ToList();
                SelectDirectoryPath = item;
                Parent = dir_info.Parent is not null
                    ? dir_info.Parent.ToString()
                    : "root";
                IsCatalog= true;
            }
            catch(Exception ex) 
            { 
                Directories.Clear();
                Directories.Add(ex.Message);
                Parent = SelectDirectoryPath;
                IsCatalog= false;
            }

        }

       /* public void GetDownCatalog() // метод для тестирования
        {
            var dir= DriveInfo.GetDrives().Select(item => item.Name).ToList();
            var dirinfo = Directory.GetFileSystemEntries(dir.First()).ToList();
            Directories = dirinfo;
            Parent = "DownCatalog";
            SelectDirectoryPath = Parent;
        }*/
    }
}
