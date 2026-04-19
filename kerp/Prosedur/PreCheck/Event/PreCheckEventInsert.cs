namespace kerp.Prosedur.PreCheck.Event
{
    public class PreCheckEventInsert
    {
        public int PreCheckId { get; set; }
        public int UserId { get; set; }     // ChangeLog üçün
        public int EventType { get; set; }
        public int WhoId { get; set; }      // Event-i edən user
    }
}
