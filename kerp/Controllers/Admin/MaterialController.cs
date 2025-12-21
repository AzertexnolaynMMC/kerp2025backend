using kerp.Prosedur.Admin.Material;
using kerp.Repository.AdminRepository.MaterialRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController(IMaterialRepository repository) : ControllerBase
    {
        private readonly IMaterialRepository _repository = repository;
        [HttpGet("MaterialSelectAdmin")]
        public IActionResult MaterialSelectAdmin()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<MaterialSelectAdmin>>
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
        [HttpDelete("MaterialStatus")]
        public IActionResult MaterialStatus([FromBody] MaterialStatus PagesActiveAndDeactive)
        {
            try
            {
                MaterialSelectAdmin? result = _repository.Delete(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<MaterialSelectAdmin>
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
        [HttpPost("MaterialInsert")]
        public IActionResult MaterialInsert([FromBody] MaterialInsert PagesActiveAndDeactive)
        {
            try
            {
                MaterialSelectAdmin? result = _repository.Post(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<MaterialSelectAdmin>
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
        [HttpPut("MaterialUpdate")]
        public IActionResult MaterialUpdate([FromBody] MaterialUpdate PagesActiveAndDeactive)
        {
            try
            {
                MaterialSelectAdmin? result = _repository.Put(PagesActiveAndDeactive);
                return Ok(new CustomerResponseModel<MaterialSelectAdmin>
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
