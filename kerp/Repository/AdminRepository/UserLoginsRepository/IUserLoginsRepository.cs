using kerp.Prosedur.Admin.UserLogins;

namespace kerp.Repository.AdminRepository.UserLoginsRepository
{
    public interface IUserLoginsRepository
    {
        List<UserLoginsSelectAdmin>? Get();
        List<UserLoginsSelectUser>? GetUserLoginsSelectUser();
        List<UserLoginsSelectLoginType>? GetUserLoginsSelectLoginType();
        UserLoginsSelectAdmin? Delete(UserLoginsStatus StructureStatus);
        UserLoginsSelectAdmin? Post(UserLoginsInsert PageInsert);
        UserLoginsSelectAdmin? Put(UserLoginsUpdate StructureUpdate);
    }
}
