namespace kerp.Prosedur.PMOrders
{
    public class PMRecordInsert
    {
        public int PmOrderId { get; set; }
        public int UserId { get; set; }
        public required string Note { get; set; }
    }
}
