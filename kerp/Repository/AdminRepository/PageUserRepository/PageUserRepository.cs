using kerp.Contexts;
using kerp.Prosedur.Admin.PageUser;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.PageUserRepository
{
    public class PageUserRepository(KerpContext ctx) : IPageUserRepository
    {
        private readonly KerpContext _ctx = ctx;
        public PageUserSelectAdmin? Delete(PageUserStatus StructureStatus)
        {
            return _ctx.PageUserSelectAdmin.FromSqlRaw(
"EXEC dbo.PageUserStatus @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.Status,
StructureStatus.UserId

).ToList().FirstOrDefault();
        }

        public List<PageUserSelectAdmin>? Get()
        {
            return [.. _ctx.PageUserSelectAdmin.FromSqlRaw(
          "EXEC dbo.PageUserSelectAdmin "
          )];
        }

        public List<PageUserSelectPage>? GetPageUserSelectPage()
        {
            return [.. _ctx.PageUserSelectPage.FromSqlRaw(
          "EXEC dbo.PageUserSelectPage "
          )];
        }

        public List<PageUserSelectUser>? GetPageUserSelectUser()
        {
            return [.. _ctx.PageUserSelectUser.FromSqlRaw(
          "EXEC dbo.PageUserSelectUser "
          )];
        }

        public List<PageUserSelectAdmin>? Post(List<PageUserInsert> PageInsert)
        {
            List<PageUserSelectAdmin> result = [];
            foreach (PageUserInsert item in PageInsert)
            {
                PageUserSelectAdmin? row = _ctx.PageUserSelectAdmin.FromSqlRaw(
"EXEC dbo.PageUserInsert @p0, @p1, @p2",
item.CreateUserId,
item.PageId,
item.UserId

).ToList().FirstOrDefault();

                if (row != null)
                {
                    result.Add(row);
                }
            }
            return result;
        }
    }
}
