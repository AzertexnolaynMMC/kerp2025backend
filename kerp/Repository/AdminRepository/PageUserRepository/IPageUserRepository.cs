using kerp.Prosedur.Admin.PageUser;

namespace kerp.Repository.AdminRepository.PageUserRepository
{
    public interface IPageUserRepository
    {
        List<PageUserSelectAdmin>? Get();
        List<PageUserSelectPage>? GetPageUserSelectPage();
        List<PageUserSelectUser>? GetPageUserSelectUser();
        PageUserSelectAdmin? Delete(PageUserStatus StructureStatus);
        List<PageUserSelectAdmin>? Post(List<PageUserInsert> PageInsert);
    }
}
