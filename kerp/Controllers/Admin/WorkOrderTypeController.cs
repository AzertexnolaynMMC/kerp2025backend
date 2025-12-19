using kerp.Prosedur.Admin.WorkOrderType;
using kerp.Repository.AdminRepository.WorkOrderTypeRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderTypeController(IWorkOrderTypeRepository repository) : ControllerBase
    {
        private readonly IWorkOrderTypeRepository _repository = repository;


        [HttpGet("WorkOrderTypeSelectAdmin")]
        public IActionResult WorkOrderTypeSelectAdmin()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<WorkOrderTypeSelectAdmin>>
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



        [HttpDelete("WorkOrderTypeStatus")]
        public IActionResult SectionStatus([FromBody] WorkOrderTypeStatus PagesActiveAndDeactive)
        {
            try
            {
                WorkOrderTypeSelectAdmin? result = _repository.Delete(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<WorkOrderTypeSelectAdmin>
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



        [HttpPost("WorkOrderTypeInsert")]
        public IActionResult SectionInsert([FromBody] WorkOrderTypeInsert PagesActiveAndDeactive)
        {
            try
            {
                WorkOrderTypeSelectAdmin? result = _repository.Post(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<WorkOrderTypeSelectAdmin>
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


        [HttpPut("WorkOrderTypeUpdate")]
        public IActionResult SectionUpdate([FromBody] WorkOrderTypeUpdate PagesActiveAndDeactive)
        {
            try
            {
                WorkOrderTypeSelectAdmin? result = _repository.Put(PagesActiveAndDeactive);



                return Ok(new CustomerResponseModel<WorkOrderTypeSelectAdmin>
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
