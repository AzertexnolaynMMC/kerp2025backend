using kerp.Prosedur.Admin.Pages;

namespace kerp.Repository.AdminRepository.PageRepository
{
    public interface IPageRepository
    {
        List<PageAdminAll>? PageAdminAll();
        PageAdminAll? PagesActiveAndDeactive(PagesActiveAndDeactive PagesActiveAndDeactive);
        PageAdminAll? PageInsert(PageInsert PageInsert);
        PageAdminAll? PageUpdate(PageUpdate PageUpdate);
    }
}
