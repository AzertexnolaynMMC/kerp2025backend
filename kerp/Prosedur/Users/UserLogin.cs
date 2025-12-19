namespace kerp.Prosedur.Users
{
    public class UserLogin
    {
        public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? SectionName { get; set; }

        public string? StructureName { get; set; }

        public bool IsActive { get; set; }

        public bool CanLogin { get; set; }

        public bool Status { get; set; }
    }
}
