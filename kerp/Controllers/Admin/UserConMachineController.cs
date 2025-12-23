using kerp.Prosedur.Admin.UserConMachine;
using kerp.Repository.AdminRepository.UserConMachineRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConMachineController(IUserConMachineRepository repository) : ControllerBase
    {

        private readonly IUserConMachineRepository _repository = repository;


        [HttpGet("UserConMachineSelectAdmin")]
        public IActionResult UserConMachineSelectAdmin()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<UserConMachineSelectAdmin>>
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
        [HttpGet("UserConMachineSelectUser")]
        public IActionResult UserConMachineSelectUser()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<UserConMachineSelectUser>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetUserConMachineSelectUser()
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



        [HttpGet("UserConMachineSelectMachine")]
        public IActionResult UserConMachineSelectMachine()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<UserConMachineSelectMachine>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetUserConMachineSelectMachine()
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



        [HttpDelete("WorkOrderTypeStatus")]
        public IActionResult SectionStatus([FromBody] UserConMachineStatus PagesActiveAndDeactive)
        {
            try
            {
                UserConMachineSelectAdmin? result = _repository.Delete(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<UserConMachineSelectAdmin>
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



        [HttpPost("WorkOrderTypeInsert")]
        public IActionResult SectionInsert([FromBody] List<UserConMachineInsert> PagesActiveAndDeactive)
        {
            try
            {
                List<UserConMachineSelectAdmin>? result = _repository.Post(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<List<UserConMachineSelectAdmin>>
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
