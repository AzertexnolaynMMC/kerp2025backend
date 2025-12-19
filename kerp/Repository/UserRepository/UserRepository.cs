using kerp.Contexts;
using kerp.Entities;
using kerp.Prosedur.Users.UserPage;
using kerp.SystemModel;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.UserRepository
{
    public class UserRepository(KerpContext ctx) : IUserRepository
    {
        private readonly KerpContext _ctx = ctx;
        public UserLogin? LoginUser(LoginModel model)
        {
            UserLogin userLogin = _ctx.UserLogin.FromSqlRaw(
                "EXEC dbo.UserLogin @p0, @p1, @p2",
                model.UserName?.ToLower(),
                model.Password,
                model.LoginType
            ).AsEnumerable().FirstOrDefault();

            if (userLogin != null)
            {
                // Root (üst səviyyə) səhifələri və alt bolmələri ilə birlikdə doldur
                userLogin.UserPage = GetUserPages(userLogin.UserId, 0);
            }

            return userLogin;
        }

        public UserLogin? UserRefleshPage(int model)
        {
            // 1. SP nəticəsini oxu (UserRefleshPage modelinə map olunur)
            UserRefleshPage? spResult = _ctx.UserRefleshPage
                .FromSqlRaw("EXEC dbo.UserRefleshPage @p0", model)
                .AsEnumerable()
                .FirstOrDefault();

            if (spResult == null)
            {
                return null;
            }

            // 2. SP nəticəsini UserLogin modelinə çevir
            UserLogin userLogin = new()
            {
                UserId = spResult.UserId,
                FirstName = spResult.FirstName,
                LastName = spResult.LastName,
                SectionName = spResult.SectionName,
                StructureName = spResult.StructureName,
                IsActive = spResult.IsActive,
                CanLogin = spResult.CanLogin,

                // Status int? olduğuna görə cast eləmək lazımdır
                // əgər null gəlirsə false kimi götürürük
                Status = spResult.Status
            };

            // 3. UserPage doldur
            userLogin.UserPage = GetUserPages(userLogin.UserId, 0);

            // 4. Nəticəni qaytar
            return userLogin;
        }

        private List<UserPage> GetUserPages(int userId, int underPageId)
        {
            List<UserPage> pages = _ctx.UserPage
                .FromSqlRaw("EXEC dbo.UserPages @p0, @p1",
                    userId,
                    underPageId)
                .ToList();

            foreach (UserPage? page in pages)
            {
                // PageId-ni növbəti səviyyə üçün UnderPageId kimi göndəririk
                List<UserPage> childPages = GetUserPages(userId, page.PageId ?? 0);

                page.UserPages = childPages;
            }

            return pages;
        }

    }
}