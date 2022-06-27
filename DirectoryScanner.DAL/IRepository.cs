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
        void AddOrUpdate(DAL.Models.DB.Folder folder);

        IEnumerable<DAL.Models.DB.Folder> GetAllInRoot(string rootFolder);
        void Remove(IEnumerable<DAL.Models.DB.File> files);
        void Remove(IEnumerable<DAL.Models.DB.Folder> folders);
    }
}
