using kerp.Contexts;
using kerp.Prosedur.Admin.UserLogins;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.UserLoginsRepository
{
    public class UserLoginsRepository(KerpContext ctx) : IUserLoginsRepository
    {
        private readonly KerpContext _ctx = ctx;
        public UserLoginsSelectAdmin? Delete(UserLoginsStatus StructureStatus)
        {
            return _ctx.UserLoginsSelectAdmin.FromSqlRaw(
"EXEC dbo.UserLoginsStatus @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.Status,
StructureStatus.UserId

).ToList().FirstOrDefault();
        }

        public List<UserLoginsSelectAdmin>? Get()
        {
            return [.. _ctx.UserLoginsSelectAdmin.FromSqlRaw(
          "EXEC dbo.UserLoginsSelectAdmin"
          )];
        }

        public List<UserLoginsSelectLoginType>? GetUserLoginsSelectLoginType()
        {
            return [.. _ctx.UserLoginsSelectLoginType.FromSqlRaw(
          "EXEC dbo.UserLoginsSelectLoginType"
          )];
        }

        public List<UserLoginsSelectUser>? GetUserLoginsSelectUser()
        {
            return [.. _ctx.UserLoginsSelectUser.FromSqlRaw(
          "EXEC dbo.UserLoginsSelectUser"
          )];
        }

        public UserLoginsSelectAdmin? Post(UserLoginsInsert PageInsert)
        {
            return _ctx.UserLoginsSelectAdmin.FromSqlRaw(
"EXEC dbo.UserLoginsInsert @p0, @p1, @p2, @p3, @p4",
PageInsert.Title,
PageInsert.UserId,
PageInsert.LoginTypeId,
PageInsert.SelectUserId,
PageInsert.Password

).ToList().FirstOrDefault();
        }

        public UserLoginsSelectAdmin? Put(UserLoginsUpdate StructureUpdate)
        {
            return _ctx.UserLoginsSelectAdmin.FromSqlRaw(
"EXEC dbo.UserLoginsUpdate @p0, @p1, @p2, @p3, @p4",
StructureUpdate.Title,
StructureUpdate.UserId,
StructureUpdate.LoginTypeId,
StructureUpdate.Password,
StructureUpdate.Id

).ToList().FirstOrDefault();
        }
    }
}
