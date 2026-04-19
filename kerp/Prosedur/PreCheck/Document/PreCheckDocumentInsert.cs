namespace kerp.Prosedur.PreCheck.Document
{
    public class PreCheckDocumentInsert
    {
        public IFormFile File { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public string FileNameTitle { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public long FileSize { get; set; }
        public int UserId { get; set; }
        public int PreCheckId { get; set; }
    }
}
