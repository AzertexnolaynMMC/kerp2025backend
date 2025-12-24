namespace kerp.Prosedur.Hr.Users.Mail
{
    public class UserStatusMail
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; } // prosedurda istifadə olunmur, amma parametr kimi var
    }
}
