using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryScanner.DAL
{
    public interface IRepository
    {
        void SaveChanges();
        Models.DB.Folder? GetFolder(string folderName);
        void Update(DAL.Models.DB.Folder folder);
    }
}
