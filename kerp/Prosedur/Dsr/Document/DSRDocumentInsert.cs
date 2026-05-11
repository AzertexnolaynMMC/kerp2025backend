namespace kerp.Prosedur.Dsr.Document
{
    public class DSRDocumentInsert
    {
        public IFormFile File { get; set; } = null!;
        public string? FileName { get; set; } = null!;
        public string? FilePath { get; set; } = null!;
        public string FileNameTitle { get; set; } = null!;
        public string? ContentType { get; set; } = null!;
        public long? FileSize { get; set; }

        public int UserId { get; set; }
        public int DsrId { get; set; }
    }
}
