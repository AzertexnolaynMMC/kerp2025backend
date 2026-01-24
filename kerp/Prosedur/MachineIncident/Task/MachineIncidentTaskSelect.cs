namespace kerp.Prosedur.MachineIncident.Task
{
    public class MachineIncidentTaskSelect
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public int MachineIncidentId { get; set; }
        public int? CrashTypeId { get; set; }

        public DateTime CreateDate { get; set; }

        public string? CrashTypeTitle { get; set; }
        public int? LangId { get; set; }
        public string? LangCode { get; set; }

        public int? AssetId { get; set; }
        public string? AssetTitle { get; set; }
    }
}
