using kerp.Prosedur.Admin.UserConMachine;

namespace kerp.Repository.AdminRepository.UserConMachineRepository
{
    public interface IUserConMachineRepository
    {
        List<UserConMachineSelectAdmin>? Get();
        List<UserConMachineSelectUser>? GetUserConMachineSelectUser();
        List<UserConMachineSelectMachine>? GetUserConMachineSelectMachine();
        UserConMachineSelectAdmin? Delete(UserConMachineStatus StructureStatus);
        List<UserConMachineSelectAdmin>? Post(List<UserConMachineInsert> PageInsert);
    }
}
