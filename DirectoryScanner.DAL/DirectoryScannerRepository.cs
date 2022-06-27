using DirectoryScanner.DAL.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace DirectoryScanner.DAL
{
    public class DirectoryScannerRepository : IRepository
    {
        private readonly DirectoryScannerContext _context;
        public DirectoryScannerRepository()
        {
            _context = new DirectoryScannerContext();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Models.DB.Folder? GetFolder(string folderName)
        {
            return _context.Folders.Include(x => x.Files).FirstOrDefault(x => x.Name == folderName);
        }

        public void AddOrUpdate(Models.DB.Folder folder)
        {
            if (folder.Id == Guid.Empty)
            {
                _context.Add(folder);
            }
            else
            {
                _context.Update(folder);
            }
        }

        public void Remove(IEnumerable<Models.DB.File> files)
        {
            _context.Files.RemoveRange(files);
        }

        public void Remove(IEnumerable<Models.DB.Folder> folders)
        {
            _context.Folders.RemoveRange(folders);
        }

        public IEnumerable<Folder> GetAllInRoot(string rootFolder)
        {
            return _context.Folders.Where(f => f.Name.StartsWith(rootFolder));
        }
    }
}
