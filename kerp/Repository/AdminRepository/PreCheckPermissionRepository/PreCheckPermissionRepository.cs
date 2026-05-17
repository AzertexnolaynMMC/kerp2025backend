using kerp.Contexts;
using kerp.Prosedur.Admin.Permission.PreCheckPermission;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.PreCheckPermissionRepository
{
    public class PreCheckPermissionRepository(KerpContext ctx) : IPreCheckPermissionRepository
    {
        private readonly KerpContext _ctx = ctx;

        public PreCheckPermissionSelect? Update(
            PreCheckPermissionUpdate request)
        {
            return _ctx.PreCheckPermissionSelect
                .FromSqlRaw(
                    "EXEC dbo.PreCheckPermissionUpdate @p0, @p1, @p2, @p3",
                    request.UserId,
                    request.OperatorUserId,
                    request.Check,
                    request.EnumType
                )
                .AsEnumerable()
                .FirstOrDefault();
        }

        public List<PreCheckPermissionSelect>? Select()
        {
            return [.. _ctx.PreCheckPermissionSelect.FromSqlRaw(
                "EXEC dbo.PreCheckPermissionSelect "
            )];
        }
    }
}