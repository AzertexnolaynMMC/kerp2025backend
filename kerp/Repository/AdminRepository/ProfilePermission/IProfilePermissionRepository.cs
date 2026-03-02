using kerp.Prosedur.Admin.Permission.ProfilePermission;

namespace kerp.Repository.AdminRepository.ProfilePermission
{
    public interface IProfilePermissionRepository
    {
        ProfilePermissionSelect? Update(ProfilePermissionUpdate ProfilePermissionUpdate);
        List<ProfilePermissionSelect>? Select();
    }
}
