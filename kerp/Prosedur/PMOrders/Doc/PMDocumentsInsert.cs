namespace kerp.Prosedur.PMOrders.Doc
{
    public class PMDocumentsInsert
    {
        public IFormFile? File { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileNameTitle { get; set; }
        public string? ContentType { get; set; }
        public long FileSize { get; set; }
        public int UserId { get; set; }
        public int PmOrderId { get; set; }
    }
}
/*
         public IFormFile File { get; set; } = null!;
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileNameTitle { get; set; }
        public string? ContentType { get; set; }
        public long? FileSize { get; set; }
        public int UserId { get; set; }
        public int MachineIncidentId { get; set; } 
 
 * */