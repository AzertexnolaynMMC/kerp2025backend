using kerp.Prosedur.Admin.Project;
using kerp.Prosedur.MachineIncident.Incident;
using kerp.Prosedur.MachineIncident.SelectModels;
using kerp.Repository.MachineIncidentRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineIncidentController(IMachineIncidentRepository repository) : ControllerBase
    {
        private readonly IMachineIncidentRepository _repository = repository;
        [HttpGet("MachineIncidentCrashTypeSelectMulti")]
        public IActionResult MachineIncidentCrashTypeSelectMulti()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<MachineIncidentCrashTypeSelectMulti>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.MachineIncidentCrashTypeSelectMulti()
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


        [HttpGet("MachineIncidentProjectSelectMulti")]
        public IActionResult MachineIncidentProjectSelectMulti()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<MachineIncidentProjectSelectMulti>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.MachineIncidentProjectSelectMulti()
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


        [HttpGet("MachineIncidentWorkOrderTypeSelectMulti")]
        public IActionResult MachineIncidentWorkOrderTypeSelectMulti()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<MachineIncidentWorkOrderTypeSelectMulti>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.MachineIncidentWorkOrderTypeSelectMulti()
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



        [HttpGet("MachineIncidentWorkShiftSelectMulti")]
        public IActionResult MachineIncidentWorkShiftSelectMulti()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<MachineIncidentWorkShiftSelectMulti>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.MachineIncidentWorkShiftSelectMulti()
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




        [HttpPost("Post")]
        public IActionResult MachineIncidentInsert([FromBody] List<MachineIncidentInsert> MachineIncidentInsert)
        {
            try
            {
                int? result = _repository.Post(MachineIncidentInsert);

                return result == 1
                    ? (IActionResult)Ok(new CustomerResponseModel<ProjectSelectAdmin>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 500,
                        title = "Internal server error: ",
                        AccessToken = null,
                        Data = null
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
