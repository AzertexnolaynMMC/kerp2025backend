namespace kerp.Prosedur.Dsr.Cost
{
    public class DSRWorkOrderEvaluatedAll
    {
        public int UserId { get; set; }

        public int DsrId { get; set; }

        public string? UserTitle { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Duration { get; set; }

        public string? LostDuration { get; set; }

        public string? NetDuration { get; set; }
    }
}
