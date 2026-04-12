using kerp.Prosedur.Pm.PMChecklistTemplate;
using kerp.Prosedur.Pm.PmGroup;
using kerp.Prosedur.Pm.PMSchedule;
using kerp.Prosedur.Pm.PMScheduleAssignees;
using kerp.Prosedur.Pm.PMScheduleStructure;
using kerp.Prosedur.Pm.PMScheduleWorkOrderType;
using kerp.Prosedur.PM.PMScheduleAsset;
using kerp.Repository.PMRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PMController(IPMRepository repository) : ControllerBase
    {
        private readonly IPMRepository _repository = repository;

        #region Group
        [HttpGet("PMChecklistGroupSelect")]
        public IActionResult PMChecklistGroupSelect()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PMChecklistGroupSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetGroup()
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

        [HttpPost("PMChecklistGroupInsert")]
        public IActionResult PMChecklistGroupInsert([FromBody] PMChecklistGroupInsert request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMChecklistGroupSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PostGroup(request)
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

        [HttpPut("PMChecklistGroupUpdate")]
        public IActionResult PMChecklistGroupUpdate([FromBody] PMChecklistGroupUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMChecklistGroupSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PutGroup(request)
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

        [HttpDelete("PMChecklistGroupStatusUpdate")]
        public IActionResult PMChecklistGroupStatusUpdate([FromBody] PMChecklistGroupStatusUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMChecklistGroupSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.StatusUpdateGroup(request)
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
        #endregion

        #region Template
        [HttpGet("PMChecklistTemplateSelect/{groupId}")]
        public IActionResult PMChecklistTemplateSelect(int groupId)
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PMChecklistTemplateSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetTemplate(groupId)
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

        [HttpPost("PMChecklistTemplateInsert")]
        public IActionResult PMChecklistTemplateInsert([FromBody] PMChecklistTemplateInsert request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMChecklistTemplateSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PostTemplate(request)
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

        [HttpPut("PMChecklistTemplateUpdate")]
        public IActionResult PMChecklistTemplateUpdate([FromBody] PMChecklistTemplateUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMChecklistTemplateSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PutTemplate(request)
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

        [HttpDelete("PMChecklistTemplateStatusUpdate")]
        public IActionResult PMChecklistTemplateStatusUpdate([FromBody] PMChecklistTemplateStatusUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMChecklistTemplateSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.StatusUpdateTemplate(request)
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

        [HttpPut("PMChecklistTemplateReorder")]
        public IActionResult PMChecklistTemplateReorder([FromBody] PMChecklistTemplateReorderRequest request)
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PMChecklistTemplateSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.ReorderTemplate(request)
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
        #endregion

        [HttpPut("PMScheduleStructureUpdate")]
        public IActionResult PMScheduleStructureUpdate([FromBody] PMScheduleStructureUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMScheduleStructureSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.UpdateScheduleStructure(request)
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

        [HttpPut("PMScheduleWorkOrderTypeUpdate")]
        public IActionResult PMScheduleWorkOrderTypeUpdate([FromBody] PMScheduleWorkOrderTypeUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMScheduleWorkOrderTypeSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.UpdateScheduleWorkOrderType(request)
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

        [HttpPost("PMScheduleAssigneesInsert")]
        public IActionResult PMScheduleAssigneesInsert([FromBody] List<PMScheduleAssigneesInsert> request)
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PMScheduleAssigneesSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.InsertScheduleAssignees(request)
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

        [HttpPut("PMScheduleAssigneesRoleUpdate")]
        public IActionResult PMScheduleAssigneesRoleUpdate([FromBody] PMScheduleAssigneesRoleUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMScheduleAssigneesSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.RoleUpdateScheduleAssignee(request)
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

        [HttpDelete("PMScheduleAssigneesStatusUpdate")]
        public IActionResult PMScheduleAssigneesStatusUpdate([FromBody] PMScheduleAssigneesStatusUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMScheduleAssigneesSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.StatusUpdateScheduleAssignee(request)
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

        #region Schedule

        [HttpGet("PMScheduleSelect/{structureId}")]
        public IActionResult PMScheduleSelect(string structureId)
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PMScheduleSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetSchedules(structureId)
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
        [HttpGet("GetPMScheduleWorkOrderTypeSelectMulti")]
        public IActionResult GetPMScheduleWorkOrderTypeSelectMulti()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PMScheduleWorkOrderTypeSelectMulti>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetPMScheduleWorkOrderTypeSelectMulti()
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

        [HttpPost("PMScheduleInsert")]
        public IActionResult PMScheduleInsert([FromBody] PMScheduleInsert request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMScheduleSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.InsertSchedule(request)
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

        [HttpPut("PMScheduleUpdate")]
        public IActionResult PMScheduleUpdate([FromBody] PMScheduleUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMScheduleSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.UpdateSchedule(request)
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

        [HttpDelete("PMScheduleStatusUpdate")]
        public IActionResult PMScheduleStatusUpdate([FromBody] PMScheduleStatusUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMScheduleSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.StatusUpdateSchedule(request)
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

        #endregion
        #region PMScheduleAsset

        [HttpGet("PMScheduleAssetSelect/{pmScheduleId}")]
        public IActionResult PMScheduleAssetSelect(int pmScheduleId)
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PMScheduleAssetSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetScheduleAssets(pmScheduleId)
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

        [HttpPost("PMScheduleAssetInsert")]
        public IActionResult PMScheduleAssetInsert([FromBody] PMScheduleAssetInsert request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMScheduleAssetSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.InsertScheduleAsset(request)
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
        [HttpPut("PMScheduleAssetUpdate")]
        public IActionResult PMScheduleAssetUpdate([FromBody] PMScheduleAssetUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMScheduleAssetSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.UpdateScheduleAsset(request)
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

        [HttpDelete("PMScheduleAssetStatusUpdate")]
        public IActionResult PMScheduleAssetStatusUpdate([FromBody] PMScheduleAssetStatus request)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMScheduleAssetSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.StatusUpdateScheduleAsset(request)
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

        #endregion
    }
}