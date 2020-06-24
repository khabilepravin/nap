using Microsoft.AspNetCore.Http;
using models;
using System.IO;

namespace napclient.Utility
{
    internal static class FileUtility
    {
        internal static FileStorage BuildFileStorage(IFormFile formFile)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                formFile.CopyTo(ms);
                fileBytes = ms.ToArray();

            }

            return new FileStorage
            {
                Data = fileBytes,
                FileType = formFile.ContentType,
                Name = formFile.FileName
            };
        }
    }
}
