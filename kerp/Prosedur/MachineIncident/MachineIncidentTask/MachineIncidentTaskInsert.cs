namespace kerp.Prosedur.MachineIncident.MachineIncidentTask
{
    public class MachineIncidentTaskInsert
    {
        public string? Title { get; set; }   // NVARCHAR(255)
        public int UserId { get; set; }
        public int AssetId { get; set; }
        public int MachineIncidentId { get; set; }
        public int CrashTypeId { get; set; }
    }
}
