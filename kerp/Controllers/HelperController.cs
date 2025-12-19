using kerp.Prosedur.Helpers;
using kerp.Repository.HelperRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController(IHelperRepository repository) : ControllerBase
    {

        private readonly IHelperRepository _repository = repository;
        [HttpGet("LoginTypeLangs")]
        public IActionResult LoginTypeLangs()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<LoginTypeLang>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.LoginTypeLangs()
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
