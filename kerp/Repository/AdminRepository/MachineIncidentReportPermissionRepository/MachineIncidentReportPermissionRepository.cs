using kerp.Contexts;
using kerp.Prosedur.Admin.Permission.MachineIncidentReportPermission;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.MachineIncidentReportPermissionRepository
{
    public class MachineIncidentReportPermissionRepository(KerpContext ctx) : IMachineIncidentReportPermissionRepository
    {
        private readonly KerpContext _ctx = ctx;

        public MachineIncidentReportPermissionSelect? Update(MachineIncidentReportPermissionUpdate request)
        {
            return _ctx.MachineIncidentReportPermissionSelect
                .FromSqlRaw(
                    "EXEC dbo.MachineIncidentReportPermissionUpdate @p0, @p1, @p2, @p3",
                    request.UserId,
                    request.OperatorUserId,
                    request.Check,
                    request.EnumType
                )
                .AsEnumerable()
                .FirstOrDefault();
        }

        public List<MachineIncidentReportPermissionSelect>? Select()
        {
            return [.. _ctx.MachineIncidentReportPermissionSelect
                .FromSqlRaw("EXEC dbo.MachineIncidentReportPermissionSelect")];
        }
    }
}
