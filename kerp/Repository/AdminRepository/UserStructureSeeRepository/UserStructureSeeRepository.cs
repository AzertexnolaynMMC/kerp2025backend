using kerp.Contexts;
using kerp.Prosedur.Admin.UserStructureSee;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.UserStructureSeeRepository
{
    public class UserStructureSeeRepository(KerpContext ctx) : IUserStructureSeeRepository
    {
        private readonly KerpContext _ctx = ctx;



        #region Select

        public List<UserStructureSeeSelect>? Get()
        {
            return ExecuteList<UserStructureSeeSelect>(
                "EXEC dbo.UserStructureSeeSelect");
        }

        public List<UserStructureSeeStructureSelect>? GetUserStructureSeeStructureSelect()
        {
            return ExecuteList<UserStructureSeeStructureSelect>(
                "EXEC dbo.UserStructureSeeStructureSelect");
        }

        public List<UserStructureSeeUserSelect>? GetUserStructureSeeUserSelect()
        {
            return ExecuteList<UserStructureSeeUserSelect>(
                "EXEC dbo.UserStructureSeeUserSelect");
        }

        #endregion

        #region Post (Insert)

        public List<UserStructureSeeSelect>? Post(List<UserStructureSeeInsert> pageInsert)
        {
            /*
             MaterialInsert içində bunlar olmalıdır:
             - StructureId
             - UserId        (əməliyyatı edən)
             - SelectUserId  (əlavə olunan user)
            */

            List<UserStructureSeeSelect> result = [];
            foreach (UserStructureSeeInsert item in pageInsert)
            {
                UserStructureSeeSelect? row = ExecuteSingle<UserStructureSeeSelect>(
                "EXEC dbo.UserStructureSeeInsert @p0, @p1, @p2",
                item.StructureId,
                item.UserId,
                item.SelectUserId
            );

                if (row != null)
                {
                    result.Add(row);
                }
            }
            return result;
        }

        #endregion

        #region Status (Delete / Active-Deactive)

        public UserStructureSeeSelect? Delete(UserStructureSeeStatus structureStatus)
        {
            /*
             MaterialStatus içində:
             - Id
             - Status
             - UserId
            */

            return ExecuteSingle<UserStructureSeeSelect>(
                "EXEC dbo.UserStructureSeeStatus @p0, @p1, @p2",
                structureStatus.Id,
                structureStatus.Status,
                structureStatus.UserId
            );
        }

        #endregion

        #region Helpers (MachineIncident ilə EYNİ)

        private List<T>? ExecuteList<T>(string sql) where T : class
        {
            return _ctx.Set<T>()
                       .FromSqlRaw(sql)
                       .AsNoTracking()
                       .AsEnumerable()   // 🔥 ÇOX VACİB
                       .ToList();
        }

        private T? ExecuteSingle<T>(string sql, params object[] parameters) where T : class
        {
            return _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()   // 🔥 ÇOX VACİB
                       .FirstOrDefault();
        }

        #endregion
    }
}
