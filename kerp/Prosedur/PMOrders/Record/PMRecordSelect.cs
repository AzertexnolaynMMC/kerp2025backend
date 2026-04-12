namespace kerp.Prosedur.PMOrders.Record
{
    public class PMRecordSelect
    {
        public int Id { get; set; }
        public int PmOrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string UserTitle { get; set; }
        public required string Note { get; set; }
    }
}
