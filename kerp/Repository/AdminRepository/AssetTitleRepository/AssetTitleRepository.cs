using kerp.Contexts;
using kerp.Prosedur.Admin.AssetTitle;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.AssetTitleRepository
{
    public class AssetTitleRepository(KerpContext ctx) : IAssetTitleRepository
    {
        private readonly KerpContext _ctx = ctx;
        public AssetTitleSelectAdmin? Delete(AssetTitleStatus StructureStatus)
        {
            return _ctx.AssetTitleSelectAdmin.FromSqlRaw(
"EXEC dbo.AssetTitleStatus @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.Status,
StructureStatus.UserId

).ToList().FirstOrDefault();
        }

        public List<AssetTitleSelectAdmin>? Get()
        {
            return [.. _ctx.AssetTitleSelectAdmin.FromSqlRaw(
          "EXEC dbo.AssetTitleSelectAdmin "
          )];
        }

        public AssetTitleSelectAdmin? Post(AssetTitleInsert PageInsert)
        {
            return _ctx.AssetTitleSelectAdmin.FromSqlRaw(
"EXEC dbo.AssetTitleInsert @p0, @p1",
PageInsert.Title,
PageInsert.UserId

).ToList().FirstOrDefault();
        }

        public AssetTitleSelectAdmin? Put(AssetTitleUpdate StructureUpdate)
        {
            return _ctx.AssetTitleSelectAdmin.FromSqlRaw(
"EXEC dbo.AssetTitleUpdate @p0, @p1, @p2",
StructureUpdate.Id,
StructureUpdate.Title,
StructureUpdate.UserId

).ToList().FirstOrDefault();
        }
    }
}
