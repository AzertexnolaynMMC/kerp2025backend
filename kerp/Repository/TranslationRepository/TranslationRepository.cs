// Repository/TranslationRepository/TranslationRepository.cs
using kerp.Contexts;
using kerp.Prosedur.Translation;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.TranslationRepository
{
    public class TranslationRepository(KerpContext ctx) : ITranslationRepository
    {
        private readonly KerpContext _ctx = ctx;

        public List<TranslationGetByLang>? GetByLang(string langCode)
        {
            return [.. _ctx.TranslationGetByLang
                .FromSqlRaw("EXEC dbo.TranslationGetByLang @p0", langCode)
                .AsNoTracking()];
        }

        public void Import(string langCode, Dictionary<string, string> flatJson)
        {
            int language = _ctx.Database
                .SqlQueryRaw<int>(
                    "SELECT Id FROM Language WHERE Title = {0} AND Status = 1",
                    langCode)
                .ToList()
                .FirstOrDefault();

            if (language == 0)
            {
                throw new Exception($"Language tapılmadı: {langCode}");
            }

            foreach ((string key, string value) in flatJson)
            {
                int keyId = _ctx.Database
                    .SqlQueryRaw<int>("EXEC dbo.TranslationKeyInsert {0}", key)
                    .ToList()
                    .FirstOrDefault();

                _ = _ctx.Database.ExecuteSqlRaw(
                    "EXEC dbo.TranslationInsertOrUpdate {0}, {1}, {2}",
                    keyId,
                    language,
                    value
                );
            }
        }
    }
}