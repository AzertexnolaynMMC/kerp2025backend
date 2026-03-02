namespace kerp.Prosedur.Pm.PMChecklistTemplate
{
    public class PMChecklistTemplateUpdate
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int ResponseType { get; set; }
        public bool IsRequired { get; set; }
        public string? ExpectedValue { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public string? OutOfRangeAction { get; set; }
        public int UserId { get; set; }
    }
}
