namespace kerp.Prosedur.PMOrders.CheckList
{
    public class PMChecklistExecutionSelect
    {
        public int? Id { get; set; }

        public int? PmOrderId { get; set; }

        public int? TemplateId { get; set; }

        public int? FilledBy { get; set; }

        public bool? IsDone { get; set; }

        public string? ResponseValue { get; set; }

        public bool? IsInRange { get; set; }

        public string? Notes { get; set; }

        public string? PhotoPath { get; set; }

        public string? CmStatus { get; set; }

        public int? CreatedCmId { get; set; }

        public DateTime? FilledAt { get; set; }

        public string? ItemName { get; set; }

        public int? OrderNo { get; set; }

        public int? ResponseType { get; set; }

        public bool? IsRequired { get; set; }

        public string? ExpectedValue { get; set; }
        public string? UserTitle { get; set; }

        public decimal? MinValue { get; set; }

        public decimal? MaxValue { get; set; }

        public int? OutOfRangeAction { get; set; }
    }
}
