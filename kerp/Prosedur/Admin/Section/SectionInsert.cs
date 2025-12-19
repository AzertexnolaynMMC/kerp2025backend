namespace kerp.Prosedur.Admin.Section
{
    public class SectionInsert
    {
        public string Title { get; set; } = null!;
        public int Status { get; set; }
        public int UnderId { get; set; }
        public int StructureId { get; set; }
        public int UserId { get; set; } // prosedurda istifadə olunmur, amma parametr kimi var
    }
}
