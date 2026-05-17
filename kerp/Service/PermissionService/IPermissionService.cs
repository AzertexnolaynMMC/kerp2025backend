using kerp.Prosedur.Admin.Permission.DSRPermission;
using kerp.Prosedur.Admin.Permission.MachineIncidentPermission;
using kerp.Prosedur.Admin.Permission.MachineIncidentReportPermission;
using kerp.Prosedur.Admin.Permission.PMOrderPermission;
using kerp.Prosedur.Admin.Permission.ProfilePermission;

namespace kerp.Service.PermissionService
{
    public interface IPermissionService
    {
        Task<DSRPermissionSelect?> DSRPermissionUpdate(
            DSRPermissionUpdate request
        );

        Task<MachineIncidentPermissionSelect?> MachineIncidentPermissionUpdate(
            MachineIncidentPermissionUpdate request
        );

        Task<MachineIncidentReportPermissionSelect?> MachineIncidentReportPermissionUpdate(
            MachineIncidentReportPermissionUpdate request
        );

        Task<PMOrderPermissionSelect?> PMOrderPermissionUpdate(
            PMOrderPermissionUpdate request
        );

        Task<ProfilePermissionSelect?> ProfilePermissionUpdate(
            ProfilePermissionUpdate request
        );
    }
}