using kerp.Prosedur.PreCheck.Document;
using kerp.Prosedur.PreCheck.Event;
using kerp.Prosedur.PreCheck.Group;
using kerp.Prosedur.PreCheck.Incident;
using kerp.Prosedur.PreCheck.Pre;
using kerp.Prosedur.PreCheck.Record;
using kerp.Prosedur.PreCheck.ResultType;
using kerp.Prosedur.PreCheck.Template;
using kerp.Prosedur.PreCheck.WorkOrder;
using kerp.Prosedur.PreCheck.WorkShift;
using kerp.Repository.PreCheckRepository;
using kerp.Service.FileUploadService;
using kerp.Service.PreCheckService;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreCheckController(
        IPreCheckRepository repository,
        IPreCheckService preCheckService, IFileUploadService fileUploadService) : ControllerBase
    {
        private readonly IPreCheckRepository _repository = repository;
        private readonly IPreCheckService _preCheckService = preCheckService;
        private readonly IFileUploadService _fileUploadService = fileUploadService;

        // ─── POST ─────────────────────────────────────────────────────────────

        [HttpPost("PreCheckInsert")]
        public async Task<IActionResult> PreCheckInsert([FromBody] List<PreCheckInsert> model)
        {
            try
            {
                int result = await _preCheckService.PreCheckInsert(model);

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

        // ─── GET ──────────────────────────────────────────────────────────────


        [HttpGet("PreCheckGroupSelectForInsert")]
        public IActionResult PreCheckGroupSelectForInsert()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckGroupSelectForInsert>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PreCheckGroupSelectForInsert()
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

        [HttpGet("PreCheckResultTypeSelectForInsert")]
        public IActionResult PreCheckResultTypeSelectForInsert()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckResultTypeSelectForInsert>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PreCheckResultTypeSelectForInsert()
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

        [HttpGet("PreCheckTemplateSelectForInsert")]
        public IActionResult PreCheckTemplateSelectForInsert()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckTemplateSelectForInsert>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PreCheckTemplateSelectForInsert()
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

        [HttpGet("PreCheckWorkOrderTypeLangSelectForInsert")]
        public IActionResult PreCheckWorkOrderTypeLangSelectForInsert()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckWorkOrderTypeLangSelectForInsert>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PreCheckWorkOrderTypeLangSelectForInsert()
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

        [HttpGet("PreCheckWorkShiftSelectForInsert")]
        public IActionResult PreCheckWorkShiftSelectForInsert()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckWorkShiftSelectForInsert>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PreCheckWorkShiftSelectForInsert()
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



        [HttpGet("PreCheckSelect")]
        public IActionResult PreCheckSelect(int Id)
        {
            try
            {
                return Ok(new CustomerResponseModel<PreCheckSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PreCheckSelect(Id)
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

        [HttpPost("PreCheckDocumentInsert")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> PreCheckDocumentInsert(
            [FromForm] PreCheckDocumentInsert model)
        {
            try
            {
                (string fileName, string filePath, string contentType, long fileSize) = await _fileUploadService.UploadAsync(
                    model.File,
                    "PreCheckDocuments",
                    model.PreCheckId ?? 0,
                    model.UserId ?? 0
                );

                model.FileName = fileName;
                model.FilePath = filePath;
                model.ContentType = contentType;
                model.FileSize = fileSize;

                int result = await _preCheckService.PreCheckDocumentInsert(model);

                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = result == 1 ? 0 : 404,
                    title = result == 1 ? "Uğurlu əməliyyat" : "Məlumat tapılmadı"
                });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message
                });
            }
        }






        [HttpPost("PreCheckDocumentUpdate")]
        public async Task<IActionResult> PreCheckDocumentUpdate([FromBody] PreCheckDocumentUpdate model)
        {
            try
            {
                int result = await _preCheckService.PreCheckDocumentUpdate(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("PreCheckDocumentStatus")]
        public async Task<IActionResult> PreCheckDocumentStatus([FromBody] PreCheckDocumentStatus model)
        {
            try
            {
                int result = await _preCheckService.PreCheckDocumentStatus(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    Data = null
                });
            }
        }
        [HttpPost("PreCheckRecordInsert")]
        public async Task<IActionResult> PreCheckRecordInsert([FromBody] PreCheckRecordInsert model)
        {
            try
            {
                int result = await _preCheckService.PreCheckRecordInsert(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("PreCheckRecordUpdate")]
        public async Task<IActionResult> PreCheckRecordUpdate([FromBody] PreCheckRecordUpdate model)
        {
            try
            {
                int result = await _preCheckService.PreCheckRecordUpdate(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("PreCheckRecordStatus")]
        public async Task<IActionResult> PreCheckRecordStatus([FromBody] PreCheckRecordStatus model)
        {
            try
            {
                int result = await _preCheckService.PreCheckRecordStatus(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Uğurlu əməliyyat",
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    Data = null
                });
            }
        }

        // =========================
        // LIFECYCLE (KANBAN)
        // =========================

        [HttpPost("Accepted")]
        public async Task<IActionResult> Accepted([FromBody] PreCheckControllerLifeCircle model)
        {
            try
            {
                int result = await _preCheckService.Accepted(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Qəbul edildi",
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("InReview")]
        public async Task<IActionResult> InReview([FromBody] PreCheckControllerLifeCircle model)
        {
            try
            {
                int result = await _preCheckService.InReview(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Yoxlamaya göndərildi",
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("Approved")]
        public async Task<IActionResult> Approved([FromBody] PreCheckControllerLifeCircle model)
        {
            try
            {
                int result = await _preCheckService.Approved(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Təsdiq edildi",
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("Closed")]
        public async Task<IActionResult> Closed([FromBody] PreCheckControllerLifeCircle model)
        {
            try
            {
                int result = await _preCheckService.Closed(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Bağlandı",
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    Data = null
                });
            }
        }


        [HttpPost("ElectricalController")]
        public async Task<IActionResult> ElectricalController([FromBody] PreCheckEventInsert model)
        {
            try
            {
                int result = await _preCheckService.ElectricalController(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Elektrik nəzarəti tamamlandı",
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("MechanicalController")]
        public async Task<IActionResult> MechanicalController([FromBody] PreCheckEventInsert model)
        {
            try
            {
                int result = await _preCheckService.MechanicalController(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "Mexaniki nəzarət tamamlandı",
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    Data = null
                });
            }
        }
        [HttpGet("PreCheckCrashTypeForIncidentSelect")]
        public IActionResult PreCheckCrashTypeForIncidentSelect()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckCrashTypeForIncidentSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PreCheckCrashTypeForIncidentSelect()
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

        [HttpGet("PreCheckProjectForIncidentSelect")]
        public IActionResult PreCheckProjectForIncidentSelect()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckProjectForIncidentSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PreCheckProjectForIncidentSelect()
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

        [HttpGet("PreCheckWorkOrderTypeForIncidentSelect")]
        public IActionResult PreCheckWorkOrderTypeForIncidentSelect()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckWorkOrderTypeForIncidentSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PreCheckWorkOrderTypeForIncidentSelect()
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

        [HttpGet("PreCheckWorkShiftForIncidentSelect")]
        public IActionResult PreCheckWorkShiftForIncidentSelect()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckWorkShiftForIncidentSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PreCheckWorkShiftForIncidentSelect()
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
        // =========================
        // CONTROLLER içinə əlavə et
        // (son GET-lərdən sonra əlavə edə bilərsən)
        // =========================

        [HttpGet("PreCheckUserSelect")]
        public IActionResult PreCheckUserSelect(int Id)
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PreCheckUserSelect>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PreCheckUserSelect(Id)
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

        [HttpPost("PreCheckCreateCM")]
        public async Task<IActionResult> PreCheckCreateCM([FromBody] PreCheckCreateCM model)
        {
            try
            {
                int result = await _preCheckService.PreCheckCreateCM(model);

                return result == 1
                    ? Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 0,
                        title = "CM uğurla yaradıldı",
                        Data = null
                    })
                    : Ok(new CustomerResponseModel<object>
                    {
                        StatusCode = 404,
                        title = "Məlumat tapılmadı",
                        Data = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 500,
                    title = "Internal server error: " + ex.Message,
                    Data = null
                });
            }
        }

    }
}