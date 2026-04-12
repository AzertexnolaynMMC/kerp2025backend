using kerp.Contexts;
using kerp.Prosedur.Pm.PMChecklistTemplate;
using kerp.Prosedur.Pm.PmGroup;
using kerp.Prosedur.Pm.PMSchedule;
using kerp.Prosedur.Pm.PMScheduleAssignees;
using kerp.Prosedur.Pm.PMScheduleStructure;
using kerp.Prosedur.Pm.PMScheduleWorkOrderType;
using kerp.Prosedur.PM.PMScheduleAsset;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace kerp.Repository.PMRepository
{
    public class PMRepository(KerpContext ctx) : IPMRepository
    {
        private readonly KerpContext _ctx = ctx;

        #region Group
        public List<PMChecklistGroupSelect>? GetGroup()
        {
            return ExecuteList<PMChecklistGroupSelect>(
                "EXEC dbo.PMChecklistGroupSelect"
            );
        }

        public PMChecklistGroupSelect? PostGroup(PMChecklistGroupInsert request)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return ExecuteSingle<PMChecklistGroupSelect>(
                "EXEC dbo.PMChecklistGroupInsert @p0, @p1",
                request.GroupName,
                request.UserId
            );
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public PMChecklistGroupSelect? PutGroup(PMChecklistGroupUpdate request)
        {
            return ExecuteSingle<PMChecklistGroupSelect>(
                "EXEC dbo.PMChecklistGroupUpdate @p0, @p1, @p2",
                request.Id,
                request.GroupName,
                request.UserId
            );
        }

        public PMChecklistGroupSelect? StatusUpdateGroup(PMChecklistGroupStatusUpdate request)
        {
            return ExecuteSingle<PMChecklistGroupSelect>(
                "EXEC dbo.PMChecklistGroupStatusUpdate @p0, @p1",
                request.Id,
                request.UserId
            );
        }
        #endregion

        #region Template
        public List<PMChecklistTemplateSelect>? GetTemplate(int groupId)
        {
            return ExecuteList<PMChecklistTemplateSelect>(
                "EXEC dbo.PMChecklistTemplateSelect @p0",
                groupId
            );
        }

        public PMChecklistTemplateSelect? PostTemplate(PMChecklistTemplateInsert request)
        {
            return ExecuteSingle<PMChecklistTemplateSelect>(
                "EXEC dbo.PMChecklistTemplateInsert @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8",
                request.GroupId,
                request.ItemName,
                request.ResponseType,
                request.IsRequired,  // ← bool → int
                request.ExpectedValue ?? (object)DBNull.Value,
                request.MinValue ?? (object)DBNull.Value,
                request.MaxValue ?? (object)DBNull.Value,
                request.OutOfRangeAction ?? (object)DBNull.Value,
                request.UserId
            );
        }

        public PMChecklistTemplateSelect? PutTemplate(PMChecklistTemplateUpdate request)
        {
            return ExecuteSingle<PMChecklistTemplateSelect>(
                "EXEC dbo.PMChecklistTemplateUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9",
                request.Id,
                request.GroupId,
                request.ItemName,
                request.ResponseType,
                request.IsRequired,
                request.ExpectedValue ?? (object)DBNull.Value,
                request.MinValue ?? (object)DBNull.Value,
                request.MaxValue ?? (object)DBNull.Value,
                request.OutOfRangeAction ?? (object)DBNull.Value,
                request.UserId
            );
        }

        public PMChecklistTemplateSelect? StatusUpdateTemplate(PMChecklistTemplateStatusUpdate request)
        {
            return ExecuteSingle<PMChecklistTemplateSelect>(
                "EXEC dbo.PMChecklistTemplateStatusUpdate @p0, @p1",
                request.Id,
                request.UserId
            );
        }

        public List<PMChecklistTemplateSelect>? ReorderTemplate(PMChecklistTemplateReorderRequest request)
        {
            string json = JsonSerializer.Serialize(request.Items);
            return ExecuteList<PMChecklistTemplateSelect>(
                "EXEC dbo.PMChecklistTemplateReorder @p0, @p1, @p2",
                request.GroupId,
                json,
                request.UserId
            );
        }
        #endregion



        public List<PMScheduleStructureSelect>? GetScheduleStructures(int pmScheduleId)
        {
            return ExecuteList<PMScheduleStructureSelect>(
                "EXEC dbo.PMScheduleStructureSelect @p0",
                pmScheduleId
            );
        }

        public PMScheduleStructureSelect? InsertScheduleStructure(PMScheduleStructureInsert request)
        {
            return ExecuteSingle<PMScheduleStructureSelect>(
                "EXEC dbo.PMScheduleStructureInsert @p0, @p1, @p2",
                request.PMScheduleId,
                request.StructureId,
                request.UserId
            );
        }

        public PMScheduleStructureSelect? UpdateScheduleStructure(PMScheduleStructureUpdate request)
        {
            return ExecuteSingle<PMScheduleStructureSelect>(
                "EXEC dbo.PMScheduleStructureUpdate @p0, @p1, @p2",
                request.Id,
                request.StructureId,
                request.UserId
            );
        }

        public List<PMScheduleWorkOrderTypeSelect>? GetScheduleWorkOrderTypes(int pmScheduleId)
        {
            return ExecuteList<PMScheduleWorkOrderTypeSelect>(
                "EXEC dbo.PMScheduleWorkOrderTypeSelect @p0",
                pmScheduleId
            );
        }

        public List<PMScheduleWorkOrderTypeSelectMulti>? GetPMScheduleWorkOrderTypeSelectMulti()
        {
            return ExecuteList<PMScheduleWorkOrderTypeSelectMulti>(
                "EXEC dbo.PMScheduleWorkOrderTypeSelectMulti"
            );
        }
        public PMScheduleWorkOrderTypeSelect? InsertScheduleWorkOrderType(PMScheduleWorkOrderTypeInsert request)
        {
            return ExecuteSingle<PMScheduleWorkOrderTypeSelect>(
                "EXEC dbo.PMScheduleWorkOrderTypeInsert @p0, @p1, @p2",
                request.PMScheduleId,
                request.WorkOrderTypeId,
                request.UserId
            );
        }

        public PMScheduleWorkOrderTypeSelect? UpdateScheduleWorkOrderType(PMScheduleWorkOrderTypeUpdate request)
        {
            return ExecuteSingle<PMScheduleWorkOrderTypeSelect>(
                "EXEC dbo.PMScheduleWorkOrderTypeUpdate @p0, @p1, @p2",
                request.Id,
                request.WorkOrderTypeId,
                request.UserId
            );
        }


        public List<PMScheduleAssigneesSelect>? GetScheduleAssignees(int pmScheduleId)
        {
            return ExecuteList<PMScheduleAssigneesSelect>(
                "EXEC dbo.PMScheduleAssigneesSelect @p0",
                pmScheduleId
            );
        }

        public PMScheduleAssigneesSelect? InsertScheduleAssignee(PMScheduleAssigneesInsert request)
        {
            return ExecuteSingle<PMScheduleAssigneesSelect>(
                "EXEC dbo.PMScheduleAssigneesInsert @p0, @p1, @p2, @p3",
                request.PmScheduleId,
                request.UserId,
                request.Role ?? (object)DBNull.Value,
                request.CreatedBy
            );
        }

        public PMScheduleAssigneesSelect? RoleUpdateScheduleAssignee(PMScheduleAssigneesRoleUpdate request)
        {
            return ExecuteSingle<PMScheduleAssigneesSelect>(
                "EXEC dbo.PMScheduleAssigneesRoleUpdate @p0, @p1, @p2",
                request.Id,
                request.Role,
                request.UserId
            );
        }

        public PMScheduleAssigneesSelect? StatusUpdateScheduleAssignee(PMScheduleAssigneesStatusUpdate request)
        {
            return ExecuteSingle<PMScheduleAssigneesSelect>(
                "EXEC dbo.PMScheduleAssigneesStatusUpdate @p0, @p1",
                request.Id,
                request.UserId
            );
        }


        public List<PMScheduleAssigneesSelect>? InsertScheduleAssignees(List<PMScheduleAssigneesInsert> request)
        {
            foreach (PMScheduleAssigneesInsert item in request)
            {
                _ = InsertScheduleAssignee(item);
            }
            return GetScheduleAssignees(request.First().PmScheduleId);
        }

        public List<PMScheduleSelect>? GetSchedules(string structureId)
        {
            List<PMScheduleSelect>? schedules = ExecuteList<PMScheduleSelect>(
                "EXEC dbo.PMScheduleSelect @p0",
                structureId
            );

            if (schedules == null)
            {
                return null;
            }

            foreach (PMScheduleSelect schedule in schedules)
            {
                schedule.PMScheduleStructureSelect = GetScheduleStructures(schedule.Id);
                schedule.PMScheduleWorkOrderTypeSelect = GetScheduleWorkOrderTypes(schedule.Id);
                schedule.PMScheduleAssigneesSelect = GetScheduleAssignees(schedule.Id);
                schedule.PMScheduleAssetSelect = GetScheduleAssets(schedule.Id);
            }

            return schedules;
        }

        public PMScheduleSelect? InsertSchedule(PMScheduleInsert request)
        {
            PMScheduleSelect? schedule = ExecuteSingle<PMScheduleSelect>(
                "EXEC dbo.PMScheduleInsert @p0, @p1, @p2, @p3, @p4, @p5",
                request.GroupId,
                request.FrequencyDays,
                request.Title,
                request.UserId,
                request.RecommendedCondition ?? (object)DBNull.Value,
                request.NextDueDate ?? (object)DBNull.Value
            );

            if (schedule == null)
            {
                return null;
            }

            if (request.PMScheduleStructureInsert != null)
            {
                request.PMScheduleStructureInsert.PMScheduleId = schedule.Id;
                _ = InsertScheduleStructure(request.PMScheduleStructureInsert);
            }

            if (request.PMScheduleWorkOrderTypeInsert != null)
            {
                request.PMScheduleWorkOrderTypeInsert.PMScheduleId = schedule.Id;
                _ = InsertScheduleWorkOrderType(request.PMScheduleWorkOrderTypeInsert);
            }

            if (request.PMScheduleAssigneesInsert != null && request.PMScheduleAssigneesInsert.Any())
            {
                foreach (PMScheduleAssigneesInsert assignee in request.PMScheduleAssigneesInsert)
                {
                    assignee.PmScheduleId = schedule.Id;
                    _ = InsertScheduleAssignee(assignee);
                }
            }

            if (request.PMScheduleAssetInsert != null && request.PMScheduleAssetInsert.Any())
            {
                foreach (PMScheduleAssetInsert asset in request.PMScheduleAssetInsert)
                {
                    asset.PmScheduleId = schedule.Id;     // 🔥 burada set edirik
                    asset.UserId = request.UserId;        // 🔥 burada set edirik

                    _ = InsertScheduleAsset(asset);
                }
            }

            schedule.PMScheduleStructureSelect = GetScheduleStructures(schedule.Id);
            schedule.PMScheduleWorkOrderTypeSelect = GetScheduleWorkOrderTypes(schedule.Id);
            schedule.PMScheduleAssigneesSelect = GetScheduleAssignees(schedule.Id);
            schedule.PMScheduleAssetSelect = GetScheduleAssets(schedule.Id);
            return schedule;
        }

        public PMScheduleSelect? UpdateSchedule(PMScheduleUpdate request)
        {
            PMScheduleSelect? schedule = ExecuteSingle<PMScheduleSelect>(
                "EXEC dbo.PMScheduleUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6",
                request.Id,
                request.GroupId,
                request.FrequencyDays,
                request.Title,
                request.UserId,
                request.RecommendedCondition ?? (object)DBNull.Value,
                request.NextDueDate ?? (object)DBNull.Value
            );

            if (schedule == null)
            {
                return null;
            }

            schedule.PMScheduleStructureSelect = GetScheduleStructures(schedule.Id);
            schedule.PMScheduleWorkOrderTypeSelect = GetScheduleWorkOrderTypes(schedule.Id);
            schedule.PMScheduleAssigneesSelect = GetScheduleAssignees(schedule.Id);
            schedule.PMScheduleAssetSelect = GetScheduleAssets(schedule.Id);

            return schedule;
        }

        public PMScheduleSelect? StatusUpdateSchedule(PMScheduleStatusUpdate request)
        {
            PMScheduleSelect? schedule = ExecuteSingle<PMScheduleSelect>(
                "EXEC dbo.PMScheduleStatusUpdate @p0, @p1",
                request.Id,
                request.UserId
            );

            if (schedule == null)
            {
                return null;
            }

            schedule.PMScheduleStructureSelect = GetScheduleStructures(schedule.Id);
            schedule.PMScheduleWorkOrderTypeSelect = GetScheduleWorkOrderTypes(schedule.Id);
            schedule.PMScheduleAssigneesSelect = GetScheduleAssignees(schedule.Id);

            return schedule;
        }
        #region Helpers
        private T? ExecuteSingle<T>(string sql, params object[] parameters) where T : class
        {
            return _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()
                       .FirstOrDefault();
        }

        private List<T>? ExecuteList<T>(string sql) where T : class
        {
            return [.. _ctx.Set<T>()
                       .FromSqlRaw(sql)
                       .AsNoTracking()
                       .AsEnumerable()];
        }

        private List<T>? ExecuteList<T>(string sql, params object[] parameters) where T : class
        {
            return [.. _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()];
        }
        #endregion

        #region PMScheduleAsset

        public List<PMScheduleAssetSelect>? GetScheduleAssets(int pmScheduleId)
        {
            return ExecuteList<PMScheduleAssetSelect>(
                "EXEC dbo.PMScheduleAssetSelect @p0",
                pmScheduleId
            );
        }

        public PMScheduleAssetSelect? InsertScheduleAsset(PMScheduleAssetInsert request)
        {
            return ExecuteSingle<PMScheduleAssetSelect>(
                "EXEC dbo.PMScheduleAssetInsert @p0, @p1, @p2",
                request.PmScheduleId,
                request.AssetId,
                request.UserId
            );
        }

        public PMScheduleAssetSelect? UpdateScheduleAsset(PMScheduleAssetUpdate request)
        {
            return ExecuteSingle<PMScheduleAssetSelect>(
                "EXEC dbo.PMScheduleAssetUpdate @p0, @p1, @p2",
                request.Id,
                request.AssetId,
                request.UserId
            );
        }

        public PMScheduleAssetSelect? StatusUpdateScheduleAsset(PMScheduleAssetStatus request)
        {
            return ExecuteSingle<PMScheduleAssetSelect>(
                "EXEC dbo.PMScheduleAssetStatus @p0, @p1",
                request.Id,
                request.UserId
            );
        }

        #endregion

    }
}