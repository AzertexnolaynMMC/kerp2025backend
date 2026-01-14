namespace kerp.Prosedur.MachineIncident.MachineIncidentLostTime
{
    public class MachineIncidentLostTimeSelect
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int MachineIncidentId { get; set; }
        public required string UserTitle { get; set; }
        public long Seconds { get; set; }
        public required string TimeSpent { get; set; }
    }
}
