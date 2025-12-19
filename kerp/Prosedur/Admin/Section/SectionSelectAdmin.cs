namespace kerp.Prosedur.Admin.Section
{
    public class SectionSelectAdmin
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        // Status sütununun tipinə görə birini seç:
        public bool Status { get; set; }     // əgər DB-də int/tinyint-dirsə
                                             // public bool Status { get; set; } // əgər DB-də bit-dirsə

        public int? StructureId { get; set; }
        public int? UnderId { get; set; }
        public string? StructureTitle { get; set; }
    }
}
