namespace kerp.Prosedur.Admin.UserConMachine
{
    public class UserConMachineSelectAdmin
    {
        public int Id { get; set; }

        public int? UserId { get; set; }          // LEFT JOIN olduğuna görə null ola bilər
        public string? UserTitle { get; set; }    // FirstName + LastName

        public int? MachineId { get; set; }       // LEFT JOIN olduğuna görə null ola bilər
        public string? Title { get; set; }        // AssetTitle.Title

        public bool Status { get; set; }
    }
}
