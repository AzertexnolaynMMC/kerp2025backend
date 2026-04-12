using kerp.Prosedur.Admin.PreCheckGroup;
using kerp.Prosedur.Admin.PreCheckResultType;
using kerp.Prosedur.Admin.PreCheckTemplate;
using kerp.Repository.AdminRepository.PreCheckGroupTemplateAndTypeRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreCheckGroupTemplateAndTypeController(IPreCheckGroupTemplateAndTypeRepository repository) : ControllerBase
    {
        private readonly IPreCheckGroupTemplateAndTypeRepository _repository = repository;

        #region PreCheckGroup
        [HttpGet("PreCheckGroups")]
        public IActionResult GetPreCheckGroups()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckGroupSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetPreCheckGroups()
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

        [HttpDelete("PreCheckGroupStatus")]
        public IActionResult DeletePreCheckGroup([FromBody] PreCheckGroupStatusUpdate model)
        {
            try
            {
                PreCheckGroupSelect? result = _repository.DeletePreCheckGroup(model);
                return Ok(new CustomerResponseModel<PreCheckGroupSelect>
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

        [HttpPost("PreCheckGroupInsert")]
        public IActionResult PostPreCheckGroup([FromBody] PreCheckGroupInsert model)
        {
            try
            {
                PreCheckGroupSelect? result = _repository.PostPreCheckGroup(model);
                return Ok(new CustomerResponseModel<PreCheckGroupSelect>
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

        [HttpPut("PreCheckGroupUpdate")]
        public IActionResult PutPreCheckGroup([FromBody] PreCheckGroupUpdate model)
        {
            try
            {
                PreCheckGroupSelect? result = _repository.PutPreCheckGroup(model);
                return Ok(new CustomerResponseModel<PreCheckGroupSelect>
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
        #endregion

        #region PreCheckTemplate
        [HttpGet("PreCheckTemplates")]
        public IActionResult GetPreCheckTemplates()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckTemplateSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetPreCheckTemplates()
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

        [HttpDelete("PreCheckTemplateStatus")]
        public IActionResult DeletePreCheckTemplate([FromBody] PreCheckTemplateStatusUpdate model)
        {
            try
            {
                PreCheckTemplateSelect? result = _repository.DeletePreCheckTemplate(model);
                return Ok(new CustomerResponseModel<PreCheckTemplateSelect>
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

        [HttpPost("PreCheckTemplateInsert")]
        public IActionResult PostPreCheckTemplate([FromBody] PreCheckTemplateInsert model)
        {
            try
            {
                PreCheckTemplateSelect? result = _repository.PostPreCheckTemplate(model);
                return Ok(new CustomerResponseModel<PreCheckTemplateSelect>
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

        [HttpPut("PreCheckTemplateUpdate")]
        public IActionResult PutPreCheckTemplate([FromBody] PreCheckTemplateUpdate model)
        {
            try
            {
                PreCheckTemplateSelect? result = _repository.PutPreCheckTemplate(model);
                return Ok(new CustomerResponseModel<PreCheckTemplateSelect>
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

        [HttpGet("PreCheckTemplateGroups")]
        public IActionResult GetPreCheckTemplateGroups()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckTemplateGroupSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetPreCheckTemplateGroups()
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

        #region PreCheckResultType
        [HttpGet("PreCheckResultTypes")]
        public IActionResult GetPreCheckResultTypes()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckResultTypeSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetPreCheckResultTypes()
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

        [HttpDelete("PreCheckResultTypeStatus")]
        public IActionResult DeletePreCheckResultType([FromBody] PreCheckResultTypeStatusUpdate model)
        {
            try
            {
                PreCheckResultTypeSelect? result = _repository.DeletePreCheckResultType(model);
                return Ok(new CustomerResponseModel<PreCheckResultTypeSelect>
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

        [HttpPost("PreCheckResultTypeInsert")]
        public IActionResult PostPreCheckResultType([FromBody] PreCheckResultTypeInsert model)
        {
            try
            {
                PreCheckResultTypeSelect? result = _repository.PostPreCheckResultType(model);
                return Ok(new CustomerResponseModel<PreCheckResultTypeSelect>
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

        [HttpPut("PreCheckResultTypeUpdate")]
        public IActionResult PutPreCheckResultType([FromBody] PreCheckResultTypeUpdate model)
        {
            try
            {
                PreCheckResultTypeSelect? result = _repository.PutPreCheckResultType(model);
                return Ok(new CustomerResponseModel<PreCheckResultTypeSelect>
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
        #endregion
    }
}