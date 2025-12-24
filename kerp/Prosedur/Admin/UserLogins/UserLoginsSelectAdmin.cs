namespace kerp.Prosedur.Admin.UserLogins
{
    public class UserLoginsSelectAdmin
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? LoginTypeId { get; set; }
        public string? LoginTypeTitle { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public bool Status { get; set; }
    }
}
