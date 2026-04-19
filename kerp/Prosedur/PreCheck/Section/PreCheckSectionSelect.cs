namespace kerp.Prosedur.PreCheck.Section
{
    public class PreCheckSectionSelect
    {
        public int Id { get; set; }
        public int PreCheckId { get; set; }
        public int SectionId { get; set; }
        public required string Title { get; set; }
        public required string LangCode { get; set; }
        public int LangId { get; set; }
    }
}
