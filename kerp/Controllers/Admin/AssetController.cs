using kerp.Prosedur.Admin.Asset;
using kerp.Repository.AdminRepository.AssetRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController(IAssetRepository repository) : ControllerBase
    {
        private readonly IAssetRepository _repository = repository;
        [HttpGet("AssetSelectAdmin")]
        public IActionResult AssetSelectAdmin()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<AssetSelectAdmin>>
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
        [HttpGet("AssetSelectByAssetTitle")]
        public IActionResult AssetSelectByAssetTitle()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<AssetSelectByAssetTitle>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetAssetSelectByAssetTitle()
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




        [HttpGet("AssetSelectByAssetType")]
        public IActionResult AssetSelectByAssetType()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<AssetSelectByAssetType>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetAssetSelectByAssetType()
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
        [HttpGet("AssetSelectByStructure")]
        public IActionResult AssetSelectByStructure()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<AssetSelectByStructure>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetAssetSelectByStructure()
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







        [HttpDelete("AssetStatus")]
        public IActionResult AssetStatus([FromBody] AssetStatus PagesActiveAndDeactive)
        {
            try
            {
                AssetSelectAdmin? result = _repository.Delete(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<AssetSelectAdmin>
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



        [HttpPost("AssetInsert")]
        public IActionResult AssetInsert([FromBody] AssetInsert PagesActiveAndDeactive)
        {
            try
            {
                AssetSelectAdmin? result = _repository.Post(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<AssetSelectAdmin>
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


        [HttpPut("AssetUpdate")]
        public IActionResult AssetUpdate([FromBody] AssetUpdate PagesActiveAndDeactive)
        {
            try
            {
                AssetSelectAdmin? result = _repository.Put(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<AssetSelectAdmin>
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
