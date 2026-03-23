using kerp.Prosedur.PMOrders;
using kerp.Repository.PMOrdersRepository;
using kerp.Service.PmOrderService;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PMOrdersController(IPMOrdersRepository repository, IPmOrderService service) : ControllerBase
    {
        private readonly IPMOrdersRepository _repository = repository;
        private readonly IPmOrderService _service = service;


        [HttpGet("PMOrdersSelect/{id}")]
        public IActionResult PMOrdersSelect(int id)
        {
            try
            {
                return Ok(new CustomerResponseModel<PMOrdersSelect>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.GetPMOrder(id)
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



        [HttpPut("PMOrderControllerLifeCrcyle")]
        public async Task<IActionResult> PMOrderControllerLifeCrcyle([FromBody] PMOrderControllerLifeCrcyle model)
        {
            try
            {
                int result = await _service.PMOrderControllerLifeCrcyle(model);

                return Ok(new CustomerResponseModel<int>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }
        [HttpPut("PMOrderSend")]
        public async Task<IActionResult> PMOrderSend([FromBody] PMOrderControllerLifeCrcyle model)
        {
            try
            {
                int result = await _service.PMOrderSend(model);

                return Ok(new CustomerResponseModel<int>
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
                    title = "Internal server error: " + ex.Message,
                    AccessToken = null,
                    Data = null
                });
            }
        }





        [HttpPut("PMChecklistExecutionUpdate")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> PMChecklistExecutionUpdate(
            [FromForm] List<PMChecklistExecutionUpdate> model)
        {
            try
            {
                foreach (PMChecklistExecutionUpdate item in model)
                {
                    if (item.ResponseType == 4 && item.File != null && item.File.Length > 0)
                    {
                        string extension = Path.GetExtension(item.File.FileName)
                                                .Replace(".", "")
                                                .ToLowerInvariant();

                        string uploadRoot = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot",
                            "PMChecklistExecution",
                            item.Id.ToString(),
                            extension
                        );

                        _ = Directory.CreateDirectory(uploadRoot);

                        string uniqueFileName =
                            $"{item.Id}_{item.FilledBy}_{DateTime.UtcNow:yyyyMMddHHmmssfff}_{Guid.NewGuid()}.{extension}";

                        string physicalPath = Path.Combine(uploadRoot, uniqueFileName);

                        using (FileStream stream = new(physicalPath, FileMode.Create))
                        {
                            await item.File.CopyToAsync(stream);
                        }

                        item.PhotoPath = $"/PMChecklistExecution/{item.Id}/{extension}/{uniqueFileName}";
                    }
                }

                int result = await _service.PMChecklistExecutionUpdate(model);

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




        [HttpPost("PMRecordInsert")]
        public async Task<IActionResult> PMRecordInsert([FromBody] PMRecordInsert model)
        {
            try
            {
                int result = await _service.PMRecordInsert(model);

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
                        title = "Məlumat əlavə olunmadı",
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

        [HttpPut("PMRecordStatus")]
        public async Task<IActionResult> PMRecordStatus([FromBody] PMRecordStatus model)
        {
            try
            {
                int result = await _service.PMRecordStatus(model);

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

        [HttpPut("PMRecordUpdate")]
        public async Task<IActionResult> PMRecordUpdate([FromBody] PMRecordUpdate model)
        {
            try
            {
                int result = await _service.PMRecordUpdate(model);

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
                        title = "Məlumat yenilənmədi",
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

        [HttpPost("PMDocumentsInsert")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> PMDocumentsInsert([FromForm] PMDocumentsInsert model)
        {
            try
            {
                if (model.File == null || model.File.Length == 0)
                {
                    return BadRequest("File boşdur");
                }

                string extension = Path.GetExtension(model.File.FileName)
                                        .Replace(".", "")
                                        .ToLowerInvariant();

                string uploadRoot = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "PMDocuments",
                    model.PmOrderId.ToString(),
                    extension
                );

                _ = Directory.CreateDirectory(uploadRoot);

                string uniqueFileName =
                    $"{model.PmOrderId}_{model.UserId}_{DateTime.UtcNow:yyyyMMddHHmmssfff}_{Guid.NewGuid()}.{extension}";

                string physicalPath = Path.Combine(uploadRoot, uniqueFileName);

                using (FileStream stream = new(physicalPath, FileMode.Create))
                {
                    await model.File.CopyToAsync(stream);
                }

                model.FileName = uniqueFileName;
                model.FilePath = $"/PMDocuments/{model.PmOrderId}/{extension}/{uniqueFileName}";
                model.ContentType = model.File.ContentType;
                model.FileSize = model.File.Length;

                int result = await _service.PMDocumentsInsert(model);

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
                        title = "Məlumat əlavə olunmadı",
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

        // 🔹 Status dəyişmə (delete/disable)
        [HttpPut("PMDocumentsStatus")]
        public async Task<IActionResult> PMDocumentsStatus([FromBody] PMDocumentsStatus model)
        {
            try
            {
                int result = await _service.PMDocumentsStatus(model);

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

        // 🔹 FileNameTitle update
        [HttpPut("PMDocumentsUpdate")]
        public async Task<IActionResult> PMDocumentsUpdate([FromBody] PMDocumentsUpdate model)
        {
            try
            {
                int result = await _service.PMDocumentsUpdate(model);

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
                        title = "Məlumat yenilənmədi",
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


        // 🔹 Material Insert
        [HttpPost("PMMaterialInsert")]
        public async Task<IActionResult> PMMaterialInsert([FromBody] PMMaterialInsert model)
        {
            try
            {
                int result = await _service.PMMaterialInsert(model);

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
                        title = "Məlumat əlavə olunmadı",
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

        // 🔹 Material Update
        [HttpPut("PMMaterialUpdate")]
        public async Task<IActionResult> PMMaterialUpdate([FromBody] PMMaterialUpdate model)
        {
            try
            {
                int result = await _service.PMMaterialUpdate(model);

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
                        title = "Məlumat yenilənmədi",
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

        // 🔹 Material Status (delete/disable)
        [HttpPut("PMMaterialStatus")]
        public async Task<IActionResult> PMMaterialStatus([FromBody] PMMaterialStatus model)
        {
            try
            {
                int result = await _service.PMMaterialStatus(model);

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

        [HttpGet("PMMaterialSelectMulti")]
        public IActionResult PMMaterialSelectMulti()
        {
            try
            {
                return Ok(new CustomerResponseModel<List<PMMaterialSelectMulti>>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = _repository.PMMaterialSelectMulti()
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

        // 🔹 Assignees Insert
        [HttpPost("PMAssigneesInsert")]
        public async Task<IActionResult> PMAssigneesInsert([FromBody] List<PMAssigneesInsert> model)
        {
            try
            {
                int result = await _service.PMAssigneesInsert(model);

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
                        title = "Məlumat əlavə olunmadı",
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


        // 🔹 Assignees Status (delete/disable)
        [HttpPut("PMAssigneesStatus")]
        public async Task<IActionResult> PMAssigneesStatus([FromBody] PMAssigneesStatus model)
        {
            try
            {
                int result = await _service.PMAssigneesStatus(model);

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


        [HttpPost("PMChatInsert")]
        public async Task<IActionResult> PMChatInsert([FromBody] PMChatInsert model)
        {
            try
            {
                int result = await _service.PMChatInsert(model);

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
                        title = "Məlumat əlavə olunmadı",
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