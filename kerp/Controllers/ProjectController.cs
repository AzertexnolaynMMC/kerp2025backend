using kerp.Prosedur.Admin.Project;
using kerp.Repository.AdminRepository.ProjectRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectRepository repository) : ControllerBase
    {
        private readonly IProjectRepository _repository = repository;

        [HttpGet("ProjectSelectAdmin")]
        public IActionResult ProjectSelectAdmin()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<ProjectSelectAdmin>>
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
        [HttpDelete("ProjectStatus")]
        public IActionResult ProjectStatus([FromBody] ProjectStatus PagesActiveAndDeactive)
        {
            try
            {
                ProjectSelectAdmin? result = _repository.Delete(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<ProjectSelectAdmin>
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
        [HttpPost("ProjectInsert")]
        public IActionResult ProjectInsert([FromBody] ProjectInsert PagesActiveAndDeactive)
        {
            try
            {
                ProjectSelectAdmin? result = _repository.Post(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<ProjectSelectAdmin>
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
        [HttpPut("ProjectUpdate")]
        public IActionResult ProjectUpdate([FromBody] ProjectUpdate PagesActiveAndDeactive)
        {
            try
            {
                ProjectSelectAdmin? result = _repository.Put(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<ProjectSelectAdmin>
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
