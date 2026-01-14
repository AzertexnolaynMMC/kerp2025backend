using kerp.Contexts;
using kerp.Enums;
using kerp.Prosedur.MachineIncident.Event;
using kerp.Prosedur.MachineIncident.Incident;
using kerp.Prosedur.MachineIncident.MachineIncidentWorkShift;
using kerp.Prosedur.MachineIncident.Section;
using kerp.Prosedur.MachineIncident.SelectModels;
using kerp.Prosedur.MachineIncident.Structure;
using kerp.Prosedur.MachineIncident.Type;
using kerp.Prosedur.MachineIncident.WorkOrderType;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.MachineIncidentRepository
{
    public class MachineIncidentRepository : IMachineIncidentRepository
    {
        private readonly KerpContext _ctx;

        public MachineIncidentRepository(KerpContext ctx)
        {
            _ctx = ctx;
        }

        #region Select Multi

        public List<MachineIncidentCrashTypeSelectMulti>? MachineIncidentCrashTypeSelectMulti()
        {
            return ExecuteList<MachineIncidentCrashTypeSelectMulti>(
                "EXEC dbo.MachineIncidentCrashTypeSelectMulti");
        }

        public List<MachineIncidentProjectSelectMulti>? MachineIncidentProjectSelectMulti()
        {
            return ExecuteList<MachineIncidentProjectSelectMulti>(
                "EXEC dbo.MachineIncidentProjectSelectMulti");
        }

        public List<MachineIncidentWorkOrderTypeSelectMulti>? MachineIncidentWorkOrderTypeSelectMulti()
        {
            return ExecuteList<MachineIncidentWorkOrderTypeSelectMulti>(
                "EXEC dbo.MachineIncidentWorkOrderTypeSelectMulti");
        }

        public List<MachineIncidentWorkShiftSelectMulti>? MachineIncidentWorkShiftSelectMulti()
        {
            return ExecuteList<MachineIncidentWorkShiftSelectMulti>(
                "EXEC dbo.MachineIncidentWorkShiftSelectMulti");
        }

        #endregion

        #region Post

        public int Post(List<MachineIncidentInsert> inserts)
        {
            using Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _ctx.Database.BeginTransaction();

            try
            {
                foreach (MachineIncidentInsert item in inserts)
                {
                    MachineIncidentSelectForBackEnd? incident = InsertMachineIncident(item);
                    if (incident == null)
                    {
                        throw new Exception("MachineIncidentInsert failed");
                    }

                    InsertCrashType(incident.Id, item);
                    InsertWorkOrderType(incident.Id, item);
                    InsertSection(incident.Id, item);
                    InsertStructure(incident.Id, item);
                    InsertWorkShift(incident.Id, item);

                    InsertCreatedEvent(incident.Id, item.UserId);
                    InsertAssignedEvent(incident.Id, item.UserId, item.AsigntUserId);
                }

                transaction.Commit();
                return 1;
            }
            catch
            {
                transaction.Rollback();
                return 0;
            }
        }

        #endregion

        #region Insert Methods

        private MachineIncidentSelectForBackEnd? InsertMachineIncident(MachineIncidentInsert item)
        {
            return ExecuteSingle<MachineIncidentSelectForBackEnd>(
                "EXEC dbo.MachineIncidentInsert @p0, @p1, @p2, @p3",
                item.Title,
                item.UserId,
                item.AssetId,
                item.ProjectId
            );
        }

        private void InsertCrashType(int incidentId, MachineIncidentInsert item)
        {
            _ = ExecuteSingle<MachineIncidentCrashTypeSelect>(
                "EXEC dbo.MachineIncidentCrashTypeInsert @p0, @p1, @p2",
                incidentId,
                item.UserId,
                item.MachineIncidentCrashTypeInsert!.CrashTypeId
            );
        }

        private void InsertWorkOrderType(int incidentId, MachineIncidentInsert item)
        {
            _ = ExecuteSingle<MachineIncidentWorkOrderTypeSelect>(
                "EXEC dbo.MachineIncidentWorkOrderTypeInsert @p0, @p1, @p2",
                incidentId,
                item.UserId,
                item.MachineIncidentWorkOrderTypeInsert!.WorkOrderTypeId
            );
        }

        private void InsertSection(int incidentId, MachineIncidentInsert item)
        {
            _ = ExecuteSingle<MachineIncidentSectionSelect>(
                "EXEC dbo.MachineIncidentSectionInsert @p0, @p1, @p2",
                incidentId,
                item.UserId,
                item.MachineIncidentSectionInsert!.SectionId
            );
        }

        private void InsertStructure(int incidentId, MachineIncidentInsert item)
        {
            _ = ExecuteSingle<MachineIncidentStructureSelect>(
                "EXEC dbo.MachineIncidentStructureInsert @p0, @p1, @p2",
                incidentId,
                item.UserId,
                item.MachineIncidentStructureInsert!.StructureId
            );
        }

        private void InsertWorkShift(int incidentId, MachineIncidentInsert item)
        {
            _ = ExecuteSingle<MachineIncidentWorkShiftSelect>(
                "EXEC dbo.MachineIncidentWorkShiftInsert @p0, @p1, @p2",
                incidentId,
                item.UserId,
                item.MachineIncidentWorkShiftInsert!.WorkShiftId
            );
        }

        #endregion

        #region Event Inserts

        private void InsertCreatedEvent(int incidentId, int userId)
        {
            InsertEvent(incidentId, userId, MachineIncidentEventType.Created, userId);
        }

        private void InsertAssignedEvent(int incidentId, int userId, int assignUserId)
        {
            InsertEvent(incidentId, userId, MachineIncidentEventType.Assigned, assignUserId);
        }

        private void InsertEvent(
            int incidentId,
            int userId,
            MachineIncidentEventType eventType,
            int targetUserId)
        {
            _ = ExecuteSingle<MachineIncidentEventSelect>(
                "EXEC dbo.MachineIncidentEventInsert @p0, @p1, @p2, @p3",
                incidentId,
                userId,
                (int)eventType,
                targetUserId
            );
        }

        #endregion

        #region Helpers (FIX BURADADIR)

        private List<T>? ExecuteList<T>(string sql) where T : class
        {
            return _ctx.Set<T>()
                       .FromSqlRaw(sql)
                       .AsNoTracking()
                       .AsEnumerable()   // 🔥 VACİB
                       .ToList();
        }

        private T? ExecuteSingle<T>(string sql, params object[] parameters) where T : class
        {
            return _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()   // 🔥 VACİB
                       .FirstOrDefault();
        }

        #endregion
    }
}
