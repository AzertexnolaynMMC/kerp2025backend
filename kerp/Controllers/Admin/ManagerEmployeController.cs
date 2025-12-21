using kerp.Prosedur.Admin.ManagerEmploye;
using kerp.Repository.AdminRepository.ManagerEmployeRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerEmployeController(IManagerEmployeRepository repository) : ControllerBase
    {
        private readonly IManagerEmployeRepository _repository = repository;
        [HttpGet("ManagerEmployeSelect")]
        public IActionResult ManagerEmployeSelect()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<ManagerEmployeSelect>>
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

        [HttpGet("ManagerEmployeUsers")]
        public IActionResult ManagerEmployeUsers()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<ManagerEmployeUsers>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.ManagerEmployeUsers()
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





        [HttpDelete("ManagerEmployeStatus")]
        public IActionResult ManagerEmployeStatus([FromBody] ManagerEmployeStatus PagesActiveAndDeactive)
        {
            try
            {
                ManagerEmployeSelect? result = _repository.Delete(PagesActiveAndDeactive);


                return Ok(new CustomerResponseModel<ManagerEmployeSelect>
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

        [HttpPost("ManagerEmployeInsert")]
        public IActionResult PageInsert([FromBody] List<ManagerEmployeInsert> PagesActiveAndDeactive)
        {
            try
            {
                List<ManagerEmployeSelect>? result = _repository.Post(PagesActiveAndDeactive);

                return Ok(new CustomerResponseModel<List<ManagerEmployeSelect>>
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
