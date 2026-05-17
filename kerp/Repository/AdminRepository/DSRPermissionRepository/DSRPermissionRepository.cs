using kerp.Contexts;
using kerp.Prosedur.Admin.Permission.DSRPermission;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.DSRPermissionRepository
{
    public class DSRPermissionRepository(KerpContext ctx) : IDSRPermissionRepository
    {
        private readonly KerpContext _ctx = ctx;

        public DSRPermissionSelect? Update(
            DSRPermissionUpdate request)
        {
            return _ctx.DSRPermissionSelect
                .FromSqlRaw(
        "EXEC dbo.DSRPermissionUpdate @p0, @p1, @p2, @p3",
        request.UserId,
        request.OperatorUserId,
        request.Check,
        request.EnumType

                )
                .AsEnumerable()
                .FirstOrDefault();
        }

        public List<DSRPermissionSelect>? Select()
        {
            return [.. _ctx.DSRPermissionSelect.FromSqlRaw(
          "EXEC dbo.DSRPermissionSelect "
          )];
        }
    }
}
