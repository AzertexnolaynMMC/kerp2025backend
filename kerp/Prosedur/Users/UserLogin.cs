using kerp.Prosedur.Users.UserPages;
using System.ComponentModel.DataAnnotations.Schema;

namespace kerp.Prosedur.Users
{
    public class UserLogin
    {
        public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? SectionName { get; set; }

        public string? StructureName { get; set; }
        public string? Position { get; set; }
        public bool? IsActive { get; set; }

        public bool? CanLogin { get; set; }

        public bool? Status { get; set; }
        [NotMapped]
        public List<UserPage>? UserPage { get; set; }
        [NotMapped]
        public List<UserMailInfoSelect>? UserMailInfoSelect { get; set; }
        [NotMapped]
        public List<UserManagerEmployeSelect>? UserManagerEmployeSelect { get; set; }
        [NotMapped]
        public List<UserUserConMachineSelect>? UserUserConMachineSelect { get; set; }
        [NotMapped]
        public List<UserUserLoginsSelect>? UserUserLoginsSelect { get; set; }
        [NotMapped]
        public List<UserPhoneInfoSelect>? UserPhoneInfoSelect { get; set; }
    }
}
