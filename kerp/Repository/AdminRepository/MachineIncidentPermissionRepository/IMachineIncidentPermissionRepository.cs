using kerp.Prosedur.Admin.Permission.MachineIncidentPermission;

namespace kerp.Repository.AdminRepository.MachineIncidentPermissionRepository
{
    public interface IMachineIncidentPermissionRepository
    {
        MachineIncidentPermissionSelect? Update(MachineIncidentPermissionUpdate MachineIncidentPermissionUpdate);
        List<MachineIncidentPermissionSelect>? Select();
    }
}
