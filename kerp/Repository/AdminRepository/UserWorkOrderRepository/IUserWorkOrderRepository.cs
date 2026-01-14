using kerp.Prosedur.Admin.UserWorkOrderSee;

namespace kerp.Repository.AdminRepository.UserWorkOrderRepository
{
    public interface IUserWorkOrderRepository
    {
        List<UserWorkOrderSeeSelect>? Get();
        List<UserWorkOrderSeeUsersSelect>? GetUserWorkOrderSeeUsersSelect();
        List<UserWorkOrderSeeWorkOrderSelect>? GetUserWorkOrderSeeWorkOrderSelect();
        UserWorkOrderSeeSelect? Delete(UserWorkOrderSeeStatus StructureStatus);
        List<UserWorkOrderSeeSelect>? Post(List<UserWorkOrderSeeInsert> PageInsert);
    }
}
