namespace kerp.Prosedur.Admin.PageUser
{
    public class PageUserSelectAdmin
    {
        public string Title { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public int Id { get; set; }
        public int UnderPageId { get; set; }
        public int PageId { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
    }
}
