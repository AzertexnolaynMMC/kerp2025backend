using kerp.Contexts;
using kerp.Prosedur.Admin.UserConMachine;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.UserConMachineRepository
{
    public class UserConMachineRepository(KerpContext ctx) : IUserConMachineRepository
    {
        private readonly KerpContext _ctx = ctx;
        public UserConMachineSelectAdmin? Delete(UserConMachineStatus StructureStatus)
        {
            return _ctx.UserConMachineSelectAdmin.FromSqlRaw(
"EXEC dbo.UserConMachineStatus @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.UserId,
StructureStatus.Status

).ToList().FirstOrDefault();
        }

        public List<UserConMachineSelectAdmin>? Get()
        {
            return [.. _ctx.UserConMachineSelectAdmin.FromSqlRaw(
          "EXEC dbo.UserConMachineSelectAdmin "
          )];
        }

        public List<UserConMachineSelectMachine>? GetUserConMachineSelectMachine()
        {
            return [.. _ctx.UserConMachineSelectMachine.FromSqlRaw(
          "EXEC dbo.UserConMachineSelectMachine "
          )];
        }

        public List<UserConMachineSelectUser>? GetUserConMachineSelectUser()
        {
            return [.. _ctx.UserConMachineSelectUser.FromSqlRaw(
          "EXEC dbo.UserConMachineSelectUser "
          )];
        }

        public List<UserConMachineSelectAdmin>? Post(List<UserConMachineInsert> PageInsert)
        {
            List<UserConMachineSelectAdmin> result = [];
            foreach (UserConMachineInsert? item in PageInsert)
            {
                UserConMachineSelectAdmin? row = _ctx.UserConMachineSelectAdmin.FromSqlRaw(
"EXEC dbo.UserConMachineInsert @p0, @p1, @p2",
item.SelectUserId,
item.MachineId,
item.UserId

).ToList().FirstOrDefault();

                if (row != null)
                {
                    result.Add(row);
                }
            }
            return result;
        }
    }
}
