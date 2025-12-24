namespace kerp.Prosedur.Hr.Users.User
{
    public class UserSelectAdmin
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }

        public int? StructureId { get; set; }
        public string? StructurTitle { get; set; }   // s.Title

        public int? SectionId { get; set; }
        public string? SectionTitle { get; set; }    // sec.Title (prosedurda TItle yazılıb)

        public bool IsActive { get; set; }           // bit -> bool
        public bool CanLogin { get; set; }           // bit -> bool
    }
}
