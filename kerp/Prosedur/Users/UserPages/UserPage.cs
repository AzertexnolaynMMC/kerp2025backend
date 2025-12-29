using System.ComponentModel.DataAnnotations.Schema;

namespace kerp.Prosedur.Users.UserPages
{
    public class UserPage
    {
        public int? Id { get; set; }          // pu.Id
        public string? Route { get; set; }    // p.Route
        public string? Icon { get; set; }     // p.Icon
        public int? PageId { get; set; }      // pu.PageId
        public string? LangRoute { get; set; }// p.LangRoute
        [NotMapped]
        public List<UserPage>? UserPagess { get; set; }
    }
}
