using kerp.Prosedur.Admin.Section;
using kerp.Repository.AdminRepository.SectionRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController(ISectionRepository repository) : ControllerBase
    {
        private readonly ISectionRepository _repository = repository;


        [HttpGet("SectionStructureSelect")]
        public IActionResult SectionStructureSelect()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<SectionStructureSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetSectionStructureSelect()
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
        [HttpGet("SectionSelectAdmin")]
        public IActionResult SectionSelectAdmin()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<SectionSelectAdmin>>
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



        [HttpDelete("SectionStatus")]
        public IActionResult SectionStatus([FromBody] SectionStatus PagesActiveAndDeactive)
        {
            try
            {
                SectionSelectAdmin? result = _repository.Delete(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<SectionSelectAdmin>
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



        [HttpPost("SectionInsert")]
        public IActionResult SectionInsert([FromBody] SectionInsert PagesActiveAndDeactive)
        {
            try
            {
                SectionSelectAdmin? result = _repository.Post(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<SectionSelectAdmin>
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


        [HttpPut("SectionUpdate")]
        public IActionResult SectionUpdate([FromBody] SectionUpdate PagesActiveAndDeactive)
        {
            try
            {
                SectionSelectAdmin? result = _repository.Put(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<SectionSelectAdmin>
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
