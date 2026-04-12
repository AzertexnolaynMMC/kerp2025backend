using kerp.Contexts;
using kerp.Prosedur.Admin.Permission.PMOrderPermission;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.PMOrderPermissionRepository
{
    public class PMOrderPermissionRepository(KerpContext ctx) : IPMOrderPermissionRepository
    {
        private readonly KerpContext _ctx = ctx;

        public List<PMOrderPermissionSelect>? Select()
        {
            return [.. _ctx.PMOrderPermissionSelect.FromSqlRaw(
                "EXEC dbo.PMOrderPermissionSelect"
            )];
        }

        public PMOrderPermissionSelect? Update(PMOrderPermissionUpdate request)
        {
            return _ctx.PMOrderPermissionSelect
                .FromSqlRaw(
                    "EXEC dbo.PMOrderPermissionUpdate @p0, @p1, @p2, @p3",
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