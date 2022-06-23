namespace DirectoryScanner.CL
{
    public interface IRepository
    {
        void SaveChanges();
        void GetFile(string folderName,string fileName);
        void GetFolder(string folderName);
        void Add(DAL.Models.DB.Folder folder);
        void Update(DAL.Models.DB.Folder folder);
    }
}