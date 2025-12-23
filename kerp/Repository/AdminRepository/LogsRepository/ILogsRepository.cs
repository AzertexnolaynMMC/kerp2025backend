using kerp.Prosedur.Admin.Logs;

namespace kerp.Repository.AdminRepository.LogsRepository
{
    public interface ILogsRepository
    {
        List<SqlLogSelect>? GetSqlLogSelect();
    }
}
