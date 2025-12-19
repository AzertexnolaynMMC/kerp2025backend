using kerp.Contexts;
using kerp.Prosedur.Structure;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.StructureRepository
{
    public class StructureRepository(KerpContext ctx) : IStructureRepository
    {
        private readonly KerpContext _ctx = ctx;
        public StructureSelectAdmin? StructureInsert(StructureInsert PageInsert)
        {
            return _ctx.StructureSelectAdmin.FromSqlRaw(
"EXEC dbo.StructureInsert @p0, @p1, @p2",
PageInsert.Status,
PageInsert.UserId,
PageInsert.Title

).ToList().FirstOrDefault();
        }


        public List<StructureSelectAdmin>? StructureSelectAdmin()
        {
            return [.. _ctx.StructureSelectAdmin.FromSqlRaw(
          "EXEC dbo.StructureSelectAdmin "
          )];
        }

        public StructureSelectAdmin? StructureStatus(StructureStatus StructureStatus)
        {
            return _ctx.StructureSelectAdmin.FromSqlRaw(
"EXEC dbo.StructureStatus @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.UserId,
StructureStatus.Status

).ToList().FirstOrDefault();
        }

        public StructureSelectAdmin? StructureUpdate(StructureUpdate StructureUpdate)
        {
            return _ctx.StructureSelectAdmin.FromSqlRaw(
"EXEC dbo.StructureUpdate @p0, @p1, @p2",
StructureUpdate.Id,
StructureUpdate.UserId,
StructureUpdate.Title

).ToList().FirstOrDefault();
        }
    }
}
