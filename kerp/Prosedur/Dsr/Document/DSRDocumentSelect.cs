namespace kerp.Prosedur.Dsr.Document
{
    public class DSRDocumentSelect
    {
        public int Id { get; set; }
        public int DsrId { get; set; }
        public int UserId { get; set; }

        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileNameTitle { get; set; }
        public string? ContentType { get; set; }

        public long? FileSize { get; set; }

        public DateTime CreateDate { get; set; }

        public string? UserTitle { get; set; }
    }
}
