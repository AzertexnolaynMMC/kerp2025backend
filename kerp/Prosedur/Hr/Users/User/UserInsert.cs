using kerp.Prosedur.Hr.Users.Mail;
using kerp.Prosedur.Hr.Users.Phone;

namespace kerp.Prosedur.Hr.Users.User
{
    public class UserInsert
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public int? StructureId { get; set; }
        public int? SectionId { get; set; }
        public int CanLogin { get; set; }

        public List<UserInsertMail>? UserInsertMail { get; set; }
        public List<UserInsertPhone>? UserInsertPhone { get; set; }
    }
}
