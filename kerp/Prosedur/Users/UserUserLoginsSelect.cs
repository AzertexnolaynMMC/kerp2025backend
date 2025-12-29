namespace kerp.Prosedur.Users
{
    public class UserUserLoginsSelect
    {
        public int Id { get; set; }                 // ltl.Id

        public int? LoginTypeId { get; set; }       // ltl.LoginTypeId
        public string? Title { get; set; }          // ltl.Title

        public string? LangTitle { get; set; }      // l.Title

        public string? LoginTitle { get; set; }     // ul.Title
        public int? UserLoginId { get; set; }       // ul.Id as UserLoginId

        public bool Status { get; set; }            // ul.Status (bit -> bool)
    }
}
