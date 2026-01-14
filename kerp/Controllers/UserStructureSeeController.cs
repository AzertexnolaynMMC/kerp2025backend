using kerp.Hubs.PageHub;
using kerp.Prosedur.Admin.UserStructureSee;
using kerp.Repository.AdminRepository.UserStructureSeeRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStructureSeeController(
        IUserStructureSeeRepository repository,
        IHubContext<PageHub> hubContext) : ControllerBase
    {
        private readonly IUserStructureSeeRepository _repository = repository;
        private readonly IHubContext<PageHub> _hubContext = hubContext;

        #region Select

        [HttpGet("UserStructureSeeSelect")]
        public IActionResult UserStructureSeeSelect()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserStructureSeeSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.Get()
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

        [HttpGet("UserStructureSeeStructureSelect")]
        public IActionResult UserStructureSeeStructureSelect()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserStructureSeeStructureSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetUserStructureSeeStructureSelect()
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

        [HttpGet("UserStructureSeeUserSelect")]
        public IActionResult UserStructureSeeUserSelect()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserStructureSeeUserSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetUserStructureSeeUserSelect()
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

        #endregion

        #region Insert

        [HttpPost("UserStructureSeeInsert")]
        public async Task<IActionResult> UserStructureSeeInsert(
            [FromBody] List<UserStructureSeeInsert> insert)
        {
            try
            {
                List<UserStructureSeeSelect>? result = _repository.Post(insert);

                // 🔔 Real-time xəbər
                await _hubContext.Clients.All.SendAsync(
                    "PagesActiveAndDeactiveChanged",
                    1
                );

                return Ok(new CustomerResponseModel<List<UserStructureSeeSelect>>
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

        #endregion

        #region Status (Active / Deactive)

        [HttpDelete("UserStructureSeeStatus")]
        public async Task<IActionResult> UserStructureSeeStatus(
            [FromBody] UserStructureSeeStatus status)
        {
            try
            {
                UserStructureSeeSelect? result = _repository.Delete(status);

                // 🔔 Real-time xəbər
                await _hubContext.Clients.All.SendAsync(
                    "PagesActiveAndDeactiveChanged",
                    1
                );

                return Ok(new CustomerResponseModel<UserStructureSeeSelect>
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

        #endregion
    }
}
