namespace kerp.Prosedur.MachineIncident.Record
{
    public class MachineIncidentRecordSelect
    {
        public int Id { get; set; }
        public int MachineIncidentId { get; set; }
        public DateTime CreateDate { get; set; }
        public int EnumType { get; set; }
        public string? UserTitle { get; set; }
        public string? Title { get; set; }
    }
}
