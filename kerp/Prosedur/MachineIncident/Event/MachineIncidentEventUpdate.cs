namespace kerp.Prosedur.MachineIncident.Event
{
    public class MachineIncidentEventUpdate
    {
        public int Id { get; set; }
        public int MachineIncidentId { get; set; }
        public DateTime NewEventDate { get; set; }
        public int UserId { get; set; }
        public int EnumType { get; set; }
    }
}
