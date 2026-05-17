using kerp.Prosedur.Admin.Permission.DSRPermission;

namespace kerp.Repository.AdminRepository.DSRPermissionRepository
{
    public interface IDSRPermissionRepository
    {
        DSRPermissionSelect? Update(DSRPermissionUpdate DSRPermissionUpdate);
        List<DSRPermissionSelect>? Select();
    }
}
