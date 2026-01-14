using kerp.Prosedur.Admin.UserStructureSee;

namespace kerp.Repository.AdminRepository.UserStructureSeeRepository
{
    public interface IUserStructureSeeRepository
    {
        List<UserStructureSeeSelect>? Get();
        List<UserStructureSeeStructureSelect>? GetUserStructureSeeStructureSelect();
        List<UserStructureSeeUserSelect>? GetUserStructureSeeUserSelect();
        UserStructureSeeSelect? Delete(UserStructureSeeStatus StructureStatus);
        List<UserStructureSeeSelect>? Post(List<UserStructureSeeInsert> PageInsert);
    }
}
