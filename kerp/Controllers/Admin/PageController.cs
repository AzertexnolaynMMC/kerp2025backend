using kerp.Hubs.PageHub;
using kerp.Prosedur.Admin.Pages;
using kerp.Repository.AdminRepository.PageRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController(IPageRepository repository, IHubContext<PageHub> hubContext) : ControllerBase
    {
        private readonly IPageRepository _repository = repository;
        private readonly IHubContext<PageHub> _hubContext = hubContext;

        [HttpGet("PageAdminAll")]
        public IActionResult PageAdminAll()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<PageAdminAll>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PageAdminAll()
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

        [HttpDelete("PagesActiveAndDeactive")]
        public async Task<IActionResult> PagesActiveAndDeactiveAsync([FromBody] PagesActiveAndDeactive PagesActiveAndDeactive)
        {
            try
            {
                PageAdminAll? result = _repository.PagesActiveAndDeactive(PagesActiveAndDeactive);

                // Burada real-time xəbər göndəririk
                await _hubContext.Clients.All.SendAsync(
                   "PagesActiveAndDeactiveChanged",
                   1
               );

                return Ok(new CustomerResponseModel<PageAdminAll>
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

        [HttpPut("PageUpdate")]
        public async Task<IActionResult> PageUpdate([FromBody] PageUpdate PagesActiveAndDeactive)
        {
            try
            {
                PageAdminAll? result = _repository.PageUpdate(PagesActiveAndDeactive);

                // Burada real-time xəbər göndəririk
                await _hubContext.Clients.All.SendAsync(
                   "PagesActiveAndDeactiveChanged",
                   1
               );

                return Ok(new CustomerResponseModel<PageAdminAll>
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





        [HttpPost("PageInsert")]
        public IActionResult PageInsert([FromBody] PageInsert PagesActiveAndDeactive)
        {
            try
            {
                PageAdminAll? result = _repository.PageInsert(PagesActiveAndDeactive);

                return Ok(new CustomerResponseModel<PageAdminAll>
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
