namespace kerp.Prosedur.Dsr.Structure
{
    public class DSRStructureSelect
    {
        public int Id { get; set; }
        public int DsrId { get; set; }
        public int StructureId { get; set; }
        public required string Title { get; set; }
        public required string LangCode { get; set; }
        public int LangId { get; set; }
    }
}
