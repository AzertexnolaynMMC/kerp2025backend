using kerp.Prosedur.Admin.Language;
using kerp.Repository.AdminRepository.LanguageRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController(ILanguageRepository repository) : ControllerBase
    {
        private readonly ILanguageRepository _repository = repository;


        [HttpGet("LanguageAdminAll")]
        public IActionResult LanguageAdminAll()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<LanguageAdminAll>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.LanguageAdminAll()
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


        [HttpDelete("LanguageActiveAndDeaktive")]
        public IActionResult LanguageActiveAndDeaktive([FromBody] LanguageActiveAndDeaktive PagesActiveAndDeactive)
        {
            try
            {
                LanguageAdminAll? result = _repository.LanguageActiveAndDeaktive(PagesActiveAndDeactive);

                // Burada real-time xəbər göndəririk

                return Ok(new CustomerResponseModel<LanguageAdminAll>
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



        [HttpPost("LanguageInsert")]
        public IActionResult PageInsert([FromBody] LanguageInsert PagesActiveAndDeactive)
        {
            try
            {
                LanguageAdminAll? result = _repository.LanguageInsert(PagesActiveAndDeactive);

                return Ok(new CustomerResponseModel<LanguageAdminAll>
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

        [HttpPut("LanguageUpdate")]
        public Task<IActionResult> LanguageUpdate([FromBody] LanguageUpdate PagesActiveAndDeactive)
        {
            try
            {
                LanguageAdminAll? result = _repository.LanguageUpdate(PagesActiveAndDeactive);

                // Burada real-time xəbər göndəririk


                return Task.FromResult<IActionResult>(Ok(new CustomerResponseModel<LanguageAdminAll>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = result
                }));
            }
            catch (Exception ex)
            {

                return Task.FromResult<IActionResult>(Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex,
                    AccessToken = null,
                    Data = null
                }));

            }

        }


    }
}
