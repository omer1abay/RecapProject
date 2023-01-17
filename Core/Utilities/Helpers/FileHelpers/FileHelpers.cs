using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class FileHelpers : IFileHelper
    {
        public string AddFile(IFormFile file, string targetPath)
        {
            string fileName = GuidHelper.CreateGuid() + ".png";
            string destFile = Path.Combine(targetPath, fileName);
            if (!File.Exists(destFile))
            {

                using (FileStream stream = File.Create(destFile))
                {
                    file.OpenReadStream().CopyTo(stream);
                }
            }
            return destFile;
        }

        public string UpdateFile(IFormFile file, string targetPath, string oldPath)
        {
            string fileName = GuidHelper.CreateGuid()+".png";
            string destFile = Path.Combine(targetPath, fileName);
            if (File.Exists(oldPath))
            {
                File.Delete(oldPath);
            }

            if (!File.Exists(destFile))
            {
                using (FileStream stream = File.Create(destFile))
                {
                    file.OpenReadStream().CopyTo(stream);
                }
            }
            return destFile;
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (IOException e)
                {
                    throw e;
                }
            }
        }

    }
}
