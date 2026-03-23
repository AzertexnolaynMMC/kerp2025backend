// PMScheduleUpdate.cs
namespace kerp.Prosedur.Pm.PMSchedule
{
    public class PMScheduleUpdate
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int GroupId { get; set; }
        public int FrequencyDays { get; set; }
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string? RecommendedCondition { get; set; }
        public DateOnly? NextDueDate { get; set; }
    }
}