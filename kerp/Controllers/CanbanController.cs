using kerp.Extensions;
using kerp.Prosedur.Canban;
using kerp.Repository.CanbanRepository;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanbanController(ICanbanRepository repository) : ControllerBase
    {
        [HttpPost("CanbanCard")]
        public IActionResult GetCanbanCard([FromBody] CanbanModel pageInsert)
        {
            return this.Success(repository.GetCanbanCard(pageInsert));
        }
    }
}