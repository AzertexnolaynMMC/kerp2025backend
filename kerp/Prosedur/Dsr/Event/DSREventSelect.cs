namespace kerp.Prosedur.Dsr.Event
{
    public class DSREventSelect
    {
        public int Id { get; set; }
        public int DsrId { get; set; }
        public required string UserTitle { get; set; }
        public int WhoId { get; set; }
        public DateTime EventDate { get; set; }
        public int TypeEnum { get; set; }
    }
}
