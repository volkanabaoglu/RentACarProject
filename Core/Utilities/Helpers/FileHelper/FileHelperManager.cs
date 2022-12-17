using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager
    {
        public string Upload(List<IFormFile> file, string root)
        {
            StringBuilder sb = new StringBuilder();

            if (file.Count>0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                foreach (var item in file)
                {
                    var extension = Path.GetExtension(item.FileName);
                    string guid = Guid.NewGuid().ToString();
                    var path = guid + extension;

                    sb.Append(path +";");
                    using FileStream fileStream = File.Create(root + path); 
                    item.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            return sb.ToString();
        }
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public string Update(List<IFormFile> file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

    }
}
