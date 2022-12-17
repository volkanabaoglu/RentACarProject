using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        public string Upload(List<IFormFile> file, string root);
        public void Delete(string filepath);
        public string Update(List<IFormFile> file, string filepath,string root);

    }
}
