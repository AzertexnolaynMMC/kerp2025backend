using kerp.Prosedur.Canban;

namespace kerp.Repository.CanbanRepository
{
    public interface ICanbanRepository
    {
        List<CanbanCard>? GetCanbanCard(CanbanModel PageInsert);
    }
}
