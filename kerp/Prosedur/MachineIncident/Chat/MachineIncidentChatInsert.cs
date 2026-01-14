namespace kerp.Prosedur.MachineIncident.MachineIncidentChat
{
    public class MachineIncidentChatInsert
    {
        public string? Title { get; set; }   // NVARCHAR(255)
        public int UserId { get; set; }
        public int MachineIncidentId { get; set; }
    }
}
