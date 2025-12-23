using kerp.Prosedur.Admin.AssetTitle;
using kerp.Repository.AdminRepository.AssetTitleRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetTitleController(IAssetTitleRepository repository) : ControllerBase
    {
        private readonly IAssetTitleRepository _repository = repository;

        [HttpGet("AssetTitleSelectAdmin")]
        public IActionResult AssetTitleSelectAdmin()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<AssetTitleSelectAdmin>>
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
        [HttpDelete("AssetTitleStatus")]
        public IActionResult ProjectStatus([FromBody] AssetTitleStatus PagesActiveAndDeactive)
        {
            try
            {
                AssetTitleSelectAdmin? result = _repository.Delete(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<AssetTitleSelectAdmin>
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
        [HttpPost("AssetTitleInsert")]
        public IActionResult ProjectInsert([FromBody] AssetTitleInsert PagesActiveAndDeactive)
        {
            try
            {
                AssetTitleSelectAdmin? result = _repository.Post(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<AssetTitleSelectAdmin>
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
        [HttpPut("AssetTitleUpdate")]
        public IActionResult ProjectUpdate([FromBody] AssetTitleUpdate PagesActiveAndDeactive)
        {
            try
            {
                AssetTitleSelectAdmin? result = _repository.Put(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<AssetTitleSelectAdmin>
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
