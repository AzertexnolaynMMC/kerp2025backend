using kerp.Contexts;
using kerp.Prosedur.MachineIncidentReport;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.MachineIncidentReportRepository
{
    public class MachineIncidentReportRepository(KerpContext ctx) : IMachineIncidentReportRepository
    {
        private readonly KerpContext _ctx = ctx;

        public List<MachineIncidentReportSelect>? MachineIncidentReportSelect(int Year, int month)
        {
            // 1. Ana sorğu
            var list = ExecuteList<MachineIncidentReportSelect>(
                "EXEC dbo.MachineIncidentReportSelect @p0, @p1", Year, month);

            if (list == null || list.Count == 0) return list;

            // 2. Bütün IncidentId-ləri bir string-ə topla
            var ids = string.Join(",", list.Select(x => x.IncidentId).Distinct());

            // 3. Bütün sub-dataları bir dəfəyə çək
            var crashTypes = ExecuteList<MachineIncidentReportCrashTypeSelect>(
                "EXEC dbo.MachineIncidentReportCrashTypeSelect @p0", ids);

            var sections = ExecuteList<MachineIncidentReportSectionSelect>(
                "EXEC dbo.MachineIncidentReportSectionSelect @p0", ids);

            var structures = ExecuteList<MachineIncidentReportStructureSelect>(
                "EXEC dbo.MachineIncidentReportStructureSelect @p0", ids);

            var workOrders = ExecuteList<MachineIncidentReportWorkOrderTypeSelect>(
                "EXEC dbo.MachineIncidentReportWorkOrderTypeSelect @p0", ids);

            var workShifts = ExecuteList<MachineIncidentReportWorkShiftSelect>(
                "EXEC dbo.MachineIncidentReportWorkShiftSelect @p0", ids);

            // 4. CrashId-ə görə grupla
            var crashTypesMap = crashTypes?.GroupBy(x => x.CrashId)
                                           .ToDictionary(g => g.Key, g => g.ToList());

            var sectionsMap = sections?.GroupBy(x => x.CrashId)
                                       .ToDictionary(g => g.Key, g => g.ToList());

            var structuresMap = structures?.GroupBy(x => x.CrashId)
                                           .ToDictionary(g => g.Key, g => g.ToList());

            var workOrdersMap = workOrders?.GroupBy(x => x.CrashId)
                                           .ToDictionary(g => g.Key, g => g.ToList());

            // WorkShift tək object olduğu üçün birbaşa Dictionary
            var workShiftsMap = workShifts?.ToDictionary(x => x.CrashId);

            // 5. Hər item-ə öz datasını yapışdır
            foreach (var item in list)
            {
                item.MachineIncidentReportCrashTypeSelect =
                    crashTypesMap?.GetValueOrDefault(item.IncidentId);

                item.MachineIncidentReportSectionSelect =
                    sectionsMap?.GetValueOrDefault(item.IncidentId);

                item.MachineIncidentReportStructureSelect =
                    structuresMap?.GetValueOrDefault(item.IncidentId);

                item.MachineIncidentReportWorkOrderTypeSelect =
                    workOrdersMap?.GetValueOrDefault(item.IncidentId);

                item.MachineIncidentReportWorkShiftSelect =
                    workShiftsMap?.GetValueOrDefault(item.IncidentId);
            }

            return list;
        }

        public List<MachineIncidentReportYear>? MachineIncidentReportYear()
        {
            return ExecuteList<MachineIncidentReportYear>(
                "EXEC dbo.MachineIncidentReportYear");
        }

        private List<T>? ExecuteList<T>(string sql, params object[] parameters) where T : class
        {
            return [.. _ctx.Set<T>()
                           .FromSqlRaw(sql, parameters)
                           .AsNoTracking()
                           .AsEnumerable()];
        }

        private List<T>? ExecuteList<T>(string sql) where T : class
        {
            return [.. _ctx.Set<T>()
                           .FromSqlRaw(sql)
                           .AsNoTracking()
                           .AsEnumerable()];
        }
    }
}