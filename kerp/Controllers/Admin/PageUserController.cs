using kerp.Hubs.PageHub;
using kerp.Prosedur.Admin.PageUser;
using kerp.Repository.AdminRepository.PageUserRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageUserController(IPageUserRepository repository, IHubContext<PageHub> hubContext) : ControllerBase
    {
        private readonly IPageUserRepository _repository = repository;
        private readonly IHubContext<PageHub> _hubContext = hubContext;

        [HttpGet("PageUserSelectAdmin")]
        public IActionResult PageUserSelectAdmin()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<PageUserSelectAdmin>>
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



        [HttpGet("PageUserSelectPage")]
        public IActionResult PageUserSelectPage()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<PageUserSelectPage>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetPageUserSelectPage()
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
        [HttpGet("PageUserSelectUser")]
        public IActionResult PageUserSelectUser()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<PageUserSelectUser>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetPageUserSelectUser()
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





        [HttpDelete("PageUserStatus")]
        public async Task<IActionResult> PageUserStatus([FromBody] PageUserStatus PagesActiveAndDeactive)
        {
            try
            {
                PageUserSelectAdmin? result = _repository.Delete(PagesActiveAndDeactive);

                // Burada real-time xəbər göndəririk
                await _hubContext.Clients.All.SendAsync(
                   "PagesActiveAndDeactiveChanged",
                   1
               );

                return Ok(new CustomerResponseModel<PageUserSelectAdmin>
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

        [HttpPost("PageUserInsert")]
        public async Task<IActionResult> PageInsertAsync([FromBody] List<PageUserInsert> PagesActiveAndDeactive)
        {

            try
            {
                List<PageUserSelectAdmin>? result = _repository.Post(PagesActiveAndDeactive);
                await _hubContext.Clients.All.SendAsync(
   "PagesActiveAndDeactiveChanged",
   1
);

                return Ok(new CustomerResponseModel<List<PageUserSelectAdmin>>
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
