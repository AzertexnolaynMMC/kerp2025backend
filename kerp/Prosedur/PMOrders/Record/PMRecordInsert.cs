namespace kerp.Prosedur.PMOrders.Record
{
    public class PMRecordInsert
    {
        public int PmOrderId { get; set; }
        public int UserId { get; set; }
        public required string Note { get; set; }
    }
}
