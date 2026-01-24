namespace kerp.Prosedur.MachineIncident.Document
{
    public class MachineIncidentDocumentInsert
    {
        public IFormFile File { get; set; } = null!;
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileNameTitle { get; set; }
        public string? ContentType { get; set; }
        public long? FileSize { get; set; }
        public int UserId { get; set; }
        public int MachineIncidentId { get; set; }
    }
}
