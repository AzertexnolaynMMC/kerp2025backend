namespace kerp.Prosedur.MachineIncident.WorkOrderType
{
    public class MachineIncidentWorkOrderTypeUpdate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkOrderTypeId { get; set; }
        public DateTime? PlannedDate { get; set; }  // ✅ YENİ
        public int? DeadlineHours { get; set; }     // ✅ YENİ
    }
}
