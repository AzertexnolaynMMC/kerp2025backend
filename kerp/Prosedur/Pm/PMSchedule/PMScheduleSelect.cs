// PMScheduleSelect.cs
using kerp.Prosedur.Pm.PMScheduleAssignees;
using kerp.Prosedur.Pm.PMScheduleStructure;
using kerp.Prosedur.Pm.PMScheduleWorkOrderType;
using System.ComponentModel.DataAnnotations.Schema;

namespace kerp.Prosedur.Pm.PMSchedule
{
    public class PMScheduleSelect
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string? AssetTitle { get; set; }
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public int FrequencyDays { get; set; }
        public DateTime? LastDone { get; set; }
        public DateOnly? NextDueDate { get; set; }
        public string? RecommendedCondition { get; set; }
        public bool Status { get; set; }
        public int CreatedUserId { get; set; }
        public string? UserTitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Title { get; set; } = string.Empty;
        [NotMapped]
        public List<PMScheduleStructureSelect>? PMScheduleStructureSelect { get; set; }
        [NotMapped]
        public List<PMScheduleWorkOrderTypeSelect>? PMScheduleWorkOrderTypeSelect { get; set; }
        [NotMapped]
        public List<PMScheduleAssigneesSelect>? PMScheduleAssigneesSelect { get; set; }
    }
}