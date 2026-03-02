using kerp.Prosedur.MachineIncidentReport;
using kerp.Repository.MachineIncidentReportRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineIncidentReportController(IMachineIncidentReportRepository repository) : ControllerBase
    {
        private readonly IMachineIncidentReportRepository _repository = repository;


        [HttpGet("MachineIncidentReportSelect")]
        public IActionResult MachineIncidentReportSelect(int year, int month)
        {
            try
            {


                return Ok(new CustomerResponseModel<List<MachineIncidentReportSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.MachineIncidentReportSelect(year, month)
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
        [HttpGet("MachineIncidentReportYear")]
        public IActionResult MachineIncidentReportYear()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<MachineIncidentReportYear>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.MachineIncidentReportYear()
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
