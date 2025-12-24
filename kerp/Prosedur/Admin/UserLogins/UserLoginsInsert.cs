namespace kerp.Prosedur.Admin.UserLogins
{
    public class UserLoginsInsert
    {
        public string? Title { get; set; }
        public int UserId { get; set; }

        public int LoginTypeId { get; set; }

        public int? SelectUserId { get; set; }

        public string? Password { get; set; }
    }
}
