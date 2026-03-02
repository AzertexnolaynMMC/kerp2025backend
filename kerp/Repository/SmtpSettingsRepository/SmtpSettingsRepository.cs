using kerp.Contexts;
using kerp.Prosedur.SmtpSettings;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.SmtpSettingsRepository
{
    public class SmtpSettingsRepository(KerpContext ctx) : ISmtpSettingsRepository
    {
        private readonly KerpContext _ctx = ctx;

        public SmtpSettingsResult? GetActiveSmtpSetting()
        {
            return _ctx.SmtpSettingsResult
                .FromSqlRaw("EXEC dbo.GetSmtpSettings")
                .AsEnumerable()  // ✅ Client-side-a keçin
                .FirstOrDefault();
        }
    }

}
