using kerp.Prosedur.Admin.Project;
using kerp.Prosedur.MachineIncident.Document;
using kerp.Prosedur.MachineIncident.Incident;
using kerp.Prosedur.MachineIncident.MachineIncidentAssistant;
using kerp.Prosedur.MachineIncident.MachineIncidentDocument;
using kerp.Prosedur.MachineIncident.MachineIncidentTask;
using kerp.Prosedur.MachineIncident.MachineIncidentWorkShift;
using kerp.Prosedur.MachineIncident.Material;
using kerp.Prosedur.MachineIncident.SelectModels;
using kerp.Prosedur.MachineIncident.Task;
using kerp.Prosedur.MachineIncident.Type;
using kerp.Prosedur.MachineIncident.WorkOrderType;
using kerp.Repository.MachineIncidentRepository;
using kerp.Service.IncidentService;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineIncidentController(IMachineIncidentRepository repository, IIncidentService incidentService) : ControllerBase
    {
        private readonly IMachineIncidentRepository _repository = repository;
        private readonly IIncidentService _incidentService = incidentService;
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


        [HttpGet("MachineIncidentSelect")]
        public IActionResult MachineIncidentSelect(int Id)
        {
            try
            {


                return Ok(new CustomerResponseModel<MachineIncidentSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.MachineIncidentSelect(Id)
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
        public async Task<IActionResult> MachineIncidentInsertAsync([FromBody] List<MachineIncidentInsert> MachineIncidentInsert)
        {
            try
            {
                List<MachineIncidentSelectForBackEnd> result =
    await _incidentService.InsertAsync(MachineIncidentInsert);

                return result.Count > 1
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

        [HttpPut("MachineIncidentTitleUpdate")]
        public async Task<IActionResult> MachineIncidentTitleUpdate(
    [FromBody] MachineIncidentTitleUpdate model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentTitleUpdateAsync(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }



        [HttpPut("MachineIncidentProjectUpdate")]
        public async Task<IActionResult> MachineIncidentProjectUpdate(
 [FromBody] MachineIncidentProjectUpdate model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentProjectUpdate(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }
        [HttpPut("MachineIncidentAssetUpdate")]
        public async Task<IActionResult> MachineIncidentAssetUpdate(
 [FromBody] MachineIncidentAssetUpdate model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentAssetUpdate(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        [HttpPut("MachineIncidentCrashTypeUpdate")]
        public async Task<IActionResult> MachineIncidentCrashTypeUpdate(
 [FromBody] MachineIncidentCrashTypeUpdate model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentCrashTypeUpdate(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        [HttpPut("MachineIncidentWorkOrderTypeUpdate")]
        public async Task<IActionResult> MachineIncidentWorkOrderTypeUpdate(
 [FromBody] MachineIncidentWorkOrderTypeUpdate model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentWorkOrderTypeUpdate(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        [HttpPut("MachineIncidentWorkShiftUpdate")]
        public async Task<IActionResult> MachineIncidentWorkShiftUpdate(
 [FromBody] MachineIncidentWorkShiftUpdate model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentWorkShiftUpdate(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        [HttpPut("MachineIncidentAccept")]
        public async Task<IActionResult> MachineIncidentAccept(
 [FromBody] MachineIncidentAccept model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentAccept(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }     
        

        
        [HttpPut("MachineIncidentAssistantInsert")]
        public async Task<IActionResult> MachineIncidentAssistantInsert(
 [FromBody] List<MachineIncidentAssistantInsert>  model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentAssistantInsert(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

                [HttpPut("MachineIncidentStart")]
        public async Task<IActionResult> MachineIncidentStart(
 [FromBody] List<MachineIncidentAssistantInsert>  model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentStart(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }
     
        
        
        
        
        
        
        [HttpPost("MachineIncidentDocumentInsert")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> MachineIncidentDocumentInsert(
            [FromForm] MachineIncidentDocumentInsert model)
        {
            try
            {
                if (model.File == null || model.File.Length == 0)
                    return BadRequest("File boşdur");

                // 🔹 Extension (pdf, png, xls və s.)
                string extension = Path.GetExtension(model.File.FileName)
                                        .Replace(".", "")
                                        .ToLowerInvariant();

                // 🔹 Root folder (wwwroot YOXDURSA – avtomatik yaradılacaq)
                string uploadRoot = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "MachineIncidentDocuments",
                    model.MachineIncidentId.ToString(),
                    extension
                );

                Directory.CreateDirectory(uploadRoot); // varsa toxunmur

                // 🔹 UNIQ FileName
                string uniqueFileName =
                    $"{model.MachineIncidentId}_{model.UserId}_{DateTime.UtcNow:yyyyMMddHHmmssfff}_{Guid.NewGuid()}.{extension}";

                string physicalPath = Path.Combine(uploadRoot, uniqueFileName);

                // 🔹 Fiziki save
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    await model.File.CopyToAsync(stream);
                }

                // 🔹 Server tərəfindən doldurulan sahələr
                model.FileName = uniqueFileName;
                model.FilePath =
                    $"/MachineIncidentDocuments/{model.MachineIncidentId}/{extension}/{uniqueFileName}";
                model.ContentType = model.File.ContentType;
                model.FileSize = model.File.Length;

                int result = await _incidentService.MachineIncidentDocumentInsert(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }








        [HttpDelete("MachineIncidentAssistantStatus")]

        public async Task<IActionResult> MachineIncidentAssistantStatus(
 [FromBody] MachineIncidentAssistantStatus model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentAssistantStatus(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }      
        
        [HttpDelete("MachineIncidentDocumentStatus")]

        public async Task<IActionResult> MachineIncidentDocumentStatus(
 [FromBody] MachineIncidentDocumentStatus model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentDocumentStatus(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }






        [HttpGet("MachineIncidentAssetSelectMulti")]
        public IActionResult MachineIncidentAssetSelectMulti(int Id)
        {
            try
            {


                return Ok(new CustomerResponseModel<List<MachineIncidentAssetSelectMulti>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.MachineIncidentAssetSelectMulti(Id)
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
                [HttpGet("MachineIncidentMaterialSelectMulti")]
        public IActionResult MachineIncidentMaterialSelectMulti()
        {
            try
            {


                return Ok(new CustomerResponseModel<List<MachineIncidentMaterialSelectMulti>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.MachineIncidentMaterialSelectMulti()
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

        
                    [HttpPost("MachineIncidentTaskInsert")]

        public async Task<IActionResult> MachineIncidentTaskInsert(
 [FromBody] MachineIncidentTaskInsert model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentTaskInsert(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        [HttpPut("MachineIncidentTaskTitleCrashTypeUpdate")]
        public async Task<IActionResult> MachineIncidentTaskTitleCrashTypeUpdate(
[FromBody] MachineIncidentTaskTitleCrashTypeUpdate model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentTaskTitleCrashTypeUpdate(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }


        [HttpDelete("MachineIncidentTaskStatus")]

        public async Task<IActionResult> MachineIncidentTaskStatus(
 [FromBody] MachineIncidentTaskStatus model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentTaskStatus(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }


        [HttpPost("MachineIncidentMaterialInsert")]

        public async Task<IActionResult> MachineIncidentMaterialInsert(
[FromBody] MachineIncidentMaterialInsert model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentMaterialInsert(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }

        [HttpDelete("MachineIncidentMaterialStatus")]

        public async Task<IActionResult> MachineIncidentMaterialStatus(
[FromBody] MachineIncidentMaterialStatus model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentMaterialStatus(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }



        [HttpPut("MachineIncidentResolved")]
        public async Task<IActionResult> MachineIncidentResolved(
[FromBody] MachineIncidentResolved model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentResolved(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }
        [HttpPut("MachineIncidentAwaitingApproval")]
        public async Task<IActionResult> MachineIncidentAwaitingApproval(
[FromBody] MachineIncidentAwaitingApproval model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentAwaitingApproval(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }
        [HttpPut("MachineIncidentClosed")]
        public async Task<IActionResult> MachineIncidentClosed(
[FromBody] MachineIncidentClosed model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentClosed(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }
        [HttpPut("MachineIncidentCanceled")]
        public async Task<IActionResult> MachineIncidentCanceled(
[FromBody] MachineIncidentCanceled model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentCanceled(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }       
        [HttpPut("MachineIncidentReject")]
        public async Task<IActionResult> MachineIncidentReject(
[FromBody] MachineIncidentReject model)
        {
            try
            {
                int result = await _incidentService.MachineIncidentReject(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        AccessToken = null,
                        Data = null
                    })
                    : (IActionResult)Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        AccessToken = null,
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }


    }
}
