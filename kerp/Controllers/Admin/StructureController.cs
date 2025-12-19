using kerp.Prosedur.Structure;
using kerp.Repository.AdminRepository.StructureRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class StructureController(IStructureRepository repository) : ControllerBase
    {
        private readonly IStructureRepository _repository = repository;

        [HttpGet("StructureSelectAdmin")]
        public IActionResult StructureSelectAdmin()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<StructureSelectAdmin>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.StructureSelectAdmin()
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



        [HttpDelete("StructureStatus")]
        public IActionResult StructureStatus([FromBody] StructureStatus PagesActiveAndDeactive)
        {
            try
            {
                StructureSelectAdmin? result = _repository.StructureStatus(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<StructureSelectAdmin>
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



        [HttpPost("StructureInsert")]
        public IActionResult StructureInsert([FromBody] StructureInsert PagesActiveAndDeactive)
        {
            try
            {
                StructureSelectAdmin? result = _repository.StructureInsert(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<StructureSelectAdmin>
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


        [HttpPut("StructureUpdate")]
        public IActionResult StructureUpdate([FromBody] StructureUpdate PagesActiveAndDeactive)
        {
            try
            {
                StructureSelectAdmin? result = _repository.StructureUpdate(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<StructureSelectAdmin>
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
