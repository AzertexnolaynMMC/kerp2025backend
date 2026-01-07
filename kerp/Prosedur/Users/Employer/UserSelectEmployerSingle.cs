namespace kerp.Prosedur.Users.Employer
{
    public class UserSelectEmployerSingle
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public int WorkerId { get; set; }
        public string? WorkerName { get; set; }
        public bool? Status { get; set; }
    }
}
