using System.ComponentModel.DataAnnotations.Schema;

namespace kerp.Prosedur.MachineIncidentReport
{
    public class MachineIncidentReportSelect
    {
        // ======================
        // Virtual / Real ID
        // ======================
        public int Id { get; set; }
        public int IncidentId { get; set; }
        public int TaskId { get; set; }

        // ======================
        // Main Info
        // ======================
        public string? TaskTitle { get; set; }
        public string? MachineIncidentTitle { get; set; }
        public string? ProjectTitle { get; set; }
        public string? AssetTitle { get; set; }
        public string? UnderAssetName { get; set; }

        // ======================
        // Event Dates
        // ======================
        public DateTime? OpenDate { get; set; }
        public DateTime? AcceptDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ConfirmDate { get; set; }

        // ======================
        // Event Users
        // ======================
        public string? OpenedBy { get; set; }
        public string? AcceptedBy { get; set; }
        public string? StartedBy { get; set; }
        public string? ClosedBy { get; set; }
        public string? ConfirmedBy { get; set; }

        // ======================
        // Work Order
        // ======================
        public int? WorkOrderTypeId { get; set; }

        // ======================
        // Durations (HH:mm:ss)
        // ======================
        public string? Durations { get; set; }
        public string? LostTime { get; set; }
        public string? RealDurations { get; set; }
        public DateTime? PlannedDate { get; set; }   // ✅ YENİ
        public int? DeadlineHours { get; set; }      // ✅ YENİ
        public DateTime? DeadlineDate { get; set; }  // ✅ YENİ
        [NotMapped]
        public MachineIncidentReportWorkShiftSelect? MachineIncidentReportWorkShiftSelect { get; set; }

        // ======================
        // Task Asset Path
        // ======================
        [NotMapped]
        public List<MachineIncidentReportCrashTypeSelect>? MachineIncidentReportCrashTypeSelect { get; set; }
        [NotMapped]
        public List<MachineIncidentReportSectionSelect>? MachineIncidentReportSectionSelect { get; set; }
        [NotMapped]
        public List<MachineIncidentReportStructureSelect>? MachineIncidentReportStructureSelect { get; set; }
        [NotMapped]
        public List<MachineIncidentReportWorkOrderTypeSelect>? MachineIncidentReportWorkOrderTypeSelect { get; set; }
    }
}
