using kerp.Prosedur.Canban;
using kerp.Repository.CanbanRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanbanController(ICanbanRepository repository) : ControllerBase
    {
        private readonly ICanbanRepository _repository = repository;

        [HttpPost("CanbanCard")]
        public IActionResult GetCanbanCard([FromBody] CanbanModel pageInsert)
        {
            try
            {
                List<CanbanCard>? result = _repository.GetCanbanCard(pageInsert);

                return Ok(new CustomerResponseModel<List<CanbanCard>>
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
