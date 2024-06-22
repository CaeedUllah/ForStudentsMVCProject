using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyMvcProject.ForFiles
{
    public class FileService : IFileService
    {
        public async Task<byte[]> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public async Task<byte[]> UpdateImageAsync(IFormFile file, byte[] existingImage)
        {
            if (file == null || file.Length == 0)
                return existingImage;

            return await UploadImageAsync(file);
        }

        public Task DeleteImageAsync(byte[] image)
        {
            // If you're storing images in a database or some other persistent storage,
            // you might need to handle the deletion there. For now, this is just a placeholder.
            return Task.CompletedTask;
        }
    }
}















/*namespace MyMvcProject.ForFiles
{
    public class FileService : IFileService
    {
        private readonly string _fileStoragePath;

        public FileService(string rootPath)
        {
            _fileStoragePath = Path.Combine(rootPath, "Image/StudentImages");

            // Ensure the directory exists
            Directory.CreateDirectory(_fileStoragePath);
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty");

            var fileName = Path.GetRandomFileName();
            var filePath = Path.Combine(_fileStoragePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return relative path from root
            return Path.Combine("Image/StudentImages", fileName);
        }

        public async Task DeleteFileAsync(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
*/