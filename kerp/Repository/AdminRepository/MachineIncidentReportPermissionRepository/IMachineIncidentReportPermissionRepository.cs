using kerp.Prosedur.Admin.Permission.MachineIncidentReportPermission;

namespace kerp.Repository.AdminRepository.MachineIncidentReportPermissionRepository
{
    public interface IMachineIncidentReportPermissionRepository
    {
        MachineIncidentReportPermissionSelect? Update(MachineIncidentReportPermissionUpdate request);
        List<MachineIncidentReportPermissionSelect>? Select();
    }
}
