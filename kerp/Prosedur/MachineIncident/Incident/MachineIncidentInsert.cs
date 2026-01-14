using kerp.Prosedur.MachineIncident.CrashType;
using kerp.Prosedur.MachineIncident.Section;
using kerp.Prosedur.MachineIncident.Structure;
using kerp.Prosedur.MachineIncident.WorkOrderType;
using kerp.Prosedur.MachineIncident.WorkShift;

namespace kerp.Prosedur.MachineIncident.Incident
{
    public class MachineIncidentInsert
    {
        public string? Title { get; set; }   // NVARCHAR(255)
        public int UserId { get; set; }      // INT
        public int AssetId { get; set; }     // INT
        public int ProjectId { get; set; }     // INT


        // =========================
        // Burda qezani kim acibsa hemin adam oz iscisini secir Event ucun lazimdir.
        // =========================
        public int AsigntUserId { get; set; }     // INT

        public MachineIncidentCrashTypeInsert? MachineIncidentCrashTypeInsert { get; set; }     // INT
        public MachineIncidentWorkOrderTypeInsert? MachineIncidentWorkOrderTypeInsert { get; set; }     // INT
        public MachineIncidentSectionInsert? MachineIncidentSectionInsert { get; set; }     // INT
        public MachineIncidentStructureInsert? MachineIncidentStructureInsert { get; set; }     // INT
        public MachineIncidentWorkShiftInsert? MachineIncidentWorkShiftInsert { get; set; }     // INT
    }
}
