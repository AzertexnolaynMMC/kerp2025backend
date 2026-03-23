// PMScheduleInsert.cs
using kerp.Prosedur.Pm.PMScheduleAssignees;
using kerp.Prosedur.Pm.PMScheduleStructure;
using kerp.Prosedur.Pm.PMScheduleWorkOrderType;

namespace kerp.Prosedur.Pm.PMSchedule
{
    public class PMScheduleInsert
    {
        public int AssetId { get; set; }
        public int GroupId { get; set; }
        public int FrequencyDays { get; set; }
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string? RecommendedCondition { get; set; }
        public DateOnly? NextDueDate { get; set; }
        public PMScheduleStructureInsert? PMScheduleStructureInsert { get; set; }
        public PMScheduleWorkOrderTypeInsert? PMScheduleWorkOrderTypeInsert { get; set; }
        public List<PMScheduleAssigneesInsert>? PMScheduleAssigneesInsert { get; set; }


    }
}