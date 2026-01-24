namespace kerp.Prosedur.MachineIncident.WorkShift
{
    public class MachineIncidentWorkShiftSelect
    {
        public string? Title { get; set; }   // NVARCHAR(255)
        public int Id { get; set; }      // INT
        public int CrashId { get; set; }      // INT
        public int WorkShiftId { get; set; }      // INT
    }
}
