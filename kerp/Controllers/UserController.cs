using kerp.Entities;
using kerp.Repository.UserRepository;
using kerp.Service;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository repository, TokenService tokenService) : ControllerBase
    {

        private readonly IUserRepository _repository = repository;
        private readonly TokenService _tokenService = tokenService;

        [HttpPost("LoginUser")]
        public IActionResult LoginUser([FromBody] LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 4,
                        title = "Model is not valid",
                        AccessToken = null,
                        Data = null
                    });
                }

                UserLogin? userLogin = _repository.LoginUser(model);

                if (userLogin == null)
                {
                    return Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 5,
                        title = "Tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
                }

                if (userLogin.IsActive == false)
                {
                    return Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 1,
                        title = "Giriş etdiyiniz login aktiv deyildir",
                        AccessToken = null,
                        Data = null
                    });
                }

                if (userLogin.CanLogin == false)
                {
                    return Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 2,
                        title = "Giriş icazeniz yoxdur",
                        AccessToken = null,
                        Data = null
                    });
                }

                if (userLogin.Status == false)
                {
                    return Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 3,
                        title = "Hesabınız sistem tərəfindən bloklanıb",
                        AccessToken = null,
                        Data = null
                    });
                }

                // ✅ UĞURLU HAL
                string token = _tokenService.GenerateToken(
                    model.UserName!,
                    userLogin.UserId.ToString()
                );

                return Ok(new CustomerResponseModel<UserLogin>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = token,
                    Data = userLogin
                });
            }
            catch (Exception ex)
            {
                // TODO: burda öz server log sisteminizə yazın (Serilog, NLog və s.)

                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        [HttpGet("UserRefleshPage")]
        public IActionResult UserRefleshPage(int userId)
        {
            try
            {
                // ModelState check-ə ehtiyac yoxdur, primitive tipdir və [ApiController] avtomatik yoxlayır
                UserLogin? userLogin = _repository.UserRefleshPage(userId);

                if (userLogin == null)
                {
                    return Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 5,
                        title = "Tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
                }

                // Burada artıq token, IsActive, CanLogin, Status yoxlamırıq.
                // Sadəcə həmin user üçün yenilənmiş məlumatı qaytarırıq.

                return Ok(new CustomerResponseModel<UserLogin>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,   // refresdə token lazım deyil
                    Data = userLogin
                });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }






    }
}