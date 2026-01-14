using kerp.Hubs.PageHub;
using kerp.Prosedur.Admin.UserWorkOrderSee;
using kerp.Repository.AdminRepository.UserWorkOrderRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWorkOrderSeeController(
        IUserWorkOrderRepository repository,
        IHubContext<PageHub> hubContext) : ControllerBase
    {
        private readonly IUserWorkOrderRepository _repository = repository;
        private readonly IHubContext<PageHub> _hubContext = hubContext;

        #region Select

        [HttpGet("UserWorkOrderSeeSelect")]
        public IActionResult UserWorkOrderSeeSelect()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserWorkOrderSeeSelect>>
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

        [HttpGet("UserWorkOrderSeeUsersSelect")]
        public IActionResult UserWorkOrderSeeUsersSelect()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserWorkOrderSeeUsersSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetUserWorkOrderSeeUsersSelect()
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

        [HttpGet("UserWorkOrderSeeWorkOrderSelect")]
        public IActionResult UserWorkOrderSeeWorkOrderSelect()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserWorkOrderSeeWorkOrderSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetUserWorkOrderSeeWorkOrderSelect()
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

        [HttpPost("UserWorkOrderSeeInsert")]
        public async Task<IActionResult> UserWorkOrderSeeInsert(
            [FromBody] List<UserWorkOrderSeeInsert> insert)
        {
            try
            {
                List<UserWorkOrderSeeSelect>? result = _repository.Post(insert);

                // 🔔 Real-time xəbər
                await _hubContext.Clients.All.SendAsync(
                    "PagesActiveAndDeactiveChanged",
                    1
                );

                return Ok(new CustomerResponseModel<List<UserWorkOrderSeeSelect>>
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

        [HttpDelete("UserWorkOrderSeeStatus")]
        public async Task<IActionResult> UserWorkOrderSeeStatus(
            [FromBody] UserWorkOrderSeeStatus status)
        {
            try
            {
                UserWorkOrderSeeSelect? result = _repository.Delete(status);

                // 🔔 Real-time xəbər
                await _hubContext.Clients.All.SendAsync(
                    "PagesActiveAndDeactiveChanged",
                    1
                );

                return Ok(new CustomerResponseModel<UserWorkOrderSeeSelect>
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
