using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SkiaSharp;

namespace MoviesCatalog.Helpers
{
    public static class FileUploadHelper
    { 
        public static async Task<string> UploadFile(IFormFile file)
        {
            if (file != null)
            {
                var filename = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                var resizedBytes = Resize(memoryStream.GetBuffer(), 500, 500);

                using var fs = new FileStream(@$"wwwroot/uploads/{filename}", FileMode.Create);
                await fs.WriteAsync(resizedBytes, 0, resizedBytes.Length);

                return @$"/uploads/{filename}";
            }
            throw new Exception("File was not uploaded!");
        }

        private static byte[] Resize(byte[] fileContents, int maxWidth, int maxHeight, SKFilterQuality quality = SKFilterQuality.Medium)
        {
            using MemoryStream ms = new MemoryStream(fileContents);
            using SKBitmap sourceBitmap = SKBitmap.Decode(ms);

            int height = Math.Min(maxHeight, sourceBitmap.Height);
            int width = Math.Min(maxWidth, sourceBitmap.Width);
            if (sourceBitmap.Height > maxHeight || sourceBitmap.Width > maxWidth)
            {
                if (sourceBitmap.Height > sourceBitmap.Width)
                    width = (int)(sourceBitmap.Width / (sourceBitmap.Height / (double)maxHeight));
                else
                    height = (int)(sourceBitmap.Height / (sourceBitmap.Width / (double)maxWidth));
            }

            using SKBitmap scaledBitmap = sourceBitmap.Resize(new SKImageInfo(width, height), quality);
            using SKImage scaledImage = SKImage.FromBitmap(scaledBitmap);
            using SKData data = scaledImage.Encode();

            return data.ToArray();
        }
    }
}
