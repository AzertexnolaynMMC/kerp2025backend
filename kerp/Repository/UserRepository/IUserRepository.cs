using kerp.Prosedur.Admin.Logs;
using kerp.Prosedur.Users;
using kerp.SystemModel;

namespace kerp.Repository.UserRepository
{
    public interface IUserRepository
    {
        UserLogin? LoginUser(LoginModel model);
        UserSelectShortInfo? UserNameSurnamePositionUpdate(UserNameSurnamePositionUpdate model);
        UserLogin? UserRefleshPage(int model);
        int? AppLogsInsert(List<AppLogsInsert> model);

        UserSelectMailSingle? DeleteUserStatusMailSingle(UserStatusMailSingle StructureStatus);
        UserSelectMailSingle? PostUserInsertMailSingle(UserInsertMailSingle PageInsert);
        UserSelectMailSingle? PutUserUpdateMailSingle(UserUpdateMailSingle StructureUpdate);


        UserPhoneInfoSelect? DeleteUserStatusPhoneSingle(UserStatusPhoneSingle StructureStatus);
        UserPhoneInfoSelect? PostUserInsertPhoneSingle(UserInsertPhoneSingle PageInsert);
        UserPhoneInfoSelect? PutUserUpdatePhoneSingle(UserUpdatePhoneSingle StructureUpdate);
    }
}
