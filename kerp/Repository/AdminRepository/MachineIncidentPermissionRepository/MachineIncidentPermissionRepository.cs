using kerp.Contexts;
using kerp.Prosedur.Admin.Permission.MachineIncidentPermission;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.MachineIncidentPermissionRepository
{
    public class MachineIncidentPermissionRepository(KerpContext ctx) : IMachineIncidentPermissionRepository
    {
        private readonly KerpContext _ctx = ctx;
        public MachineIncidentPermissionSelect? Update(
            MachineIncidentPermissionUpdate request)
        {
            return _ctx.MachineIncidentPermissionSelect
                .FromSqlRaw(
        "EXEC dbo.MachineIncidentPermissionUpdate @p0, @p1, @p2, @p3",
        request.UserId,
        request.OperatorUserId,
        request.Check,
        request.EnumType

                )
                .AsEnumerable()
                .FirstOrDefault();
        }

        public List<MachineIncidentPermissionSelect>? Select()
        {
            return [.. _ctx.MachineIncidentPermissionSelect.FromSqlRaw(
          "EXEC dbo.MachineIncidentPermissionSelect "
          )];
        }
    }
}
