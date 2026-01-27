namespace kerp.Prosedur.MachineIncident.MachineIncidentTask
{
    public class MachineIncidentTaskTitleCrashTypeUpdate
    {
        public string Title { get; set; }   // NVARCHAR(255)
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CrashTypeId { get; set; }
    }
}
