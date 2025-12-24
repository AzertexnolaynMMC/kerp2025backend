using kerp.Prosedur.Admin.UserLogins;
using kerp.Repository.AdminRepository.UserLoginsRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginsController(IUserLoginsRepository repository) : ControllerBase
    {
        private readonly IUserLoginsRepository _repository = repository;

        [HttpGet("UserLoginsSelectAdmin")]
        public IActionResult UserLoginsSelectAdmin()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserLoginsSelectAdmin>>
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

        [HttpGet("UserLoginsSelectLoginType")]
        public IActionResult UserLoginsSelectLoginType()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserLoginsSelectLoginType>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetUserLoginsSelectLoginType()
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

        [HttpGet("UserLoginsSelectUser")]
        public IActionResult UserLoginsSelectUser()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserLoginsSelectUser>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetUserLoginsSelectUser()
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

        [HttpPost("UserLoginsInsert")]
        public IActionResult UserLoginsInsert([FromBody] UserLoginsInsert model)
        {
            try
            {
                UserLoginsSelectAdmin? result = _repository.Post(model);

                return Ok(new CustomerResponseModel<UserLoginsSelectAdmin>
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

        [HttpPut("UserLoginsUpdate")]
        public IActionResult UserLoginsUpdate([FromBody] UserLoginsUpdate model)
        {
            try
            {
                UserLoginsSelectAdmin? result = _repository.Put(model);

                return Ok(new CustomerResponseModel<UserLoginsSelectAdmin>
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

        [HttpDelete("UserLoginsStatus")]
        public IActionResult UserLoginsStatus([FromBody] UserLoginsStatus model)
        {
            try
            {
                UserLoginsSelectAdmin? result = _repository.Delete(model);

                return Ok(new CustomerResponseModel<UserLoginsSelectAdmin>
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
