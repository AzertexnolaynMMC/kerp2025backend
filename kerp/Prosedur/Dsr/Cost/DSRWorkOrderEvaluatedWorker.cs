namespace kerp.Prosedur.Dsr.Cost
{
    public class DSRWorkOrderEvaluatedWorker
    {
        public int VirtualId { get; set; }

        public int DsrId { get; set; }

        public int UserId { get; set; }

        public string? DsrTaskTitle { get; set; }

        public string? UserTitle { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? TotalSeconds { get; set; }

        public string? Duration { get; set; }

        public long? LostTimeSeconds { get; set; }

        public string? LostTimeDuration { get; set; }

        public long? NetWorkSeconds { get; set; }

        public string? NetWorkDuration { get; set; }
    }
}
