namespace kerp.Prosedur.MachineIncident.MachineIncidentLostTime
{
    public class MachineIncidentLostTimeInsert
    {
        public string? Title { get; set; }          // NVARCHAR(255)
        public int UserId { get; set; }             // INT
        public int MachineIncidentId { get; set; }  // INT
        public long Second { get; set; }             // BIGINT
    }
}
