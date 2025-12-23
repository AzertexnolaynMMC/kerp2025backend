using kerp.Prosedur.Admin.Logs;
using kerp.Repository.AdminRepository.LogsRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController(ILogsRepository repository) : ControllerBase
    {
        private readonly ILogsRepository _repository = repository;

        [HttpGet("SqlLogSelect")]
        public IActionResult SqlLogSelect()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<SqlLogSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetSqlLogSelect()
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
