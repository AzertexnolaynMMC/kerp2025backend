using kerp.Contexts;
using kerp.Prosedur.Admin.Language;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.LanguageRepository
{
    public class LanguageRepository(KerpContext ctx) : ILanguageRepository
    {
        private readonly KerpContext _ctx = ctx;

        public LanguageAdminAll? LanguageActiveAndDeaktive(LanguageActiveAndDeaktive LanguageActiveAndDeaktive)
        {
            return _ctx.LanguageAdminAll.FromSqlRaw(
"EXEC dbo.LanguageActiveAndDeactive @p0, @p1, @p2",
LanguageActiveAndDeaktive.Id,
LanguageActiveAndDeaktive.UserId,
LanguageActiveAndDeaktive.Status
).ToList().FirstOrDefault();
        }

        public List<LanguageAdminAll>? LanguageAdminAll()
        {
            return [.. _ctx.LanguageAdminAll.FromSqlRaw(
          "EXEC dbo.LanguageAdminAll "
          )];
        }

        public LanguageAdminAll? LanguageInsert(LanguageInsert LanguageInsert)
        {
            return _ctx.LanguageAdminAll.FromSqlRaw(
"EXEC dbo.LanguageInsert @p0, @p1, @p2",
LanguageInsert.Title,
LanguageInsert.Status,
LanguageInsert.UserId
).ToList().FirstOrDefault();
        }

        public LanguageAdminAll? LanguageUpdate(LanguageUpdate LanguageUpdate)
        {
            return _ctx.LanguageAdminAll.FromSqlRaw(
"EXEC dbo.LanguageUpdate @p0, @p1, @p2, @p3",
LanguageUpdate.Id,
LanguageUpdate.Title,
LanguageUpdate.Status,
LanguageUpdate.UserId
).ToList().FirstOrDefault();
        }
    }
}
