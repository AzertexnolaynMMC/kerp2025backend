using kerp.Prosedur.Hr.Users;
using kerp.Prosedur.Hr.Users.Mail;
using kerp.Prosedur.Hr.Users.Phone;
using kerp.Prosedur.Hr.Users.Section;
using kerp.Prosedur.Hr.Users.Structur;
using kerp.Prosedur.Hr.Users.User;

namespace kerp.Repository.HrRepository.UserRepository
{
    public interface IUserRepository
    {
        List<UserSelectAdmin>? Get();
        List<UserSelectStructure>? GetUserSelectStructure();
        List<UserSelectSection>? GetUserSelectSection();
        List<UserSelectPhone>? GetUserSelectPhone();
        List<UserSelectMail>? GetUserSelectMail();


        UserSelectAdmin? Delete(UserStatus StructureStatus);
        InsertUserMailPhoneSelectList? Post(UserInsert PageInsert);
        UserSelectAdmin? Put(UserUpdate StructureUpdate);


        UserSelectPhone? DeleteUserStatusPhone(UserStatus StructureStatus);
        UserSelectPhone? PostUserInsertPhone(UserInsertPhone PageInsert);
        UserSelectPhone? PutUserUpdatetPhone(UserUpdatetPhone StructureUpdate);


        UserStatusMail? DeleteUserStatusMail(UserStatusMail StructureStatus);
        UserStatusMail? PostUserInsertMail(UserInsertMail PageInsert);
        UserStatusMail? PutUserUpdatetMail(UserUpdatetMail StructureUpdate);



    }
}
