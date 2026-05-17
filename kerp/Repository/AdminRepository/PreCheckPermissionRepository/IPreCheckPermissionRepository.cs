using kerp.Prosedur.Admin.Permission.PreCheckPermission;

namespace kerp.Repository.AdminRepository.PreCheckPermissionRepository
{
    public interface IPreCheckPermissionRepository
    {
        PreCheckPermissionSelect? Update(PreCheckPermissionUpdate preCheckPermissionUpdate);
        List<PreCheckPermissionSelect>? Select();
    }
}