namespace kerp.Prosedur.Pm.PMChecklistTemplate
{
    public class PMChecklistTemplateSelect
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int OrderNo { get; set; }
        public int ResponseType { get; set; }
        public bool IsRequired { get; set; }  // BIT → bool
        public string? ExpectedValue { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public string? OutOfRangeAction { get; set; }
        public bool Status { get; set; }  // BIT → bool
    }
}
