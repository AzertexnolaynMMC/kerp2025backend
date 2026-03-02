using kerp.Prosedur.Translation;

namespace kerp.Repository.TranslationRepository
{
    public interface ITranslationRepository
    {
        List<TranslationGetByLang>? GetByLang(string langCode);
        void Import(string langCode, Dictionary<string, string> flatJson);
    }
}
