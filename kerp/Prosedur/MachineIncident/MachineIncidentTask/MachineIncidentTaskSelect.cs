namespace kerp.Prosedur.MachineIncident.MachineIncidentTask
{
    public class MachineIncidentTaskSelect
    {
        public int Id { get; set; }
        public string? Title { get; set; }   // NVARCHAR(255)
        public string? CrashTypeTitle { get; set; }   // NVARCHAR(255)
        public string? LangCode { get; set; }   // NVARCHAR(255)
        public int LangId { get; set; }
        public int MachineIncidentId { get; set; }
        public int CrashTypeId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
