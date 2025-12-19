namespace kerp.Prosedur.Admin.Pages
{
    public class PageInsert
    {
        public string Title { get; set; } = null!;
        public string Route { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string LangRoute { get; set; } = null!;
        public int UnderPageId { get; set; }
        public int Status { get; set; }   // əgər SQL-də BIT edəcəksənsə, burada bool da yaza bilərsən
        public int UserId { get; set; }
    }
}
