using kerp.Contexts;
using kerp.Prosedur.Admin.Pages;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.PageRepository
{
    public class PageRepository(KerpContext ctx) : IPageRepository
    {
        private readonly KerpContext _ctx = ctx;
        public List<PageAdminAll>? PageAdminAll()
        {
            return [.. _ctx.PageAdminAll.FromSqlRaw(
          "EXEC dbo.PageAdminAll "
          )];
        }

        public PageAdminAll? PageInsert(PageInsert PageInsert)
        {
            return _ctx.PageAdminAll.FromSqlRaw(
"EXEC dbo.PageInsert @p0, @p1, @p2, @p3, @p4, @p5, @p6",
PageInsert.Title,
PageInsert.Route,
PageInsert.Icon,
PageInsert.LangRoute,
PageInsert.UnderPageId,
PageInsert.Status,
PageInsert.UserId
).ToList().FirstOrDefault();
        }

        public PageAdminAll? PagesActiveAndDeactive(PagesActiveAndDeactive PagesActiveAndDeactive)
        {
            return _ctx.PageAdminAll.FromSqlRaw(
            "EXEC dbo.PagesActiveAndDeactive @p0, @p1, @p2",
            PagesActiveAndDeactive.Id,
            PagesActiveAndDeactive.UserId,
            PagesActiveAndDeactive.Status
            ).ToList().FirstOrDefault();
        }

        public PageAdminAll? PageUpdate(PageUpdate PageUpdate)
        {
            return _ctx.PageAdminAll.FromSqlRaw(
"EXEC dbo.PageUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7",
PageUpdate.Id,
PageUpdate.Title,
PageUpdate.Route,
PageUpdate.Icon,
PageUpdate.LangRoute,
PageUpdate.UnderPageId,
PageUpdate.Status,
PageUpdate.UserId
).ToList().FirstOrDefault();
        }
    }
}
