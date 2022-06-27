using DirectoryScanner.DAL;
namespace DirectoryScanner.BLL
{
    public class Scanner
    {
        private readonly IRepository _repository;
      
        public Scanner()
        {      
            _repository = new DirectoryScannerRepository();
        }
        public void UpdateDirectoryList(string root)
        {
            ScanDirectory(root);

            _repository.Remove(_repository.GetAllInRoot(root).Where(x=>!x.Exists));  
            _repository.SaveChanges();
        }

        private void ScanDirectory(string name)
        {
            try
            {
                foreach (var directoryPath in Directory.GetDirectories(name))
                {
                    ScanDirectory(directoryPath);
                }

                var folder = _repository.GetFolder(name) ?? new DAL.Models.DB.Folder
                {
                    Name = name,
                };

                folder.SetExists();

                ScannFiles(folder);

                _repository.Remove(folder.Files.Where(f => !f.Exists));
                _repository.AddOrUpdate(folder);
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
                    var file = folder.Files.FirstOrDefault(x => x.Name == fileInfo.Name);
                    if (file == null)
                    {
                        file = new DAL.Models.DB.File
                        {
                            Name = fileInfo.Name,
                            Size = fileInfo.Length,
                            FullDirectory = fileInfo.FullName,
                        };
                        folder.Files.Add(file);
                    }
                    file.SetExists();
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (Exception) { throw; }
        }
    }

}