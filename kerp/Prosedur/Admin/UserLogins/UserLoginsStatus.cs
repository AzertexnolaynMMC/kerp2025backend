namespace kerp.Prosedur.Admin.UserLogins
{
    public class UserLoginsStatus
    {
        public int Id { get; set; }
        public int Status { get; set; }   // prosedur int qəbul edir (0/1)
        public int UserId { get; set; }   // prosedurda parametr kimi va
    }
}
