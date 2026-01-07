namespace kerp.Prosedur.Users.Login
{
    public class UserUpdateLoginSingle
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LoginTypeId { get; set; }
        public string? Title { get; set; }
        public string? Password { get; set; }
    }
}
