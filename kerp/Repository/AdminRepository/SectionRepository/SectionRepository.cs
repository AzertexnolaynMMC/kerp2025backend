using kerp.Contexts;
using kerp.Prosedur.Admin.Section;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.SectionRepository
{
    public class SectionRepository(KerpContext ctx) : ISectionRepository
    {
        private readonly KerpContext _ctx = ctx;
        public SectionSelectAdmin? Delete(SectionStatus StructureStatus)
        {
            return _ctx.SectionSelectAdmin.FromSqlRaw(
"EXEC dbo.SectionStatus @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.Status,
StructureStatus.UserId

).ToList().FirstOrDefault();
        }

        public List<SectionSelectAdmin>? Get()
        {
            return [.. _ctx.SectionSelectAdmin.FromSqlRaw(
          "EXEC dbo.SectionSelectAdmin "
          )];
        }

        public List<SectionStructureSelect>? GetSectionStructureSelect()
        {
            return [.. _ctx.SectionStructureSelect.FromSqlRaw(
          "EXEC dbo.SectionStructureSelect "
          )];
        }

        public SectionSelectAdmin? Post(SectionInsert PageInsert)
        {
            return _ctx.SectionSelectAdmin.FromSqlRaw(
"EXEC dbo.SectionInsert @p0, @p1, @p2, @p3, @p4",
PageInsert.Title,
PageInsert.Status,
PageInsert.UnderId,
PageInsert.StructureId,
PageInsert.UserId

).ToList().FirstOrDefault();
        }

        public SectionSelectAdmin? Put(SectionUpdate StructureUpdate)
        {
            return _ctx.SectionSelectAdmin.FromSqlRaw(
"EXEC dbo.SectionUpdate @p0, @p1, @p2",
StructureUpdate.Title,
StructureUpdate.Id,
StructureUpdate.UserId

).ToList().FirstOrDefault();
        }
    }
}
