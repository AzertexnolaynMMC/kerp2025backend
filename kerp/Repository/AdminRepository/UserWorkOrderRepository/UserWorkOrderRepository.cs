using kerp.Contexts;
using kerp.Prosedur.Admin.UserWorkOrderSee;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.UserWorkOrderRepository
{
    public class UserWorkOrderRepository(KerpContext ctx) : IUserWorkOrderRepository
    {
        private readonly KerpContext _ctx = ctx;


        #region Status (Delete / Active-Deactive)
        public UserWorkOrderSeeSelect? Delete(UserWorkOrderSeeStatus StructureStatus)
        {
            return ExecuteSingle<UserWorkOrderSeeSelect>(
            "EXEC dbo.UserWorkOrderSeeStatus @p0, @p1, @p2",
            StructureStatus.Id,
            StructureStatus.Status,
            StructureStatus.UserId
        );
        }

        #endregion


        #region Post (Insert)
        public List<UserWorkOrderSeeSelect>? Post(List<UserWorkOrderSeeInsert> PageInsert)
        {
            List<UserWorkOrderSeeSelect> result = [];
            foreach (UserWorkOrderSeeInsert item in PageInsert)
            {
                UserWorkOrderSeeSelect? row = ExecuteSingle<UserWorkOrderSeeSelect>(
                "EXEC dbo.UserWorkOrderSeeInsert @p0, @p1, @p2",
                item.WorkOrderId,
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


        #region Select

        public List<UserWorkOrderSeeSelect>? Get()
        {
            return ExecuteList<UserWorkOrderSeeSelect>(
           "EXEC dbo.UserWorkOrderSeeSelect");
        }

        public List<UserWorkOrderSeeUsersSelect>? GetUserWorkOrderSeeUsersSelect()
        {
            return ExecuteList<UserWorkOrderSeeUsersSelect>(
     "EXEC dbo.UserWorkOrderSeeUsersSelect");
        }

        public List<UserWorkOrderSeeWorkOrderSelect>? GetUserWorkOrderSeeWorkOrderSelect()
        {
            return ExecuteList<UserWorkOrderSeeWorkOrderSelect>(
     "EXEC dbo.UserWorkOrderSeeWorkOrderSelect");
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
