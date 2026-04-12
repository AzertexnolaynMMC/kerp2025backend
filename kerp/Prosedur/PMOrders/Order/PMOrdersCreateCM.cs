using kerp.Prosedur.MachineIncident.CrashType;
using kerp.Prosedur.MachineIncident.Section;
using kerp.Prosedur.MachineIncident.Structure;
using kerp.Prosedur.MachineIncident.WorkOrderType;
using kerp.Prosedur.MachineIncident.WorkShift;

namespace kerp.Prosedur.PMOrders.Order
{
    public class PMOrdersCreateCM
    {
        public string? CmStatus { get; set; }   // NVARCHAR(255)
        public int? CreatedCmId { get; set; }
        public int PMChecklistExecutionId { get; set; }
        public string? Title { get; set; }   // NVARCHAR(255)
                                             // INT
        public int UserId { get; set; }      // INT
        public int AssetId { get; set; }     // INT
        public int ProjectId { get; set; }     // INT
        public DateTime? PlannedDate { get; set; }
        public int? DeadlineHours { get; set; }

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
