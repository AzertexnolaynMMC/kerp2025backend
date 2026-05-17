namespace kerp.Prosedur.Dsr.Cost
{
    public class DSRCostInsert
    {
        public int DsrId { get; set; }

        public int CostTypeId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public string? Description { get; set; }

        public int UserId { get; set; }
    }
}
