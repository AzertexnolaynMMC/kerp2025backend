using kerp.Hubs.PageHub;
using kerp.Prosedur.Admin.Permission.MachineIncidentReportPermission;
using kerp.Repository.AdminRepository.MachineIncidentReportPermissionRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineIncidentReportPermissionController(IMachineIncidentReportPermissionRepository repository, IHubContext<PageHub> hubContext) : ControllerBase
    {
        private readonly IMachineIncidentReportPermissionRepository _repository = repository;
        private readonly IHubContext<PageHub> _hubContext = hubContext;

        [HttpGet("Select")]
        public IActionResult Select()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<MachineIncidentReportPermissionSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.Select()
                });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] MachineIncidentReportPermissionUpdate request)
        {
            try
            {
                MachineIncidentReportPermissionSelect? result = _repository.Update(request);
                await _hubContext.Clients.All.SendAsync("PagesActiveAndDeactiveChanged", 1);
                return Ok(new CustomerResponseModel<MachineIncidentReportPermissionSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex,
                    AccessToken = null,
                    Data = null
                });
            }
        }
    }
}