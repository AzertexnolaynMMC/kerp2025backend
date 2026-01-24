using kerp.Contexts;
using kerp.Prosedur.Admin.Logs;
using kerp.Prosedur.Users;
using kerp.Prosedur.Users.Asset;
using kerp.Prosedur.Users.Employer;
using kerp.Prosedur.Users.Login;
using kerp.Prosedur.Users.Mail;
using kerp.Prosedur.Users.phone;
using kerp.Prosedur.Users.UserPages;
using kerp.SystemModel;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.UserRepository
{
    public class UserRepository(KerpContext ctx) : IUserRepository
    {
        private readonly KerpContext _ctx = ctx;
        public int? AppLogsInsert(List<AppLogsInsert> model)
        {
            try
            {
                foreach (AppLogsInsert item in model)
                {
                    AppLog userLogin = _ctx.AppLog.FromSqlRaw(
           "EXEC dbo.AppLogsInsert @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17",
           item.UserId,
           item.TimestampUtc,
           item.Level,
           item.Message,
           item.Env,
           item.Service,
           item.Logger,
           item.AppVersion,
           item.Host,
           item.TraceId,
           item.SpanId,
           item.RequestId,
           item.UserJson,
           item.HttpJson,
           item.BusinessJson,
           item.ErrorJson,
           item.SystemJson,
           item.ExtraJson
       ).AsEnumerable().FirstOrDefault();
                }
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public UserSelectMailSingle? DeleteUserStatusMailSingle(UserStatusMailSingle StructureStatus)
        {
            return _ctx.UserSelectMailSingle.FromSqlRaw(
                "EXEC dbo.UserStatusMailSingle @p0, @p1, @p2",
                StructureStatus.Id,
                StructureStatus.Status,
                StructureStatus.UserId
            ).AsNoTracking().AsEnumerable().FirstOrDefault();
        }
        public UserPhoneInfoSelect? DeleteUserStatusPhoneSingle(UserStatusPhoneSingle StructureStatus)
        {
            return _ctx.UserPhoneInfoSelect.FromSqlRaw(
     "EXEC dbo.UserStatusPhoneSingle @p0, @p1, @p2",
     StructureStatus.Id,
     StructureStatus.Status,
     StructureStatus.UserId
 ).AsNoTracking().AsEnumerable().FirstOrDefault();
        }
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
                userLogin.UserMailInfoSelect = [.. _ctx.UserMailInfoSelect.FromSqlRaw("EXEC dbo.UserMailInfoSelect @p0", userLogin.UserId)];
                userLogin.UserManagerEmployeSelect = [.. _ctx.UserManagerEmployeSelect.FromSqlRaw("EXEC dbo.UserManagerEmployeSelect @p0", userLogin.UserId)];
                userLogin.UserUserConMachineSelect = [.. _ctx.UserUserConMachineSelect.FromSqlRaw("EXEC dbo.UserUserConMachineSelect @p0", userLogin.UserId)];
                userLogin.UserUserLoginsSelect = [.. _ctx.UserUserLoginsSelect.FromSqlRaw("EXEC dbo.UserUserLoginsSelect @p0", userLogin.UserId)];
                userLogin.UserPhoneInfoSelect = [.. _ctx.UserPhoneInfoSelect.FromSqlRaw("EXEC dbo.UserPhoneInfoSelect @p0", userLogin.UserId)];
                userLogin.UserLoginStructureSelect = [.. _ctx.UserLoginStructureSelect.FromSqlRaw("EXEC dbo.UserLoginStructureSelect @p0", userLogin.UserId)];
                userLogin.UserLoginWorkOrderSelect = [.. _ctx.UserLoginWorkOrderSelect.FromSqlRaw("EXEC dbo.UserLoginWorkOrderSelect @p0", userLogin.UserId)];
            }

            return userLogin;
        }
        public UserSelectMailSingle? PostUserInsertMailSingle(UserInsertMailSingle pageInsert)
        {
            return pageInsert == null || string.IsNullOrWhiteSpace(pageInsert.Title)
                ? null
                : TitleExistsMail(pageInsert.Title)
                ? null
                : _ctx.UserSelectMailSingle
                .FromSqlRaw("EXEC dbo.UserInsertMailSingle @p0, @p1",
                    pageInsert.Title,
                    pageInsert.UserId
                )
                .AsNoTracking()
                .AsEnumerable()
                .FirstOrDefault();
        }
        public UserPhoneInfoSelect? PostUserInsertPhoneSingle(UserInsertPhoneSingle pageInsert)
        {
            return pageInsert == null || string.IsNullOrWhiteSpace(pageInsert.Title)
                ? null
                : TitleExistsPhone(pageInsert.Title)
                ? null
                : _ctx.UserPhoneInfoSelect
                .FromSqlRaw("EXEC dbo.UserInsertPhoneSingle @p0, @p1",
            pageInsert.Title,
                    pageInsert.UserId
                )
                .AsNoTracking()
                .AsEnumerable()
                .FirstOrDefault();
        }
        public UserSelectMailSingle? PutUserUpdateMailSingle(UserUpdateMailSingle structureUpdate)
        {
            return structureUpdate == null || string.IsNullOrWhiteSpace(structureUpdate.Title)
                ? null
                : TitleExistsMail(structureUpdate.Title, structureUpdate.Id)
                ? null
                : _ctx.UserSelectMailSingle
                .FromSqlRaw("EXEC dbo.UserUpdateMailSingle @p0, @p1, @p2",
                    structureUpdate.Title,
                    structureUpdate.UserId,
                    structureUpdate.Id
                )
                .AsNoTracking()
                .AsEnumerable()
                .FirstOrDefault();
        }
        public UserPhoneInfoSelect? PutUserUpdatePhoneSingle(UserUpdatePhoneSingle structureUpdate)
        {
            return structureUpdate == null || string.IsNullOrWhiteSpace(structureUpdate.Title)
                ? null
                : TitleExistsPhone(structureUpdate.Title, structureUpdate.Id)
            ? null
                : _ctx.UserPhoneInfoSelect
                .FromSqlRaw("EXEC dbo.UserUpdatePhoneSingle @p0, @p1, @p2",
            structureUpdate.Title,
                    structureUpdate.UserId,
                    structureUpdate.Id
                )
                .AsNoTracking()
                .AsEnumerable()
                .FirstOrDefault();
        }
        public UserSelectShortInfo? UserNameSurnamePositionUpdate(UserNameSurnamePositionUpdate model)
        {
            return _ctx.UserSelectShortInfo.FromSqlRaw(
      "EXEC dbo.UserNameSurnamePositionUpdate @p0, @p1, @p2, @p3",
      model.FirstName,
      model.LastName,
      model.Position,
      model.UserId
  ).AsEnumerable().FirstOrDefault();
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
                Position = spResult.Position,
                StructureId = spResult.StructureId,
                SectionId = spResult.SectionId,


                // Status int? olduğuna görə cast eləmək lazımdır
                // əgər null gəlirsə false kimi götürürük
                Status = spResult.Status
            };

            // 3. UserPage doldur
            userLogin.UserPage = GetUserPages(userLogin.UserId, 0);
            userLogin.UserMailInfoSelect = [.. _ctx.UserMailInfoSelect.FromSqlRaw("EXEC dbo.UserMailInfoSelect @p0", userLogin.UserId)];
            userLogin.UserManagerEmployeSelect = [.. _ctx.UserManagerEmployeSelect.FromSqlRaw("EXEC dbo.UserManagerEmployeSelect @p0", userLogin.UserId)];
            userLogin.UserUserConMachineSelect = [.. _ctx.UserUserConMachineSelect.FromSqlRaw("EXEC dbo.UserUserConMachineSelect @p0", userLogin.UserId)];
            userLogin.UserUserLoginsSelect = [.. _ctx.UserUserLoginsSelect.FromSqlRaw("EXEC dbo.UserUserLoginsSelect @p0", userLogin.UserId)];
            userLogin.UserPhoneInfoSelect = [.. _ctx.UserPhoneInfoSelect.FromSqlRaw("EXEC dbo.UserPhoneInfoSelect @p0", userLogin.UserId)];
            userLogin.UserLoginStructureSelect = [.. _ctx.UserLoginStructureSelect.FromSqlRaw("EXEC dbo.UserLoginStructureSelect @p0", userLogin.UserId)];
            userLogin.UserLoginWorkOrderSelect = [.. _ctx.UserLoginWorkOrderSelect.FromSqlRaw("EXEC dbo.UserLoginWorkOrderSelect @p0", userLogin.UserId)];
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

                page.UserPagess = childPages;
            }

            return pages;
        }
        private bool TitleExistsMail(string title, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return false;
            }

            string normalized = title.Trim();

            List<UserSelectMailCheck> checkList = _ctx.UserSelectMailCheck
                .FromSqlRaw("EXEC dbo.UserSelectMailCheck")
                .AsNoTracking()
                .AsEnumerable()
                .ToList();

            return checkList.Any(x =>
                !string.IsNullOrWhiteSpace(x.Title) &&
                string.Equals(x.Title.Trim(), normalized, StringComparison.OrdinalIgnoreCase) &&
                (!excludeId.HasValue || x.Id != excludeId.Value)
            );
        }
        private static string? NormalizeAzPhone(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            // yalnız rəqəmlər
            string digits = string.Concat(input.Where(char.IsDigit));
            if (digits.Length == 0)
            {
                return null;
            }

            // bəzən 00 ilə yazırlar: 00994...
            if (digits.StartsWith("00"))
            {
                digits = digits[2..];
            }

            // (051...) və ya 051... -> 99451...
            if (digits.Length == 10 && digits.StartsWith("0"))
            {
                digits = "994" + digits[1..];
            }

            // 9 rəqəm (512521254) -> 994512521254
            if (digits.Length == 9)
            {
                digits = "994" + digits;
            }

            // Artıq 994 ilə gəlirsə (994XXXXXXXXX) saxla
            // Digər halları da olduğu kimi qaytarırıq (istəsən burada sərtləşdirə bilərsən)
            return digits;
        }
        private bool TitleExistsPhone(string title, int? excludeId = null)
        {
            string? normalized = NormalizeAzPhone(title);
            if (normalized is null)
            {
                return false;
            }

            List<UserSelectPhoneCheck> checkList = _ctx.UserSelectPhoneCheck
                .FromSqlRaw("EXEC dbo.UserSelectPhoneCheck")
                .AsNoTracking()
                .ToList();

            return checkList.Any(x =>
            {
                if (excludeId.HasValue && x.Id == excludeId.Value)
                {
                    return false;
                }

                string? other = NormalizeAzPhone(x.Title);
                return other != null && other == normalized; // artıq digits-only, Ordinal kifayətdir
            });
        }







        public UserSelectConMachineSingle? DeleteUserStatusConMachineSingle(UserStatusConMachineSingle StructureStatus)
        {
            return _ctx.UserSelectConMachineSingle.FromSqlRaw(
"EXEC dbo.UserConMachineStatus @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.UserId,
StructureStatus.Status

).ToList().FirstOrDefault();
        }

        public UserSelectConMachineSingle? PostUserInsertConMachineSingle(UserInsertConMachineSingle PageInsert)
        {
            return _ctx.UserSelectConMachineSingle.FromSqlRaw(
"EXEC dbo.UserInsertConMachineSingle @p0, @p1",
PageInsert.MachineId,
PageInsert.UserId

).ToList().FirstOrDefault();
        }

        public List<UserSelectAssets>? GetUserSelectAssets()
        {
            return [.. _ctx.UserSelectAssets
                .FromSqlRaw("EXEC dbo.UserSelectAssets")
                .AsNoTracking()
];
        }










        public UserSelectEmployerSingle? DeleteUserStatusEmployerSingle(UserStatusEmployerSingle StructureStatus)
        {
            return _ctx.UserSelectEmployerSingle.FromSqlRaw(
"EXEC dbo.UserStatusEmployerSingle @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.UserId,
StructureStatus.Status

).ToList().FirstOrDefault();
        }

        public UserSelectEmployerSingle? PostUserInsertEmployerSingle(UserInsertEmployerSingle PageInsert)
        {
            return _ctx.UserSelectEmployerSingle.FromSqlRaw(
"EXEC dbo.UserInsertEmployerSingle @p0, @p1",
PageInsert.WorkerId,
PageInsert.UserId

).ToList().FirstOrDefault();
        }

        public List<UserSelectEmployerMulti>? GetUserSelectEmployerMulti()
        {
            return [.. _ctx.UserSelectEmployerMulti
                .FromSqlRaw("EXEC dbo.UserSelectEmployerMulti")
                .AsNoTracking()];
        }



        public UserSelectLoginSingle? DeleteUserStatusLoginSingle(UserStatusLoginSingle StructureStatus)
        {
            return _ctx.UserSelectLoginSingle.FromSqlRaw(
"EXEC dbo.UserStatusLoginSingle @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.Status,
StructureStatus.UserId

).ToList().FirstOrDefault();
        }

        public UserSelectLoginSingle? PostUserInsertLoginSingle(UserInsertLoginSingle PageInsert)
        {
            return _ctx.UserSelectLoginSingle.FromSqlRaw(
"EXEC dbo.UserInsertLoginSingle @p0, @p1, @p2, @p3",
PageInsert.Title,
PageInsert.UserId,
PageInsert.LoginTypeId,
PageInsert.Password

).ToList().FirstOrDefault();
        }

        public UserSelectLoginSingle? PutUserUpdateLoginSingle(UserUpdateLoginSingle model)
        {
            return _ctx.UserSelectLoginSingle
                .FromSqlRaw(
                    "EXEC dbo.UserUpdateLoginSingle @p0, @p1, @p2, @p3, @p4",
                    model.Title,
                    model.UserId,
                    model.LoginTypeId,
                    model.Password,
                    model.Id
                )
                .AsNoTracking()
                .ToList()
                .FirstOrDefault();
        }

        public List<UserSelectLoginTypeMulti>? GetUserSelectLoginTypeMulti()
        {
            return [.. _ctx.UserSelectLoginTypeMulti
                .FromSqlRaw("EXEC dbo.UserSelectLoginTypeMulti")
                .AsNoTracking()];
        }



    }
}