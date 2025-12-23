using kerp.Contexts;
using kerp.Prosedur.Admin.Logs;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.LogsRepository
{
    public class LogsRepository(KerpContext ctx) : ILogsRepository
    {
        private readonly KerpContext _ctx = ctx;
        public List<SqlLogSelect>? GetSqlLogSelect()
        {
            return [.. _ctx.SqlLogSelect.FromSqlRaw(
          "EXEC dbo.SqlLogSelect "
          )];
        }
    }
}
