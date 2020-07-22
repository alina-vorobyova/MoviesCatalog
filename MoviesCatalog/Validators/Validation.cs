using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MoviesCatalog.Validators
{
    public static class Validation
    {
        public static bool IsValidFileExtension(IFormFile file)
        {
            if (file != null)
            {
                string extension = Path.GetExtension(file.FileName);
                extension = extension.ToLower();
                if (extension == ".jpeg" || extension == ".jpg" || extension == ".png")
                    return true;
            }
            return false;
        }

        public static bool IsValidFileSize(IFormFile file)
        {
            var maxSize = 10;
            var maxSizeInMb = maxSize * 1024 * 1024;
            if (file != null)
            {
                if (file.Length > maxSizeInMb)
                    return false;
            }
          
            return true;
        }



    }
}
