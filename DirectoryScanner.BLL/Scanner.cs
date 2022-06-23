using DirectoryScanner.DAL;
using Microsoft.EntityFrameworkCore;
namespace DirectoryScanner.BLL
{
    public class Scanner
    {
        private readonly IRepository _repository;

        public Scanner() => _repository = new DirectoryScannerRepository();

        public void SaveChanges() => _repository.SaveChanges();

        public void ScanDirectory(string name)
        {
            try
            {
                foreach (var directoryPath in Directory.GetDirectories(name))
                {
                    ScanDirectory(directoryPath);
                }
                var folder = _repository.GetFolder(name) ?? new DAL.Models.DB.Folder { Name = name };
                ScannFiles(folder);
                _repository.Update(folder);
            }
            catch (UnauthorizedAccessException) { }
            catch (Exception) { throw; }
        }

        private void ScannFiles(DAL.Models.DB.Folder folder)
        {
            try
            {
                foreach (var filePath in Directory.GetFiles(folder.Name))
                {
                    var fileInfo = new FileInfo(filePath);

                    if (folder.Files.FirstOrDefault(x => x.Name == fileInfo.Name) == null)
                    {
                        folder.Files.Add(new DAL.Models.DB.File
                        {
                            Name = fileInfo.Name,
                            Size = fileInfo.Length,
                            FullDirectory = fileInfo.FullName
                        });
                    }

                }
            }
            catch (UnauthorizedAccessException) { }
            catch (Exception) { throw; }
        }

       


    }

}