namespace MyMvcProject.ForFiles
{
    public interface IFileService
    {
        Task<byte[]> UploadImageAsync(IFormFile file);
        Task<byte[]> UpdateImageAsync(IFormFile file, byte[] existingImage);
        Task DeleteImageAsync(byte[] image);
    }
}
