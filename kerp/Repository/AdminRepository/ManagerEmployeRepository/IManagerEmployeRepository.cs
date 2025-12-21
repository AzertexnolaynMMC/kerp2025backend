using kerp.Prosedur.Admin.ManagerEmploye;

namespace kerp.Repository.AdminRepository.ManagerEmployeRepository
{
    public interface IManagerEmployeRepository
    {
        List<ManagerEmployeSelect>? Get();
        List<ManagerEmployeUsers>? ManagerEmployeUsers();
        ManagerEmployeSelect? Delete(ManagerEmployeStatus StructureStatus);
        List<ManagerEmployeSelect>? Post(List<ManagerEmployeInsert> PageInsert);
    }
}
