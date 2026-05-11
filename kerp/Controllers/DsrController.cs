using kerp.Prosedur.Dsr.Assistant;
using kerp.Prosedur.Dsr.Chat;
using kerp.Prosedur.Dsr.Document;
using kerp.Prosedur.Dsr.Dsrs;
using kerp.Prosedur.Dsr.DSRTaskType;
using kerp.Prosedur.Dsr.LostTime;
using kerp.Prosedur.Dsr.Material;
using kerp.Prosedur.Dsr.Record;
using kerp.Prosedur.Dsr.Task;
using kerp.Prosedur.Dsr.TaskComment;
using kerp.Prosedur.Dsr.WorkOrderType;
using kerp.Prosedur.Dsr.WorkShift;
using kerp.Repository.DsrRepository;
using kerp.Service.DsrService;
using kerp.Service.FileUploadService;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DsrController(IDsrRepository repository, IDsrService service, IFileUploadService fileUploadService) : ControllerBase
    {
        private readonly IDsrRepository _repository = repository;
        private readonly IDsrService _service = service;
        private readonly IFileUploadService _fileUploadService = fileUploadService;

        // ─────────────────────────────────────────────
        // SELECT (REPOSITORY)
        // ─────────────────────────────────────────────
        [HttpGet("DSRTaskTypeSelectAdmin")]
        public IActionResult DSRTaskTypeSelectAdmin()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<DSRTaskTypeSelectAdmin>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.DSRTaskTypeSelectAdmin()
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

        [HttpGet("DSRWorkOrderTypeSelectMulti")]
        public IActionResult DSRWorkOrderTypeSelectMulti()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<DSRWorkOrderTypeSelectMulti>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.DSRWorkOrderTypeSelectMulti()
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

        [HttpGet("DsrWorkShiftSelectMulti")]
        public IActionResult DsrWorkShiftSelectMulti()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<DsrWorkShiftSelectMulti>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.DsrWorkShiftSelectMulti()
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


        [HttpGet("DSRSelect")]
        public IActionResult DSRSelect(int id)
        {
            try
            {
                return Ok(new CustomerResponseModel<DSRSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.DSRSelect(id)
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

        // ─────────────────────────────────────────────
        // TASK TYPE (REPOSITORY)
        // ─────────────────────────────────────────────
        [HttpPost("DSRTaskTypeInsert")]
        public IActionResult DSRTaskTypeInsert([FromBody] DSRTaskTypeInsert request)
        {
            try
            {
                return Ok(new CustomerResponseModel<DSRTaskTypeSelectAdmin>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.DSRTaskTypeInsert(request)
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

        [HttpPut("DSRTaskTypeUpdate")]
        public IActionResult DSRTaskTypeUpdate([FromBody] DSRTaskTypeUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<DSRTaskTypeSelectAdmin>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.DSRTaskTypeUpdate(request)
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

        [HttpDelete("DSRTaskTypeStatus")]
        public IActionResult DSRTaskTypeStatus([FromBody] DSRTaskTypeStatus request)
        {
            try
            {
                return Ok(new CustomerResponseModel<DSRTaskTypeSelectAdmin>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.DSRTaskTypeStatus(request)
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

        // ─────────────────────────────────────────────
        // DSR INSERT (SERVICE)
        // ─────────────────────────────────────────────
        [HttpPost("DSRInsert")]
        public async Task<IActionResult> DSRInsert([FromBody] List<DSRInsert> request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRInsert(request)
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

        // ─────────────────────────────────────────────
        // WORK SHIFT
        // ─────────────────────────────────────────────
        [HttpPut("DSRWorkShiftUpdate")]
        public async Task<IActionResult> DSRWorkShiftUpdate([FromBody] DSRWorkShiftUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRWorkShiftUpdate(request)
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

        // ─────────────────────────────────────────────
        // TASK
        // ─────────────────────────────────────────────
        [HttpPost("DSRTaskInsert")]
        public async Task<IActionResult> DSRTaskInsert([FromBody] DSRTaskInsert request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRTaskInsert(request)
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

        [HttpPut("DSRTaskUpdate")]
        public async Task<IActionResult> DSRTaskUpdate([FromBody] DSRTaskUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRTaskUpdate(request)
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

        [HttpDelete("DSRTaskStatus")]
        public async Task<IActionResult> DSRTaskStatus([FromBody] DSRTaskStatus request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRTaskStatus(request)
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

        // ─────────────────────────────────────────────
        // TASK ASSISTANT
        // ─────────────────────────────────────────────
        [HttpPost("DSRTaskAssistantInsert")]
        public async Task<IActionResult> DSRTaskAssistantInsert([FromBody] DSRTaskAssistantInsert request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRTaskAssistantInsert(request)
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

        [HttpDelete("DSRTaskAssistantStatus")]
        public async Task<IActionResult> DSRTaskAssistantStatus([FromBody] DSRTaskAssistantStatus request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRTaskAssistantStatus(request)
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

        // ─────────────────────────────────────────────
        // TASK COMMENT
        // ─────────────────────────────────────────────
        [HttpPost("DSRTaskCommentInsert")]
        public async Task<IActionResult> DSRTaskCommentInsert([FromBody] DSRTaskCommentInsert request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRTaskCommentInsert(request)
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

        [HttpPut("DSRTaskCommentUpdate")]
        public async Task<IActionResult> DSRTaskCommentUpdate([FromBody] DSRTaskCommentUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRTaskCommentUpdate(request)
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

        [HttpDelete("DSRTaskCommentDelete")]
        public async Task<IActionResult> DSRTaskCommentDelete([FromBody] DSRTaskCommentDelete request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRTaskCommentDelete(request)
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

        // ─────────────────────────────────────────────
        // CHAT
        // ─────────────────────────────────────────────
        [HttpPost("DSRChatInsert")]
        public async Task<IActionResult> DSRChatInsert([FromBody] DSRChatInsert request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRChatInsert(request)
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

        // ─────────────────────────────────────────────
        // DOCUMENT
        // ─────────────────────────────────────────────
        [HttpPost("DSRDocumentInsert")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> DSRDocumentInsert([FromForm] DSRDocumentInsert request)
        {
            try
            {
                (string fileName, string filePath, string contentType, long fileSize) = await _fileUploadService.UploadAsync(
                    request.File,
                    "DSRDocuments",
                    request.DsrId,
                    request.UserId
                );
                request.FileName = fileName;
                request.FilePath = filePath;
                request.ContentType = contentType;
                request.FileSize = fileSize;

                int result = await _service.DSRDocumentInsert(request);

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
                    title = ex.Message
                });
            }
        }


        [HttpPut("DSRDocumentUpdate")]
        public async Task<IActionResult> DSRDocumentUpdate([FromBody] DSRDocumentUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRDocumentUpdate(request)
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

        [HttpDelete("DSRDocumentStatus")]
        public async Task<IActionResult> DSRDocumentStatus([FromBody] DSRDocumentStatus request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRDocumentStatus(request)
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

        // ─────────────────────────────────────────────
        // LOST TIME
        // ─────────────────────────────────────────────
        [HttpPost("DSRLostTimeInsert")]
        public async Task<IActionResult> DSRLostTimeInsert([FromBody] DSRLostTimeInsert request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRLostTimeInsert(request)
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

        [HttpPut("DSRLostTimeUpdate")]
        public async Task<IActionResult> DSRLostTimeUpdate([FromBody] DSRLostTimeUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRLostTimeUpdate(request)
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

        [HttpDelete("DSRLostTimeStatus")]
        public async Task<IActionResult> DSRLostTimeStatus([FromBody] DSRLostTimeStatus request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRLostTimeStatus(request)
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

        // ─────────────────────────────────────────────
        // MATERIAL
        // ─────────────────────────────────────────────
        [HttpGet("DSRMaterialSelectMulti")]
        public IActionResult DSRMaterialSelectMulti()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<DSRMaterialSelectMulti>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.DSRMaterialSelectMulti()
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

        [HttpPost("DSRMaterialInsert")]
        public async Task<IActionResult> DSRMaterialInsert([FromBody] DSRMaterialInsert request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRMaterialInsert(request)
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

        [HttpPut("DSRMaterialUpdate")]
        public async Task<IActionResult> DSRMaterialUpdate([FromBody] DSRMaterialUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRMaterialUpdate(request)
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

        [HttpDelete("DSRMaterialStatus")]
        public async Task<IActionResult> DSRMaterialStatus([FromBody] DSRMaterialStatus request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRMaterialStatus(request)
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

        // ─────────────────────────────────────────────
        // RECORD
        // ─────────────────────────────────────────────
        [HttpPost("DSRRecordInsert")]
        public async Task<IActionResult> DSRRecordInsert([FromBody] DSRRecordInsert request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRRecordInsert(request)
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

        [HttpPut("DSRRecordUpdate")]
        public async Task<IActionResult> DSRRecordUpdate([FromBody] DSRRecordUpdate request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRRecordUpdate(request)
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

        [HttpDelete("DSRRecordStatus")]
        public async Task<IActionResult> DSRRecordStatus([FromBody] DSRRecordStatus request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRRecordStatus(request)
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
        [HttpDelete("DSRWorkOrderStarted")]
        public async Task<IActionResult> DSRWorkOrderStarted([FromBody] DSRControllerLifeCycle request)
        {
            try
            {
                return Ok(new CustomerResponseModel<int>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = await _service.DSRWorkOrderStarted(request)
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