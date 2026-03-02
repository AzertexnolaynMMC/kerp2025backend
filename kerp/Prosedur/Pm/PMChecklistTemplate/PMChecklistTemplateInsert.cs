namespace kerp.Prosedur.Pm.PMChecklistTemplate
{
    public class PMChecklistTemplateInsert
    {
        public int GroupId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int OrderNo { get; set; }
        public int ResponseType { get; set; }
        public int IsRequired { get; set; }
        public string? ExpectedValue { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public string? OutOfRangeAction { get; set; }
        public int UserId { get; set; }
    }
}
