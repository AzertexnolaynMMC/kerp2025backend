using kerp.Enums;
using kerp.Prosedur.Admin.Dictionary;
using kerp.Repository.AdminRepository.DictionaryRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController(IDictionaryRepository repository) : ControllerBase
    {

        private readonly IDictionaryRepository _repository = repository;

        [HttpGet("DictionaryAdminAll")]
        public IActionResult DictionaryAdminAll([FromQuery] LangAdminProc proc)
        {
            try
            {


                return Ok(new CustomerResponseModel<List<DictionaryAdminAll>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.DictionaryAdminAll(proc)
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
        [HttpGet("DictionarySelect")]
        public IActionResult DictionarySelect([FromQuery] LangAdminProc proc)
        {
            try
            {


                return Ok(new CustomerResponseModel<List<DictionarySelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.DictionarySelect(proc)
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
        [HttpGet("DictionarySelectLanguage")]
        public IActionResult DictionarySelectLanguage()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<DictionarySelectLanguage>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.DictionarySelectLanguage()
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



        [HttpPost("DictionaryInsertRequest")]
        public IActionResult PageInsert([FromBody] List<DictionaryInsertRequest> PagesActiveAndDeactive)
        {
            try
            {
                List<DictionaryAdminAll>? result = _repository.DictionaryInsertRequest(PagesActiveAndDeactive);

                return Ok(new CustomerResponseModel<List<DictionaryAdminAll>>
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
        [HttpPut("DictionaryUpdate")]
        public IActionResult DictionaryUpdate([FromBody] DictionaryUpdate PagesActiveAndDeactive)
        {
            try
            {
                DictionaryAdminAll result = _repository.DictionaryUpdate(PagesActiveAndDeactive);

                return Ok(new CustomerResponseModel<DictionaryAdminAll>
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
        [HttpDelete("DictionaryStatus")]
        public IActionResult DictionaryStatus([FromBody] DictionaryStatus PagesActiveAndDeactive)
        {
            try
            {
                DictionaryAdminAll result = _repository.DictionaryStatus(PagesActiveAndDeactive);

                return Ok(new CustomerResponseModel<DictionaryAdminAll>
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
