using kerp.Prosedur.Users.UserPage;
using System.ComponentModel.DataAnnotations.Schema;

namespace kerp.Entities;

public partial class UserLogin
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? SectionName { get; set; }

    public string? StructureName { get; set; }

    public bool? IsActive { get; set; }

    public bool? CanLogin { get; set; }

    public bool? Status { get; set; }
    [NotMapped]
    public List<UserPage>? UserPage { get; set; }
}
