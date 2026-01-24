using kerp.Prosedur.Canban;

namespace kerp.Repository.CanbanRepository
{
    public interface ICanbanRepository
    {
        List<CanbanCard>? GetCanbanCard(CanbanModel PageInsert);
        CanbanCardHub? CanbanCardHub(int PageInsert);
        List<T>? ExecuteList<T>(string sql, params object[] parameters)
    where T : class;

        T? ExecuteSingle<T>(string sql, params object[] parameters)
            where T : class;
    }
}
