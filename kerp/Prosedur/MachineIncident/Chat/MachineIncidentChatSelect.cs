namespace kerp.Prosedur.MachineIncident.Chat
{
    public class MachineIncidentChatSelect
    {
        public string? UserTitle { get; set; }   // NVARCHAR(255)
        public string? Title { get; set; }   // NVARCHAR(255)
        public int Id { get; set; }      // INT
        public int UserId { get; set; }      // INT
        public int MachineIncidentId { get; set; }      // INT
        public DateTime CreateDate { get; set; }      // INT
    }
}
