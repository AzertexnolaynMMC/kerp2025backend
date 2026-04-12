using kerp.Prosedur.Admin.Permission.PMOrderPermission;
using kerp.Prosedur.Admin.Permission.ProfilePermission;

namespace kerp.Repository.AdminRepository.PMOrderPermissionRepository
{
    public interface IPMOrderPermissionRepository
    {
        PMOrderPermissionSelect? Update(PMOrderPermissionUpdate ProfilePermissionUpdate);
        List<PMOrderPermissionSelect>? Select();
    }
}
