namespace kerp.Prosedur.Users.UserPages
{
    public class UserRefleshPage
    {
        public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? SectionName { get; set; }

        public string? StructureName { get; set; }
        public string? Position { get; set; }

        public bool? IsActive { get; set; }

        public bool? CanLogin { get; set; }

        // UserLogins LEFT JOIN olduğu üçün null ola bilər
        public bool? Status { get; set; }
    }
}
