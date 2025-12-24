using kerp.Prosedur.Hr.Users;
using kerp.Prosedur.Hr.Users.Mail;
using kerp.Prosedur.Hr.Users.Phone;
using kerp.Prosedur.Hr.Users.Section;
using kerp.Prosedur.Hr.Users.Structur;
using kerp.Prosedur.Hr.Users.User;
using kerp.Repository.HrRepository.UserRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Hr
{
    [Route("api/Hr/[controller]")]
    [ApiController]
    public class UserController(IUserRepository repository) : ControllerBase
    {
        private readonly IUserRepository _repository = repository;

        // ===== SELECT =====

        [HttpGet("UserSelectAdmin")]
        public IActionResult UserSelectAdmin()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserSelectAdmin>>
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

        [HttpGet("UserSelectMail")]
        public IActionResult UserSelectMail()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserSelectMail>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetUserSelectMail()
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

        [HttpGet("UserSelectPhone")]
        public IActionResult UserSelectPhone()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserSelectPhone>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetUserSelectPhone()
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

        [HttpGet("UserSelectSection")]
        public IActionResult UserSelectSection()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserSelectSection>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetUserSelectSection()
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

        [HttpGet("UserSelectStructure")]
        public IActionResult UserSelectStructure()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<UserSelectStructure>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetUserSelectStructure()
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

        // ===== INSERT / UPDATE / STATUS (USER) =====

        [HttpPost("UserInsert")]
        public IActionResult UserInsert([FromBody] UserInsert model)
        {
            try
            {
                InsertUserMailPhoneSelectList? result = _repository.Post(model);

                return Ok(new CustomerResponseModel<InsertUserMailPhoneSelectList>
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

        [HttpPut("UserUpdate")]
        public IActionResult UserUpdate([FromBody] UserUpdate model)
        {
            try
            {
                UserSelectAdmin? result = _repository.Put(model);

                return Ok(new CustomerResponseModel<UserSelectAdmin>
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

        [HttpDelete("UserStatus")]
        public IActionResult UserStatus([FromBody] UserStatus model)
        {
            try
            {
                UserSelectAdmin? result = _repository.Delete(model);

                return Ok(new CustomerResponseModel<UserSelectAdmin>
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

        // ===== MAIL =====

        [HttpPost("UserInsertMail")]
        public IActionResult UserInsertMail([FromBody] UserInsertMail model)
        {
            try
            {
                UserStatusMail? result = _repository.PostUserInsertMail(model);

                return Ok(new CustomerResponseModel<UserStatusMail>
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

        [HttpPut("UserUpdateMail")]
        public IActionResult UserUpdateMail([FromBody] UserUpdatetMail model)
        {
            try
            {
                UserStatusMail? result = _repository.PutUserUpdatetMail(model);

                return Ok(new CustomerResponseModel<UserStatusMail>
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

        [HttpDelete("UserStatusMail")]
        public IActionResult UserStatusMail([FromBody] UserStatusMail model)
        {
            try
            {
                UserStatusMail? result = _repository.DeleteUserStatusMail(model);

                return Ok(new CustomerResponseModel<UserStatusMail>
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

        // ===== PHONE =====

        [HttpPost("UserInsertPhone")]
        public IActionResult UserInsertPhone([FromBody] UserInsertPhone model)
        {
            try
            {
                UserSelectPhone? result = _repository.PostUserInsertPhone(model);

                return Ok(new CustomerResponseModel<UserSelectPhone>
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

        [HttpPut("UserUpdatePhone")]
        public IActionResult UserUpdatePhone([FromBody] UserUpdatetPhone model)
        {
            try
            {
                UserSelectPhone? result = _repository.PutUserUpdatetPhone(model);

                return Ok(new CustomerResponseModel<UserSelectPhone>
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

        [HttpDelete("UserStatusPhone")]
        public IActionResult UserStatusPhone([FromBody] UserStatus model)
        {
            try
            {
                UserSelectPhone? result = _repository.DeleteUserStatusPhone(model);

                return Ok(new CustomerResponseModel<UserSelectPhone>
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
