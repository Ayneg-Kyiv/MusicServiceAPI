using Microsoft.AspNetCore.Http;

namespace MusicService.Infrastructure.FileOperations
{
    public static class FileOperations
    {
        public static async Task<(string, string)> SaveFileAsync( IFormFile file, 
                                                    string ContentRootPath,
                                                    string WayPoint )
        {
            string fileName = new string(Path.GetFileNameWithoutExtension(file.FileName).Take(20).ToArray()).Replace(" ", "_");
            fileName += $"{DateTime.Now:yymmssfff}{Path.GetExtension(file.FileName)}";

            string filePath = Path.Combine(ContentRootPath, WayPoint, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return (fileName, filePath);
        }

        public static async Task<string> CopyFileAsync (string CurrentPath, string ContentRootPath,string WayPoint , string FileName)
        {
            string filePath = Path.Combine(ContentRootPath, WayPoint, FileName);

            if (!System.IO.File.Exists(filePath))
                File.Copy(CurrentPath, filePath);

            return filePath;
        }

        public static void DeleteFile( string filePath )
        {
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }
    }
}
