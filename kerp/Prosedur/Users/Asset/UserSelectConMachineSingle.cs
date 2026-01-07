namespace kerp.Prosedur.Users.Asset
{
    public class UserSelectConMachineSingle
    {
        public int Id { get; set; }

        public int? UserId { get; set; }          // LEFT JOIN olduğuna görə null ola bilər

        public int? MachineId { get; set; }       // LEFT JOIN olduğuna görə null ola bilər
        public string? Title { get; set; }        // AssetTitle.Title

        public bool Status { get; set; }
    }
}
