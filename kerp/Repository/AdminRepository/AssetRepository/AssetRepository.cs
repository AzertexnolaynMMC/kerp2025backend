using kerp.Contexts;
using kerp.Prosedur.Admin.Asset;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.AssetRepository
{
    public class AssetRepository(KerpContext ctx) : IAssetRepository
    {
        private readonly KerpContext _ctx = ctx;
        public AssetSelectAdmin? Delete(AssetStatus StructureStatus)
        {
            return _ctx.AssetSelectAdmin.FromSqlRaw(
"EXEC dbo.AssetStatus @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.UserId,
StructureStatus.Status

).ToList().FirstOrDefault();
        }

        public List<AssetSelectAdmin>? Get()
        {
            return [.. _ctx.AssetSelectAdmin.FromSqlRaw(
          "EXEC dbo.AssetSelectAdmin "
          )];
        }

        public List<AssetSelectByAssetTitle>? GetAssetSelectByAssetTitle()
        {
            return [.. _ctx.AssetSelectByAssetTitle.FromSqlRaw(
          "EXEC dbo.AssetSelectByAssetTitle "
          )];
        }

        public List<AssetSelectByAssetType>? GetAssetSelectByAssetType()
        {
            return [.. _ctx.AssetSelectByAssetType.FromSqlRaw(
          "EXEC dbo.AssetSelectByAssetType "
          )];
        }

        public List<AssetSelectByStructure>? GetAssetSelectByStructure()
        {
            return [.. _ctx.AssetSelectByStructure.FromSqlRaw(
          "EXEC dbo.AssetSelectByStructure "
          )];
        }

        public AssetSelectAdmin? Post(AssetInsert PageInsert)
        {
            if (PageInsert.AssetTitleId == 0)
            {
                AssetSelectByAssetTitle AssetSelectByAssetTitle = _ctx.AssetSelectByAssetTitle.FromSqlRaw(
"EXEC dbo.AssetInsertByAssetTitle @p0, @p1",
PageInsert.AssetTitle,
PageInsert.UserId
).ToList().FirstOrDefault();
                PageInsert.AssetTitleId = AssetSelectByAssetTitle!.Id;
            }

            return _ctx.AssetSelectAdmin.FromSqlRaw(
"EXEC dbo.AssetInsert @p0, @p1, @p2, @p3, @p4",
PageInsert.AssetTitleId,
PageInsert.UnderAssetId,
PageInsert.StructureId,
PageInsert.AssetTypeId,
PageInsert.UserId
).ToList().FirstOrDefault();
        }

        public AssetSelectAdmin? Put(AssetUpdate StructureUpdate)
        {
            if (StructureUpdate.AssetTitleId == 0)
            {
                AssetSelectByAssetTitle AssetSelectByAssetTitle = _ctx.AssetSelectByAssetTitle.FromSqlRaw(
"EXEC dbo.AssetInsertByAssetTitle @p0, @p1",
StructureUpdate.AssetTitle,
StructureUpdate.UserId
).ToList().FirstOrDefault();
                StructureUpdate.AssetTitleId = AssetSelectByAssetTitle!.Id;
            }

            return _ctx.AssetSelectAdmin.FromSqlRaw(
"EXEC dbo.AssetInsert @p0, @p1, @p2, @p3",
StructureUpdate.AssetTitleId,
StructureUpdate.Id,
StructureUpdate.AssetTypeId,
StructureUpdate.UserId
).ToList().FirstOrDefault();
        }
    }
}
