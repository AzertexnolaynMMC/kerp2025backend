using kerp.Hubs.PageHub;
using kerp.Prosedur.Admin.Permission.MachineIncidentPermission;
using kerp.Repository.AdminRepository.MachineIncidentPermissionRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineIncidentPermissionController(IMachineIncidentPermissionRepository repository, IHubContext<PageHub> hubContext) : ControllerBase
    {
        private readonly IMachineIncidentPermissionRepository _repository = repository;
        private readonly IHubContext<PageHub> _hubContext = hubContext;

        [HttpGet("Select")]
        public IActionResult Select()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<MachineIncidentPermissionSelect>>
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
        public async Task<IActionResult> Update([FromBody] MachineIncidentPermissionUpdate PagesActiveAndDeactive)
        {
            try
            {
                MachineIncidentPermissionSelect? result = _repository.Update(PagesActiveAndDeactive);


                await _hubContext.Clients.All.SendAsync("PagesActiveAndDeactiveChanged", 1);
                return Ok(new CustomerResponseModel<MachineIncidentPermissionSelect>
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
