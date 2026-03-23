namespace kerp.Prosedur.PMOrders
{
    public class PMMaterialSelect
    {
        public int Id { get; set; }

        public int MaterialId { get; set; }

        public double Amount { get; set; }

        public required string Measure { get; set; }

        public required string Code { get; set; }

        public required string Title { get; set; }

        public int PmOrderId { get; set; }
    }
}
