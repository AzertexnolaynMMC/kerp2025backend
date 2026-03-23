namespace kerp.Prosedur.PMOrders
{
    public class PMEventSelect
    {
        public int Id { get; set; }

        public int PmOrderId { get; set; }

        public string? UserTitle { get; set; }

        public int EventType { get; set; }

        public DateTime EventDate { get; set; }
    }
}
