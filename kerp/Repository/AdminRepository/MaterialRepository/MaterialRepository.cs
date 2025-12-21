using kerp.Contexts;
using kerp.Prosedur.Admin.Material;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.MaterialRepository
{
    public class MaterialRepository(KerpContext ctx) : IMaterialRepository
    {
        private readonly KerpContext _ctx = ctx;
        public MaterialSelectAdmin? Delete(MaterialStatus StructureStatus)
        {
            return _ctx.MaterialSelectAdmin.FromSqlRaw(
"EXEC dbo.MaterialStatus @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.UserId,
StructureStatus.Status

).ToList().FirstOrDefault();
        }

        public List<MaterialSelectAdmin>? Get()
        {
            return [.. _ctx.MaterialSelectAdmin.FromSqlRaw(
          "EXEC dbo.MaterialSelectAdmin "
          )];
        }

        public MaterialSelectAdmin? Post(MaterialInsert PageInsert)
        {
            return _ctx.MaterialSelectAdmin.FromSqlRaw(
"EXEC dbo.MaterialInsert @p0, @p1, @p2, @p3",
PageInsert.Title,
PageInsert.Code,
PageInsert.Measure,
PageInsert.UserId

).ToList().FirstOrDefault();
        }

        public MaterialSelectAdmin? Put(MaterialUpdate PageInsert)
        {
            return _ctx.MaterialSelectAdmin.FromSqlRaw(
"EXEC dbo.MaterialUpdate @p0, @p1, @p2, @p3, @p4",
PageInsert.Title,
PageInsert.Code,
PageInsert.Measure,
PageInsert.UserId,
PageInsert.Id

).ToList().FirstOrDefault();
        }
    }
}
