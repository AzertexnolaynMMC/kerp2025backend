namespace kerp.Prosedur.PMOrders.Event
{
    public class PMEventSelectMulti
    {
        public int Id { get; set; }

        public DateTime EventDate { get; set; }

        public required string UserTitle { get; set; }

        public int EventType { get; set; }
    }
}
