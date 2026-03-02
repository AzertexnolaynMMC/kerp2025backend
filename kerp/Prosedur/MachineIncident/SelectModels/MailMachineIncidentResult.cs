namespace kerp.Prosedur.MachineIncident.SelectModels
{
    public class MailMachineIncidentResult
    {
        public string UserTitle { get; set; } = string.Empty;
        public int Id { get; set; }
        public string? CrashTypeTitle { get; set; }
        public string? WorkOrderTypeTitle { get; set; }
        public string? WorkShiftTile { get; set; }
        public string? Descriptions { get; set; }
        public string? AssetTitle { get; set; }
    }
}
