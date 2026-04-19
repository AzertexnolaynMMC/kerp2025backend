namespace kerp.Service.FileUploadService
{
    public interface IFileUploadService
    {
        Task<(string fileName, string filePath, string contentType, long fileSize)>
    UploadAsync(IFormFile file, string rootFolder, int entityId, int userId);
    }
}
