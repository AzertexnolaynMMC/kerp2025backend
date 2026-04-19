namespace kerp.Prosedur.PreCheck.Event
{
    public class PreCheckEventSelect
    {
        public int Id { get; set; }
        public int PreCheckId { get; set; }
        public required string UserTitle { get; set; }
        public int EventType { get; set; }
        public DateTime EventDate { get; set; }
        public int UserId { get; set; }
    }
}
