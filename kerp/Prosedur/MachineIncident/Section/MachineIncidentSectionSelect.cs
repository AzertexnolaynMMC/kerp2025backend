namespace kerp.Prosedur.MachineIncident.Section
{
    public class MachineIncidentSectionSelect
    {
        public string? Title { get; set; }   // NVARCHAR(255)
        public string? LangCode { get; set; }   // NVARCHAR(255)
        public int Id { get; set; }
        public int LangId { get; set; }
        public int CrashId { get; set; }
        public int SectionId { get; set; }
    }
}
