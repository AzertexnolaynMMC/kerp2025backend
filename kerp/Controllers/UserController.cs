using kerp.Prosedur.Admin.Logs;
using kerp.Prosedur.Users;
using kerp.Prosedur.Users.Asset;
using kerp.Prosedur.Users.Employer;
using kerp.Prosedur.Users.Login;
using kerp.Prosedur.Users.Mail;
using kerp.Prosedur.Users.phone;
using kerp.Repository.UserRepository;
using kerp.Service;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository repository, TokenService tokenService, LdapService ldapService) : ControllerBase
    {

        private readonly IUserRepository _repository = repository;
        private readonly TokenService _tokenService = tokenService;
        private readonly LdapService _ldapService = ldapService;

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

                UserLogin? userLogin = null;

                // 🔹 LDAP LOGIN
                if (model.LoginType == 2)
                {
                    bool ldapOk = _ldapService.Authenticate(
                        model.UserName!,
                        model.Password!
                    );

                    if (!ldapOk)
                    {
                        return Ok(new CustomerResponseModel<object>
                        {
                            StatusCode = 5,
                            title = "LDAP istifadəçisi tapılmadı və ya şifrə yanlışdır",
                            AccessToken = null,
                            Data = null
                        });
                    }

                    // ✅ LDAP OK → DB-ə BAX
                    userLogin = _repository.LoginUser(model);

                    if (userLogin == null)
                    {
                        return Ok(new CustomerResponseModel<object>
                        {
                            StatusCode = 6,
                            title = "LDAP istifadəçisi var, amma sistemdə qeydiyyatda deyil",
                            AccessToken = null,
                            Data = null
                        });
                    }
                }
                else
                {
                    // 🔹 KÖHNƏ DB LOGIN (SƏN NECƏ YAZMISANS AYNISI)
                    userLogin = _repository.LoginUser(model);

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
                }

                // 🔐 ORTAQ YOXLAMALAR
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
                        title = "Giriş icazəniz yoxdur",
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

                // ✅ TOKEN
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
            catch (Exception)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error",
                    AccessToken = null,
                    Data = null
                });
            }
        }




        [HttpPost("AppLogsInsert")]
        public IActionResult AppLogsInsert([FromBody] List<AppLogsInsert> model)
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

                int? userLogin = _repository.AppLogsInsert(model);
                return userLogin == 1
                    ? Ok(new CustomerResponseModel<UserLogin>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<UserLogin>
                    {
                        StatusCode = 1,
                        title = "Xəta baş verdi",
                        AccessToken = null,
                        Data = null
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
        [HttpPost("UserNameSurnamePositionUpdate")]
        public IActionResult UserNameSurnamePositionUpdate([FromBody] UserNameSurnamePositionUpdate model)
        {
            try
            {
                return !ModelState.IsValid
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 4,
                        title = "Model is not valid",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<UserSelectShortInfo>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = _repository.UserNameSurnamePositionUpdate(model)
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
        [HttpPost("UserInsertMailSingle")]
        public IActionResult UserInsertMailSingle([FromBody] UserInsertMailSingle model)
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

                UserSelectMailSingle? result = _repository.PostUserInsertMailSingle(model);

                // Title var -> null gəlir
                if (result == null)
                {
                    return Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Bu title artıq mövcuddur",
                        AccessToken = null,
                        Data = null
                    });
                }

                // Uğurlu
                return Ok(new CustomerResponseModel<UserSelectMailSingle>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }
        [HttpPut("UserUpdateMailSingle")]
        public IActionResult UserUpdateMailSingle([FromBody] UserUpdateMailSingle model)
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

                UserSelectMailSingle? result = _repository.PutUserUpdateMailSingle(model);

                // Title var -> null gəlir
                if (result == null)
                {
                    return Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Bu title artıq mövcuddur",
                        AccessToken = null,
                        Data = null
                    });
                }

                // Uğurlu
                return Ok(new CustomerResponseModel<UserSelectMailSingle>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }
        [HttpDelete("UserStatusMailSingle")]
        public IActionResult UserStatusMailSingle([FromBody] UserStatusMailSingle model)
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

                UserSelectMailSingle? result = _repository.DeleteUserStatusMailSingle(model);

                // null gəlibsə -> StatusCode 7
                if (result == null)
                {
                    return Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Əməliyyat icra olunmadı",
                        AccessToken = null,
                        Data = null
                    });
                }

                // uğurlu -> 0
                return Ok(new CustomerResponseModel<UserSelectMailSingle>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }
        [HttpPost("UserInsertPhoneSingle")]
        public IActionResult UserInsertPhoneSingle([FromBody] UserInsertPhoneSingle model)
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

                UserPhoneInfoSelect? result = _repository.PostUserInsertPhoneSingle(model);

                // Title var -> null gəlir
                if (result == null)
                {
                    return Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Bu title artıq mövcuddur",
                        AccessToken = null,
                        Data = null
                    });
                }

                // Uğurlu
                return Ok(new CustomerResponseModel<UserPhoneInfoSelect>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }
        [HttpPut("UserUpdatePhoneSingle")]
        public IActionResult UserUpdatePhoneSingle([FromBody] UserUpdatePhoneSingle model)
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

                UserPhoneInfoSelect? result = _repository.PutUserUpdatePhoneSingle(model);

                // Title var -> null gəlir
                if (result == null)
                {
                    return Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Bu title artıq mövcuddur",
                        AccessToken = null,
                        Data = null
                    });
                }

                // Uğurlu
                return Ok(new CustomerResponseModel<UserPhoneInfoSelect>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }
        [HttpDelete("UserStatusPhoneSingle")]
        public IActionResult UserStatusPhoneSingle([FromBody] UserStatusPhoneSingle model)
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

                UserPhoneInfoSelect? result = _repository.DeleteUserStatusPhoneSingle(model);

                // null gəlibsə -> StatusCode 7
                if (result == null)
                {
                    return Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Əməliyyat icra olunmadı",
                        AccessToken = null,
                        Data = null
                    });
                }

                // uğurlu -> 0
                return Ok(new CustomerResponseModel<UserPhoneInfoSelect>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        // =========================
        // CON MACHINE SINGLE - INSERT
        // =========================
        [HttpPost("UserInsertConMachineSingle")]
        public IActionResult UserInsertConMachineSingle([FromBody] UserInsertConMachineSingle model)
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

                UserSelectConMachineSingle? result = _repository.PostUserInsertConMachineSingle(model);

                return result == null
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Əməliyyat icra olunmadı",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<UserSelectConMachineSingle>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        // =========================
        // CON MACHINE SINGLE - STATUS/DELETE
        // =========================
        [HttpDelete("UserStatusConMachineSingle")]
        public IActionResult UserStatusConMachineSingle([FromBody] UserStatusConMachineSingle model)
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

                UserSelectConMachineSingle? result = _repository.DeleteUserStatusConMachineSingle(model);

                return result == null
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Əməliyyat icra olunmadı",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<UserSelectConMachineSingle>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        // =========================
        // ASSETS - SELECT LIST
        // =========================
        [HttpGet("UserSelectAssets")]
        public IActionResult UserSelectAssets()
        {
            try
            {
                List<UserSelectAssets>? result = _repository.GetUserSelectAssets();

                return result == null || result.Count == 0
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 5,
                        title = "Tapılmadı",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<List<UserSelectAssets>>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        // =========================
        // EMPLOYER SINGLE - INSERT
        // =========================
        [HttpPost("UserInsertEmployerSingle")]
        public IActionResult UserInsertEmployerSingle([FromBody] UserInsertEmployerSingle model)
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

                UserSelectEmployerSingle? result = _repository.PostUserInsertEmployerSingle(model);

                return result == null
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Əməliyyat icra olunmadı",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<UserSelectEmployerSingle>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        // =========================
        // EMPLOYER SINGLE - STATUS/DELETE
        // =========================
        [HttpDelete("UserStatusEmployerSingle")]
        public IActionResult UserStatusEmployerSingle([FromBody] UserStatusEmployerSingle model)
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

                UserSelectEmployerSingle? result = _repository.DeleteUserStatusEmployerSingle(model);

                return result == null
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Əməliyyat icra olunmadı",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<UserSelectEmployerSingle>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        // =========================
        // EMPLOYER MULTI - SELECT LIST
        // =========================
        [HttpGet("UserSelectEmployerMulti")]
        public IActionResult UserSelectEmployerMulti()
        {
            try
            {
                List<UserSelectEmployerMulti>? result = _repository.GetUserSelectEmployerMulti();

                return result == null || result.Count == 0
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 5,
                        title = "Tapılmadı",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<List<UserSelectEmployerMulti>>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        // =========================
        // LOGIN SINGLE - INSERT
        // =========================
        [HttpPost("UserInsertLoginSingle")]
        public IActionResult UserInsertLoginSingle([FromBody] UserInsertLoginSingle model)
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

                UserSelectLoginSingle? result = _repository.PostUserInsertLoginSingle(model);

                return result == null
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Əməliyyat icra olunmadı",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<UserSelectLoginSingle>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        // =========================
        // LOGIN SINGLE - UPDATE
        // =========================
        [HttpPut("UserUpdateLoginSingle")]
        public IActionResult UserUpdateLoginSingle([FromBody] UserUpdateLoginSingle model)
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

                UserSelectLoginSingle? result = _repository.PutUserUpdateLoginSingle(model);

                return result == null
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Əməliyyat icra olunmadı",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<UserSelectLoginSingle>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        // =========================
        // LOGIN SINGLE - STATUS/DELETE
        // =========================
        [HttpDelete("UserStatusLoginSingle")]
        public IActionResult UserStatusLoginSingle([FromBody] UserStatusLoginSingle model)
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

                UserSelectLoginSingle? result = _repository.DeleteUserStatusLoginSingle(model);

                return result == null
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 7,
                        title = "Əməliyyat icra olunmadı",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<UserSelectLoginSingle>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        // =========================
        // LOGIN TYPE MULTI - SELECT LIST
        // =========================
        [HttpGet("UserSelectLoginTypeMulti")]
        public IActionResult UserSelectLoginTypeMulti()
        {
            try
            {
                List<UserSelectLoginTypeMulti>? result = _repository.GetUserSelectLoginTypeMulti();

                return result == null || result.Count == 0
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 5,
                        title = "Tapılmadı",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<List<UserSelectLoginTypeMulti>>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

    }
}