using kerp.Contexts;
using kerp.Prosedur.Admin.ManagerEmploye;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.ManagerEmployeRepository
{
    public class ManagerEmployeRepository(KerpContext ctx) : IManagerEmployeRepository
    {
        private readonly KerpContext _ctx = ctx;
        public ManagerEmployeSelect? Delete(ManagerEmployeStatus StructureStatus)
        {
            return _ctx.ManagerEmployeSelect.FromSqlRaw(
"EXEC dbo.ManagerEmployeStatus @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.UserId,
StructureStatus.Status

).ToList().FirstOrDefault();
        }

        public List<ManagerEmployeSelect>? Get()
        {
            return [.. _ctx.ManagerEmployeSelect.FromSqlRaw(
          "EXEC dbo.ManagerEmployeSelect "
          )];
        }

        public List<ManagerEmployeUsers>? ManagerEmployeUsers()
        {
            return [.. _ctx.ManagerEmployeUsers.FromSqlRaw(
          "EXEC dbo.ManagerEmployeUsers "
          )];
        }

        public List<ManagerEmployeSelect>? Post(List<ManagerEmployeInsert> PageInsert)
        {
            List<ManagerEmployeSelect> result = [];
            foreach (ManagerEmployeInsert item in PageInsert)
            {
                ManagerEmployeSelect? row = _ctx.ManagerEmployeSelect.FromSqlRaw(
"EXEC dbo.ManagerEmployeInsert @p0, @p1, @p2",
item.ManagerId,
item.WorkerId,
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
