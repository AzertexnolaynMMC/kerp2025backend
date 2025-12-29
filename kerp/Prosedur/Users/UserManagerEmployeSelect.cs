namespace kerp.Prosedur.Users
{
    public class UserManagerEmployeSelect
    {
        public int Id { get; set; }

        public int? ManagerId { get; set; }
        public int? WorkerId { get; set; }

        public bool Status { get; set; }      // bit -> bool

        public string? WorkerName { get; set; } // u.LastName + ' ' + u.FirstName
    }
}
