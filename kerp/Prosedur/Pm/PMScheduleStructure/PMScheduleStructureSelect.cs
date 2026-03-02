namespace kerp.Prosedur.Pm.PMScheduleStructure
{
    public class PMScheduleStructureSelect
    {
        public int Id { get; set; }
        public int PMScheduleId { get; set; }
        public int StructureId { get; set; }
        public string? Title { get; set; }
        public string? LangCode { get; set; }
        public int? LangId { get; set; }
        public bool Status { get; set; }
    }
}
