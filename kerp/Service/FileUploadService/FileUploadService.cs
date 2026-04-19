namespace kerp.Service.FileUploadService
{
    public class FileUploadService : IFileUploadService
    {
        public async Task<(string fileName, string filePath, string contentType, long fileSize)>
            UploadAsync(IFormFile file, string rootFolder, int entityId, int userId)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("File boşdur");
            }

            string extension = Path.GetExtension(file.FileName)
                                   .Replace(".", "")
                                   .ToLowerInvariant();

            string uploadRoot = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                rootFolder,
                entityId.ToString(),
                extension
            );

            _ = Directory.CreateDirectory(uploadRoot);

            string uniqueFileName =
                $"{entityId}_{userId}_{DateTime.UtcNow:yyyyMMddHHmmssfff}_{Guid.NewGuid()}.{extension}";

            string physicalPath = Path.Combine(uploadRoot, uniqueFileName);

            using FileStream stream = new(physicalPath, FileMode.Create);
            await file.CopyToAsync(stream);

            string filePath = $"/{rootFolder}/{entityId}/{extension}/{uniqueFileName}";

            return (uniqueFileName, filePath, file.ContentType, file.Length);
        }
    }
}
