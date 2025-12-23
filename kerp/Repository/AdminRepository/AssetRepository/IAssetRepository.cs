using kerp.Prosedur.Admin.Asset;

namespace kerp.Repository.AdminRepository.AssetRepository
{
    public interface IAssetRepository
    {
        List<AssetSelectAdmin>? Get();
        List<AssetSelectByStructure>? GetAssetSelectByStructure();
        List<AssetSelectByAssetType>? GetAssetSelectByAssetType();
        List<AssetSelectByAssetTitle>? GetAssetSelectByAssetTitle();
        AssetSelectAdmin? Delete(AssetStatus StructureStatus);
        AssetSelectAdmin? Post(AssetInsert PageInsert);
        AssetSelectAdmin? Put(AssetUpdate StructureUpdate);
    }
}
