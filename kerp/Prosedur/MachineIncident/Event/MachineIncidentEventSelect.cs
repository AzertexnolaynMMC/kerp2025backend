namespace kerp.Prosedur.MachineIncident.Event
{
    public class MachineIncidentEventSelect
    {
        public string? UserTitle { get; set; }   // NVARCHAR(255)
        public int Id { get; set; }      // INT
        public int WhoId { get; set; }      // INT
        public int CrashId { get; set; }      // INT
        public int TypeEnum { get; set; }      // INT
        public DateTime EventDate { get; set; }      // INT
    }
}
