using kerp.Prosedur.Admin.AssetTitle;

namespace kerp.Repository.AdminRepository.AssetTitleRepository
{
    public interface IAssetTitleRepository
    {
        List<AssetTitleSelectAdmin>? Get();
        AssetTitleSelectAdmin? Delete(AssetTitleStatus StructureStatus);
        AssetTitleSelectAdmin? Post(AssetTitleInsert PageInsert);
        AssetTitleSelectAdmin? Put(AssetTitleUpdate StructureUpdate);
    }
}
