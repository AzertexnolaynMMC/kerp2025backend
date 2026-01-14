namespace kerp.Prosedur.MachineIncident.Type
{
    public class MachineIncidentCrashTypeSelect
    {
        public string? Title { get; set; }   // NVARCHAR(255)
        public string? LangCode { get; set; }   // NVARCHAR(255)
        public int Id { get; set; }      // INT
        public int CrashId { get; set; }      // INT
        public int LangId { get; set; }      // INT
        public int CrashTypeId { get; set; }      // INT
    }
}
