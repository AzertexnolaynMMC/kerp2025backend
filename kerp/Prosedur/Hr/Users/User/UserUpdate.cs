namespace kerp.Prosedur.Hr.Users.User
{
    public class UserUpdate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public int? StructureId { get; set; }
        public int? SectionId { get; set; }
        public int CanLogin { get; set; }
    }
}
