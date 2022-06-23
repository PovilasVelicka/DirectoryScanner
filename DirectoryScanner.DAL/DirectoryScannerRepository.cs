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

        public void Update(Models.DB.Folder folder)
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

    }
}
