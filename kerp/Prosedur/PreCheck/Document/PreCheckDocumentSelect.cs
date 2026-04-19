namespace kerp.Prosedur.PreCheck.Document
{
    public class PreCheckDocumentSelect
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileNameTitle { get; set; }
        public string? ContentType { get; set; }
        public long? FileSize { get; set; }
        public int? PreCheckId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UserTitle { get; set; }
    }
}
