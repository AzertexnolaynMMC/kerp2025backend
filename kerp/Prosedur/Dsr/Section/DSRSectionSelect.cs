namespace kerp.Prosedur.Dsr.Section
{
    public class DSRSectionSelect
    {
        public int Id { get; set; }
        public int DsrId { get; set; }
        public int SectionId { get; set; }
        public required string Title { get; set; }
        public required string LangCode { get; set; }
        public int LangId { get; set; }
    }
}
