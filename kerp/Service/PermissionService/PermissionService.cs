using kerp.Hubs.PageHub;
using kerp.Prosedur.Admin.Permission.DSRPermission;
using kerp.Prosedur.Admin.Permission.MachineIncidentPermission;
using kerp.Prosedur.Admin.Permission.MachineIncidentReportPermission;
using kerp.Prosedur.Admin.Permission.PMOrderPermission;
using kerp.Prosedur.Admin.Permission.ProfilePermission;
using kerp.Prosedur.Users;
using kerp.Repository.AdminRepository.DSRPermissionRepository;
using kerp.Repository.AdminRepository.MachineIncidentPermissionRepository;
using kerp.Repository.AdminRepository.MachineIncidentReportPermissionRepository;
using kerp.Repository.AdminRepository.PMOrderPermissionRepository;
using kerp.Repository.AdminRepository.ProfilePermission;
using kerp.Repository.UserRepository;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Service.PermissionService
{
    public class PermissionService(
        IDSRPermissionRepository dsrPermissionRepository,
        IMachineIncidentPermissionRepository machineIncidentPermissionRepository,
        IMachineIncidentReportPermissionRepository machineIncidentReportPermissionRepository,
        IPMOrderPermissionRepository pmOrderPermissionRepository,
        IProfilePermissionRepository profilePermissionRepository,
        IUserRepository userRepository,
        IHubContext<PageHub> hubContext
    ) : IPermissionService
    {
        private readonly IDSRPermissionRepository _dsrPermissionRepository = dsrPermissionRepository;
        private readonly IMachineIncidentPermissionRepository _machineIncidentPermissionRepository = machineIncidentPermissionRepository;
        private readonly IMachineIncidentReportPermissionRepository _machineIncidentReportPermissionRepository = machineIncidentReportPermissionRepository;
        private readonly IPMOrderPermissionRepository _pmOrderPermissionRepository = pmOrderPermissionRepository;
        private readonly IProfilePermissionRepository _profilePermissionRepository = profilePermissionRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IHubContext<PageHub> _hubContext = hubContext;

        public async Task<DSRPermissionSelect?> DSRPermissionUpdate(
            DSRPermissionUpdate request)
        {
            DSRPermissionSelect? result =
                _dsrPermissionRepository.Update(request);

            if (result == null)
            {
                return null;
            }

            await SendUserPermissionUpdate(request.OperatorUserId);

            return result;
        }

        public async Task<MachineIncidentPermissionSelect?> MachineIncidentPermissionUpdate(
            MachineIncidentPermissionUpdate request)
        {
            MachineIncidentPermissionSelect? result =
                _machineIncidentPermissionRepository.Update(request);

            if (result == null)
            {
                return null;
            }

            await SendUserPermissionUpdate(request.OperatorUserId);

            return result;
        }

        public async Task<MachineIncidentReportPermissionSelect?> MachineIncidentReportPermissionUpdate(
            MachineIncidentReportPermissionUpdate request)
        {
            MachineIncidentReportPermissionSelect? result =
                _machineIncidentReportPermissionRepository.Update(request);

            if (result == null)
            {
                return null;
            }

            await SendUserPermissionUpdate(request.OperatorUserId);

            return result;
        }

        public async Task<PMOrderPermissionSelect?> PMOrderPermissionUpdate(
            PMOrderPermissionUpdate request)
        {
            PMOrderPermissionSelect? result =
                _pmOrderPermissionRepository.Update(request);

            if (result == null)
            {
                return null;
            }

            await SendUserPermissionUpdate(request.OperatorUserId);

            return result;
        }

        public async Task<ProfilePermissionSelect?> ProfilePermissionUpdate(
            ProfilePermissionUpdate request)
        {
            ProfilePermissionSelect? result =
                _profilePermissionRepository.Update(request);

            if (result == null)
            {
                return null;
            }

            await SendUserPermissionUpdate(request.OperatorUserId);

            return result;
        }

        private async Task SendUserPermissionUpdate(int operatorUserId)
        {
            UserLogin? user =
                _userRepository.UserRefleshPage(operatorUserId);

            if (user != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "UserPermissionUpdate",
                    user
                );
            }
        }
    }
}