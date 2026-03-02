// Controllers/TranslationController.cs
using kerp.Prosedur.Translation;
using kerp.Repository.TranslationRepository;
using kerp.SystemModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace kerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationController(ITranslationRepository repository) : ControllerBase
    {
        private readonly ITranslationRepository _repository = repository;

        [HttpGet("GetByLang/{langCode}")]
        public IActionResult GetByLang(string langCode)
        {
            try
            {
                List<TranslationGetByLang>? flat = _repository.GetByLang(langCode);

                Dictionary<string, object> root = new();
                foreach (TranslationGetByLang item in flat ?? [])
                {
                    string[] parts = item.Key.Split('.');
                    Dictionary<string, object> current = root;
                    for (int i = 0; i < parts.Length - 1; i++)
                    {
                        if (!current.ContainsKey(parts[i]))
                        {
                            current[parts[i]] = new Dictionary<string, object>();
                        }

                        current = (Dictionary<string, object>)current[parts[i]];
                    }
                    current[parts[^1]] = item.Value;
                }

                return Ok(root);
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

        [HttpPost("Import")]
        public IActionResult Import([FromBody] TranslationImportRequest request)
        {
            try
            {
                Dictionary<string, string> flat = new();
                FlattenJson(request.Json, "", flat);

                _repository.Import(request.LangCode, flat);

                return Ok(new CustomerResponseModel<object>
                {
                    StatusCode = 0,
                    title = "Uğurlu əməliyyat",
                    AccessToken = null,
                    Data = new { TotalKeys = flat.Count }
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

        private void FlattenJson(
            JsonElement element,
            string prefix,
            Dictionary<string, string> result)
        {
            if (element.ValueKind == JsonValueKind.Object)
            {
                foreach (JsonProperty prop in element.EnumerateObject())
                {
                    string key = string.IsNullOrEmpty(prefix)
                        ? prop.Name
                        : $"{prefix}.{prop.Name}";
                    FlattenJson(prop.Value, key, result);
                }
            }
            else if (element.ValueKind == JsonValueKind.String)
            {
                result[prefix] = element.GetString()!;
            }
        }
    }
}