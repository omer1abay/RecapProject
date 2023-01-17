using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelpers
{
    public interface IFileHelper
    {
        string AddFile(IFormFile file,string sourceFile);
        void DeleteFile(string filePath);
        string UpdateFile(IFormFile file, string targetPath, string oldPath);
    }
}