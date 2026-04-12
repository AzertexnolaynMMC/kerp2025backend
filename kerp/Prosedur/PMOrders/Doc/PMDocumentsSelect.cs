namespace kerp.Prosedur.PMOrders.Doc
{
    public class PMDocumentsSelect
    {
        public int Id { get; set; }

        public string? FileName { get; set; }

        public string? FilePath { get; set; }

        public string? FileNameTitle { get; set; }

        public string? ContentType { get; set; }

        public long FileSize { get; set; }

        public int PmOrderId { get; set; }

        public DateTime? CreateDate { get; set; }

        public string? UserTitle { get; set; }
    }
}
