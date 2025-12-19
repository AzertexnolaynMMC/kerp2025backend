using kerp.Contexts;
using kerp.Prosedur.Admin.WorkOrderType;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.WorkOrderTypeRepository
{
    public class WorkOrderTypeRepository(KerpContext ctx) : IWorkOrderTypeRepository
    {
        private readonly KerpContext _ctx = ctx;
        public WorkOrderTypeSelectAdmin? Delete(WorkOrderTypeStatus StructureStatus)
        {
            return _ctx.WorkOrderTypeSelectAdmin.FromSqlRaw(
"EXEC dbo.WorkOrderTypeStatus @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.Status,
StructureStatus.UserId

).ToList().FirstOrDefault();
        }

        public List<WorkOrderTypeSelectAdmin>? Get()
        {
            return [.. _ctx.WorkOrderTypeSelectAdmin.FromSqlRaw(
          "EXEC dbo.WorkOrderTypeSelectAdmin "
          )];
        }

        public WorkOrderTypeSelectAdmin? Post(WorkOrderTypeInsert PageInsert)
        {
            return _ctx.WorkOrderTypeSelectAdmin.FromSqlRaw(
"EXEC dbo.WorkOrderTypeInsert @p0, @p1, @p2",
PageInsert.Title,
PageInsert.UserId,
PageInsert.Status

).ToList().FirstOrDefault();
        }

        public WorkOrderTypeSelectAdmin? Put(WorkOrderTypeUpdate StructureUpdate)
        {
            return _ctx.WorkOrderTypeSelectAdmin.FromSqlRaw(
"EXEC dbo.WorkOrderTypeUpdate @p0, @p1, @p2",
StructureUpdate.Title,
StructureUpdate.Id,
StructureUpdate.UserId

).ToList().FirstOrDefault();
        }
    }
}
