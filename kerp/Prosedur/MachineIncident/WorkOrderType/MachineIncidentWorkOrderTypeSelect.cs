namespace kerp.Prosedur.MachineIncident.WorkOrderType
{
    public class MachineIncidentWorkOrderTypeSelect
    {
        public int Id { get; set; }
        public int CrashId { get; set; }
        public int WorkOrderTypeId { get; set; }
        public string? Title { get; set; }
        public string? LangCode { get; set; }
        public string? Keys { get; set; } // ✅ YENİ
        public int LangId { get; set; }
    }
}
