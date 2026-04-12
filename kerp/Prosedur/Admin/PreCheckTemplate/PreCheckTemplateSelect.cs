namespace kerp.Prosedur.Admin.PreCheckTemplate
{
    public class PreCheckTemplateSelect
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int PreCheckGroupId { get; set; }
        public string? GroupTitle { get; set; } // LEFT JOIN-dən gəlir
        public bool Status { get; set; }
    }
}
