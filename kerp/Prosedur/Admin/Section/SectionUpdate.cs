namespace kerp.Prosedur.Admin.Section
{
    public class SectionUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int UserId { get; set; } // prosedurda istifadə olunmur, amma parametr kimi var
    }
}
