using System.Text.Json;

namespace kerp.Prosedur.Translation
{
    public class TranslationImportRequest
    {
        public string LangCode { get; set; } = null!;
        public JsonElement Json { get; set; }
    }
}
