namespace kerp.Prosedur.Dsr.Record
{
    public class DSRRecordSelect
    {
        public int Id { get; set; }
        public int DsrId { get; set; }

        public DateTime CreateDate { get; set; }

        public string? UserTitle { get; set; }
        public string? Title { get; set; }
    }
}
