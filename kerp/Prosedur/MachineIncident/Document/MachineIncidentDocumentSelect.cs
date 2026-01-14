namespace kerp.Prosedur.MachineIncident.MachineIncidentDocument
{
    public class MachineIncidentDocumentSelect
    {
        public int Id { get; set; }

        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileNameTitle { get; set; }
        public string? ContentType { get; set; }
        public long FileSize { get; set; }
        public int MachineIncidentId { get; set; }
        public DateTime CreateDate { get; set; }
        public required string UserTitle { get; set; }
    }
}
