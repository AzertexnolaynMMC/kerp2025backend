namespace kerp.Prosedur.Users
{
    public class UserUserConMachineSelect
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public int? MachineId { get; set; }

        public bool Status { get; set; }          // bit -> bool

        public string? Title { get; set; } // att.Title
    }
}
