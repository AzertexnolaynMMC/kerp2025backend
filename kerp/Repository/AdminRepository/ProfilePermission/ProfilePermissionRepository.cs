using kerp.Contexts;
using kerp.Prosedur.Admin.Permission.ProfilePermission;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.ProfilePermission
{
    public class ProfilePermissionRepository(KerpContext ctx) : IProfilePermissionRepository
    {
        private readonly KerpContext _ctx = ctx;
        public List<ProfilePermissionSelect>? Select()
        {
            return [.. _ctx.ProfilePermissionSelect.FromSqlRaw(
          "EXEC dbo.ProfilePermissionSelect "
          )];
        }

        public ProfilePermissionSelect? Update(ProfilePermissionUpdate request)
        {
            return _ctx.ProfilePermissionSelect
    .FromSqlRaw(
"EXEC dbo.ProfilePermissionUpdate @p0, @p1, @p2, @p3",
request.UserId,
request.OperatorUserId,
request.Check,
request.EnumType

    )
    .AsEnumerable()
    .FirstOrDefault();
        }
    }
}
