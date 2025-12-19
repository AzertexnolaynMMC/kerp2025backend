namespace kerp.Prosedur.Admin.Language
{
    public class LanguageInsert
    {
        public string Title { get; set; } = null!;
        public int Status { get; set; }   // əgər SQL-də BIT edəcəksənsə, burada bool da yaza bilərsən
        public int UserId { get; set; }
    }
}
