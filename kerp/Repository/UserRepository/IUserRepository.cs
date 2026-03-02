using kerp.Prosedur.Admin.Logs;
using kerp.Prosedur.Users;
using kerp.Prosedur.Users.Asset;
using kerp.Prosedur.Users.Employer;
using kerp.Prosedur.Users.Login;
using kerp.Prosedur.Users.Mail;
using kerp.Prosedur.Users.phone;
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




        UserSelectConMachineSingle? DeleteUserStatusConMachineSingle(UserStatusConMachineSingle StructureStatus);
        UserSelectConMachineSingle? PostUserInsertConMachineSingle(UserInsertConMachineSingle PageInsert);
        List<UserSelectAssets>? GetUserSelectAssets();




        UserSelectEmployerSingle? DeleteUserStatusEmployerSingle(UserStatusEmployerSingle StructureStatus);
        UserSelectEmployerSingle? PostUserInsertEmployerSingle(UserInsertEmployerSingle PageInsert);
        List<UserSelectEmployerMulti>? GetUserSelectEmployerMulti();






        UserSelectLoginSingle? DeleteUserStatusLoginSingle(UserStatusLoginSingle StructureStatus);
        UserSelectLoginSingle? PostUserInsertLoginSingle(UserInsertLoginSingle PageInsert);
        UserSelectLoginSingle? PutUserUpdateLoginSingle(UserUpdateLoginSingle StructureUpdate);

        List<UserSelectLoginTypeMulti>? GetUserSelectLoginTypeMulti();
        Task<List<UserFcmToken>> GetUserFcmTokens(int workOrderTypeId, int structureId, int creatorUserId);
    }
}
