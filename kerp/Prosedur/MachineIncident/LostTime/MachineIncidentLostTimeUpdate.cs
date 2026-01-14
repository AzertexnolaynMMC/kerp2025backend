namespace kerp.Prosedur.MachineIncident.LostTime
{
    public class MachineIncidentLostTimeUpdate
    {
        public int Id { get; set; }                 // INT
        public string? Title { get; set; }           // NVARCHAR(255)
        public int UserId { get; set; }              // INT
        public long Second { get; set; }             // BIGINT
    }
}
