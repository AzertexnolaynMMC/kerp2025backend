namespace kerp.Prosedur.PreCheck.Event
{
    public class PreCheckEventsSelectMulti
    {
        public int Id { get; set; }
        public int PreCheckId { get; set; }
        public int UserId { get; set; }
        public DateTime EventDate { get; set; }
        public int EventType { get; set; }
        public required string UserFullName { get; set; }
    }
}
