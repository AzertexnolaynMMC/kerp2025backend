namespace kerp.Prosedur.PMOrders.Event
{
    public class PMOrderEventInsert
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TypeEnum { get; set; }
        public int WhoId { get; set; }
    }
}
