namespace kerp.Prosedur.Dsr.Cost
{
    public class DSRCostSelect
    {
        public int Id { get; set; }

        public int DsrId { get; set; }

        public int CostTypeId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

        public string? Description { get; set; }

        public DateTime AddDate { get; set; }

        public string? DSRCostTypeTitle { get; set; }
        public bool? IsMaterial { get; set; }
        public int? MaterialId { get; set; }
    }
}
