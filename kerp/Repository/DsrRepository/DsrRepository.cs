using kerp.Contexts;
using kerp.Enums;
using kerp.Prosedur.Dsr.Assistant;
using kerp.Prosedur.Dsr.Chat;
using kerp.Prosedur.Dsr.Document;
using kerp.Prosedur.Dsr.Dsrs;
using kerp.Prosedur.Dsr.DSRTaskType;
using kerp.Prosedur.Dsr.Event;
using kerp.Prosedur.Dsr.LostTime;
using kerp.Prosedur.Dsr.Machine;
using kerp.Prosedur.Dsr.Material;
using kerp.Prosedur.Dsr.Record;
using kerp.Prosedur.Dsr.Section;
using kerp.Prosedur.Dsr.Structure;
using kerp.Prosedur.Dsr.Task;
using kerp.Prosedur.Dsr.TaskComment;
using kerp.Prosedur.Dsr.WorkOrderType;
using kerp.Prosedur.Dsr.WorkShift;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace kerp.Repository.DsrRepository
{
    public class DsrRepository(KerpContext ctx) : IDsrRepository
    {
        private readonly KerpContext _ctx = ctx;

        // =====================================================
        // HELPERS
        // =====================================================
        private T? ExecuteSingle<T>(string sql, params object[] parameters) where T : class
        {
            return _ctx.Set<T>()
                .FromSqlRaw(sql, parameters)
                .AsNoTracking()
                .AsEnumerable()
                .FirstOrDefault();
        }

        private List<T>? ExecuteList<T>(string sql, params object[] parameters) where T : class
        {
            return [.. _ctx.Set<T>()
                .FromSqlRaw(sql, parameters)
                .AsNoTracking()
                .AsEnumerable()];
        }

        private void InsertEvent(int dsrId, int userId, DsrEventType eventType)
        {
            _ = ExecuteSingle<DSREventSelect>(
                "EXEC dbo.DSREventInsert @p0, @p1, @p2, @p3",
                dsrId,
                userId,
                (int)eventType,
                userId
            );
        }

        // =====================================================
        // TASK TYPE
        // =====================================================
        public List<DSRTaskTypeSelectAdmin>? DSRTaskTypeSelectAdmin()
        {
            return ExecuteList<DSRTaskTypeSelectAdmin>(
                "EXEC dbo.DSRTaskTypeSelectAdmin"
            );
        }

        public DSRTaskTypeSelectAdmin? DSRTaskTypeInsert(DSRTaskTypeInsert request)
        {
            return ExecuteSingle<DSRTaskTypeSelectAdmin>(
                "EXEC dbo.DSRTaskTypeInsert @p0, @p1",
                request.Title,
                request.UserId
            );
        }

        public DSRTaskTypeSelectAdmin? DSRTaskTypeUpdate(DSRTaskTypeUpdate request)
        {
            return ExecuteSingle<DSRTaskTypeSelectAdmin>(
                "EXEC dbo.DSRTaskTypeUpdate @p0, @p1, @p2",
                request.Id,
                request.Title,
                request.UserId
            );
        }

        public DSRTaskTypeSelectAdmin? DSRTaskTypeStatus(DSRTaskTypeStatus request)
        {
            return ExecuteSingle<DSRTaskTypeSelectAdmin>(
                "EXEC dbo.DSRTaskTypeStatus @p0, @p1",
                request.Id,
                request.UserId
            );
        }

        // =====================================================
        // WORK ORDER TYPE
        // =====================================================
        public List<DSRWorkOrderTypeSelectMulti>? DSRWorkOrderTypeSelectMulti()
        {
            return ExecuteList<DSRWorkOrderTypeSelectMulti>(
                "EXEC dbo.DSRWorkOrderTypeSelectMulti"
            );
        }

        public List<DSRWorkOrderTypeSelect>? DSRWorkOrderTypeSelect(int dsrId)
        {
            return ExecuteList<DSRWorkOrderTypeSelect>(
                "EXEC dbo.DSRWorkOrderTypeSelect @p0",
                dsrId
            );
        }

        public DSRWorkOrderTypeSelect? DSRWorkOrderTypeInsert(DSRWorkOrderTypeInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRWorkOrderTypeSelect? result = ExecuteSingle<DSRWorkOrderTypeSelect>(
                    "EXEC dbo.DSRWorkOrderTypeInsert @p0, @p1, @p2",
                    request.DsrId,
                    request.WorkOrderTypeId,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(request.DsrId, request.UserId, DsrEventType.WorkOrderTypeAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // WORK SHIFT
        // =====================================================
        public List<DsrWorkShiftSelectMulti>? DsrWorkShiftSelectMulti()
        {
            return ExecuteList<DsrWorkShiftSelectMulti>(
                "EXEC dbo.DsrWorkShiftSelectMulti"
            );
        }

        public List<DSRWorkShiftSelect>? DSRWorkShiftSelect(int dsrId)
        {
            return ExecuteList<DSRWorkShiftSelect>(
                "EXEC dbo.DSRWorkShiftSelect @p0",
                dsrId
            );
        }

        public DSRWorkShiftSelect? DSRWorkShiftInsert(DSRWorkShiftInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRWorkShiftSelect? result = ExecuteSingle<DSRWorkShiftSelect>(
                    "EXEC dbo.DSRWorkShiftInsert @p0, @p1, @p2",
                    request.DsrId,
                    request.WorkShiftId,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(request.DsrId, request.UserId, DsrEventType.WorkShiftAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRWorkShiftSelect? DSRWorkShiftUpdate(DSRWorkShiftUpdate request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRWorkShiftSelect? result = ExecuteSingle<DSRWorkShiftSelect>(
                    "EXEC dbo.DSRWorkShiftUpdate @p0, @p1, @p2",
                    request.Id,
                    request.WorkShiftId,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.WorkShiftUpdated);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // SECTION
        // =====================================================
        public List<DSRSectionSelect>? DSRSectionSelect(int dsrId)
        {
            return ExecuteList<DSRSectionSelect>(
                "EXEC dbo.DSRSectionSelect @p0",
                dsrId
            );
        }

        public DSRSectionSelect? DSRSectionInsert(DSRSectionInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRSectionSelect? result = ExecuteSingle<DSRSectionSelect>(
                    "EXEC dbo.DSRSectionInsert @p0, @p1, @p2",
                    request.DsrId,
                    request.SectionId,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(request.DsrId, request.UserId, DsrEventType.SectionAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // STRUCTURE
        // =====================================================
        public List<DSRStructureSelect>? DSRStructureSelect(int dsrId)
        {
            return ExecuteList<DSRStructureSelect>(
                "EXEC dbo.DSRStructureSelect @p0",
                dsrId
            );
        }

        public DSRStructureSelect? DSRStructureInsert(DSRStructureInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRStructureSelect? result = ExecuteSingle<DSRStructureSelect>(
                    "EXEC dbo.DSRStructureInsert @p0, @p1, @p2",
                    request.DsrId,
                    request.StructureId,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(request.DsrId, request.UserId, DsrEventType.StructureAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // MACHINE
        // =====================================================
        public DSRMachineSelect? DSRMachineSelect(int dsrId)
        {
            return ExecuteSingle<DSRMachineSelect>(
                "EXEC dbo.DSRMachineSelect @p0",
                dsrId
            );
        }

        public DSRMachineSelect? DSRMachineInsert(DSRMachineInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRMachineSelect? result = ExecuteSingle<DSRMachineSelect>(
                    "EXEC dbo.DSRMachineInsert @p0, @p1, @p2",
                    request.DsrId,
                    request.MachineId,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(request.DsrId, request.UserId, DsrEventType.MachineAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // TASK
        // =====================================================
        public List<DSRTaskSelect>? DSRTaskSelect(int dsrId)
        {
            return ExecuteList<DSRTaskSelect>(
                "EXEC dbo.DSRTaskSelect @p0",
                dsrId
            );
        }

        public DSRTaskSelect? DSRTaskInsert(DSRTaskInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRTaskSelect? result = ExecuteSingle<DSRTaskSelect>(
                    "EXEC dbo.DSRTaskInsert @p0, @p1, @p2, @p3",
                    request.DsrId,
                    request.TaskTypeId,
                    request.Title,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(request.DsrId, request.UserId, DsrEventType.TaskAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRTaskSelect? DSRTaskUpdate(DSRTaskUpdate request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRTaskSelect? result = ExecuteSingle<DSRTaskSelect>(
                    "EXEC dbo.DSRTaskUpdate @p0, @p1, @p2, @p3",
                    request.Id,
                    request.TaskTypeId,
                    request.Title,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.TaskUpdated);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRTaskSelect? DSRTaskStatus(DSRTaskStatus request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRTaskSelect? result = ExecuteSingle<DSRTaskSelect>(
                    "EXEC dbo.DSRTaskStatus @p0, @p1",
                    request.Id,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.TaskDeleted);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // TASK ASSISTANT
        // =====================================================
        public List<DSRTaskAssistantSelect>? DSRTaskAssistantSelect(int dsrId)
        {
            return ExecuteList<DSRTaskAssistantSelect>(
                "EXEC dbo.DSRTaskAssistantSelect @p0",
                dsrId
            );
        }

        public DSRTaskAssistantSelect? DSRTaskAssistantInsert(DSRTaskAssistantInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRTaskAssistantSelect? result = ExecuteSingle<DSRTaskAssistantSelect>(
                    "EXEC dbo.DSRTaskAssistantInsert @p0, @p1, @p2",
                    request.DsrTaskId,
                    request.UserId,
                    request.SelectUser
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.AssistantAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRTaskAssistantSelect? DSRTaskAssistantStatus(DSRTaskAssistantStatus request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRTaskAssistantSelect? result = ExecuteSingle<DSRTaskAssistantSelect>(
                    "EXEC dbo.DSRTaskAssistantStatus @p0, @p1",
                    request.Id,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.AssistantRemoved);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // TASK COMMENT
        // =====================================================
        public List<DSRTaskCommentSelect>? DSRTaskCommentSelect(int dsrId)
        {
            return ExecuteList<DSRTaskCommentSelect>(
                "EXEC dbo.DSRTaskCommentSelect @p0",
                dsrId
            );
        }

        public DSRTaskCommentSelect? DSRTaskCommentInsert(DSRTaskCommentInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRTaskCommentSelect? result = ExecuteSingle<DSRTaskCommentSelect>(
                    "EXEC dbo.DSRTaskCommentInsert @p0, @p1, @p2",
                    request.DsrTaskId,
                    request.UserId,
                    request.Title
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.CommentAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRTaskCommentSelect? DSRTaskCommentUpdate(DSRTaskCommentUpdate request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRTaskCommentSelect? result = ExecuteSingle<DSRTaskCommentSelect>(
                    "EXEC dbo.DSRTaskCommentUpdate @p0, @p1, @p2",
                    request.Id,
                    request.UserId,
                    request.Title
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.CommentUpdated);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRTaskCommentSelect? DSRTaskCommentDelete(DSRTaskCommentDelete request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRTaskCommentSelect? result = ExecuteSingle<DSRTaskCommentSelect>(
                    "EXEC dbo.DSRTaskCommentDelete @p0, @p1",
                    request.Id,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.CommentDeleted);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // EVENT
        // =====================================================
        public List<DSREventSelect>? DSREventSelect(int dsrId)
        {
            return ExecuteList<DSREventSelect>(
                "EXEC dbo.DSREventSelect @p0",
                dsrId
            );
        }

        public DSREventSelect? DSREventInsert(DSREventInsert request)
        {
            return ExecuteSingle<DSREventSelect>(
                "EXEC dbo.DSREventInsert @p0, @p1, @p2, @p3",
                request.DsrId,
                request.WhoId,
                request.TypeEnum,
                request.UserId
            );
        }

        // =====================================================
        // CHAT
        // =====================================================
        public List<DSRChatSelect>? DSRChatSelect(int dsrId)
        {
            return ExecuteList<DSRChatSelect>(
                "EXEC dbo.DSRChatSelect @p0",
                dsrId
            );
        }

        public DSRChatSelect? DSRChatInsert(DSRChatInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRChatSelect? result = ExecuteSingle<DSRChatSelect>(
                    "EXEC dbo.DSRChatInsert @p0, @p1, @p2",
                    request.Title,
                    request.UserId,
                    request.DsrId
                );
                if (result != null)
                {
                    InsertEvent(request.DsrId, request.UserId, DsrEventType.ChatAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // DOCUMENT
        // =====================================================
        public List<DSRDocumentSelect>? DSRDocumentSelect(int dsrId)
        {
            return ExecuteList<DSRDocumentSelect>(
                "EXEC dbo.DSRDocumentSelect @p0",
                dsrId
            );
        }

        public DSRDocumentSelect? DSRDocumentInsert(DSRDocumentInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRDocumentSelect? result = ExecuteSingle<DSRDocumentSelect>(
                    "EXEC dbo.DSRDocumentInsert @p0, @p1, @p2, @p3, @p4, @p5, @p6",
                    request.FileName,
                    request.FilePath,
                    request.FileNameTitle,
                    request.ContentType,
                    request.FileSize,
                    request.UserId,
                    request.DsrId
                );
                if (result != null)
                {
                    InsertEvent(request.DsrId, request.UserId!, DsrEventType.DocumentAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRDocumentSelect? DSRDocumentUpdate(DSRDocumentUpdate request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRDocumentSelect? result = ExecuteSingle<DSRDocumentSelect>(
                    "EXEC dbo.DSRDocumentUpdate @p0, @p1, @p2",
                    request.FileNameTitle,
                    request.UserId,
                    request.Id
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.DocumentUpdated);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRDocumentSelect? DSRDocumentStatus(DSRDocumentStatus request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRDocumentSelect? result = ExecuteSingle<DSRDocumentSelect>(
                    "EXEC dbo.DSRDocumentStatus @p0, @p1",
                    request.Id,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.DocumentDeleted);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // LOST TIME
        // =====================================================
        public List<DSRLostTimeSelect>? DSRLostTimeSelect(int dsrId)
        {
            return ExecuteList<DSRLostTimeSelect>(
                "EXEC dbo.DSRLostTimeSelect @p0",
                dsrId
            );
        }

        public DSRLostTimeSelect? DSRLostTimeInsert(DSRLostTimeInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRLostTimeSelect? result = ExecuteSingle<DSRLostTimeSelect>(
                    "EXEC dbo.DSRLostTimeInsert @p0, @p1, @p2, @p3",
                    request.Title,
                    request.UserId,
                    request.DsrId,
                    request.Second
                );
                if (result != null)
                {
                    InsertEvent(request.DsrId, request.UserId, DsrEventType.LostTimeAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRLostTimeSelect? DSRLostTimeUpdate(DSRLostTimeUpdate request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRLostTimeSelect? result = ExecuteSingle<DSRLostTimeSelect>(
                    "EXEC dbo.DSRLostTimeUpdate @p0, @p1, @p2, @p3",
                    request.Id,
                    request.Title,
                    request.UserId,
                    request.Second
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.LostTimeUpdated);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRLostTimeSelect? DSRLostTimeStatus(DSRLostTimeStatus request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRLostTimeSelect? result = ExecuteSingle<DSRLostTimeSelect>(
                    "EXEC dbo.DSRLostTimeStatus @p0, @p1",
                    request.Id,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.LostTimeDeleted);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // MATERIAL
        // =====================================================
        public List<DSRMaterialSelectMulti>? DSRMaterialSelectMulti()
        {
            return ExecuteList<DSRMaterialSelectMulti>(
                "EXEC dbo.DSRMaterialSelectMulti"
            );
        }

        public List<DSRMaterialSelect>? DSRMaterialSelect(int dsrId)
        {
            return ExecuteList<DSRMaterialSelect>(
                "EXEC dbo.DSRMaterialSelect @p0",
                dsrId
            );
        }

        public DSRMaterialSelect? DSRMaterialInsert(DSRMaterialInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRMaterialSelect? result = ExecuteSingle<DSRMaterialSelect>(
                    "EXEC dbo.DSRMaterialInsert @p0, @p1, @p2, @p3",
                    request.MaterialId,
                    request.UserId,
                    request.DsrTaskId,
                    request.Amount
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.MaterialAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRMaterialSelect? DSRMaterialUpdate(DSRMaterialUpdate request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRMaterialSelect? result = ExecuteSingle<DSRMaterialSelect>(
                    "EXEC dbo.DSRMaterialUpdate @p0, @p1, @p2, @p3, @p4",
                    request.Id,
                    request.Amount,
                    request.UserId,
                    request.MaterialId,
                    request.DsrTaskId
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.MaterialUpdated);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRMaterialSelect? DSRMaterialStatus(DSRMaterialStatus request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRMaterialSelect? result = ExecuteSingle<DSRMaterialSelect>(
                    "EXEC dbo.DSRMaterialStatus @p0, @p1",
                    request.Id,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.MaterialDeleted);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // RECORD
        // =====================================================
        public List<DSRRecordSelect>? DSRRecordSelect(int dsrId)
        {
            return ExecuteList<DSRRecordSelect>(
                "EXEC dbo.DSRRecordSelect @p0",
                dsrId
            );
        }

        public DSRRecordSelect? DSRRecordInsert(DSRRecordInsert request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRRecordSelect? result = ExecuteSingle<DSRRecordSelect>(
                    "EXEC dbo.DSRRecordInsert @p0, @p1, @p2",
                    request.Title,
                    request.UserId,
                    request.DsrId
                );
                if (result != null)
                {
                    InsertEvent(request.DsrId, request.UserId, DsrEventType.RecordAdded);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRRecordSelect? DSRRecordUpdate(DSRRecordUpdate request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRRecordSelect? result = ExecuteSingle<DSRRecordSelect>(
                    "EXEC dbo.DSRRecordUpdate @p0, @p1, @p2",
                    request.Id,
                    request.Title,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.RecordUpdated);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        public DSRRecordSelect? DSRRecordStatus(DSRRecordStatus request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRRecordSelect? result = ExecuteSingle<DSRRecordSelect>(
                    "EXEC dbo.DSRRecordStatus @p0, @p1",
                    request.Id,
                    request.UserId
                );
                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.RecordDeleted);
                }

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // DSR SELECT
        // =====================================================
        public DSRSelect? DSRSelect(int dsrId)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            try
            {
                DSRSelect? result = ExecuteSingle<DSRSelect>(
                    "EXEC dbo.DSRSelect @p0",
                    dsrId
                );

                if (result == null)
                {
                    transaction.Commit();
                    return null;
                }

                result.DSRMachineSelect = ExecuteSingle<DSRMachineSelect>(
                    "EXEC dbo.DSRMachineSelect @p0", dsrId
                );
                result.DSRWorkOrderTypeSelect = ExecuteList<DSRWorkOrderTypeSelect>(
                    "EXEC dbo.DSRWorkOrderTypeSelect @p0", dsrId
                );
                result.DSRSectionSelect = ExecuteList<DSRSectionSelect>(
                    "EXEC dbo.DSRSectionSelect @p0", dsrId
                );
                result.DSRStructureSelect = ExecuteList<DSRStructureSelect>(
                    "EXEC dbo.DSRStructureSelect @p0", dsrId
                );
                result.DSRWorkShiftSelect = ExecuteList<DSRWorkShiftSelect>(
                    "EXEC dbo.DSRWorkShiftSelect @p0", dsrId
                );
                result.DSRTaskSelect = ExecuteList<DSRTaskSelect>(
                    "EXEC dbo.DSRTaskSelect @p0", dsrId
                );
                result.DSRTaskAssistantSelect = ExecuteList<DSRTaskAssistantSelect>(
                    "EXEC dbo.DSRTaskAssistantSelect @p0", dsrId
                );
                result.DSREventSelect = ExecuteList<DSREventSelect>(
                    "EXEC dbo.DSREventSelect @p0", dsrId
                );
                result.DSRChatSelect = ExecuteList<DSRChatSelect>(
                    "EXEC dbo.DSRChatSelect @p0", dsrId
                );
                result.DSRDocumentSelect = ExecuteList<DSRDocumentSelect>(
                    "EXEC dbo.DSRDocumentSelect @p0", dsrId
                );
                result.DSRLostTimeSelect = ExecuteList<DSRLostTimeSelect>(
                    "EXEC dbo.DSRLostTimeSelect @p0", dsrId
                );
                result.DSRMaterialSelect = ExecuteList<DSRMaterialSelect>(
                    "EXEC dbo.DSRMaterialSelect @p0", dsrId
                );
                result.DSRRecordSelect = ExecuteList<DSRRecordSelect>(
                    "EXEC dbo.DSRRecordSelect @p0", dsrId
                );
                result.DSRTaskCommentSelect = ExecuteList<DSRTaskCommentSelect>(
                    "EXEC dbo.DSRTaskCommentSelect @p0", dsrId
                );

                transaction.Commit();
                return result;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // DSR INSERT (FULL NESTED FLOW)
        // =====================================================
        public List<DSRSelect>? DSRInsert(List<DSRInsert> requests)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();
            List<DSRSelect> results = [];

            try
            {
                foreach (DSRInsert request in requests)
                {
                    DSRSelect? dsr = ExecuteSingle<DSRSelect>(
                        "EXEC dbo.DSRInsert @p0, @p1, @p2, @p3, @p4",
                        request.Title!,
                        request.StructureId,
                        request.IsMachinePartRepair,
                        request.IsRemovedFromMachine,
                        request.UserId
                    );

                    if (dsr == null)
                    {
                        throw new Exception("DSR insert failed");
                    }

                    int dsrId = dsr.Id;

                    if (request.DSRMachineInsert != null)
                    {
                        dsr.DSRMachineSelect = ExecuteSingle<DSRMachineSelect>(
                            "EXEC dbo.DSRMachineInsert @p0, @p1, @p2",
                            dsrId,
                            request.DSRMachineInsert.MachineId,
                            request.UserId
                        );
                    }

                    if (request.DSRWorkOrderTypeInsert != null)
                    {
                        _ = ExecuteSingle<DSRWorkOrderTypeSelect>(
                            "EXEC dbo.DSRWorkOrderTypeInsert @p0, @p1, @p2",
                            dsrId,
                            request.DSRWorkOrderTypeInsert.WorkOrderTypeId,
                            request.UserId
                        );
                    }

                    if (request.DSRSectionInsert != null)
                    {
                        _ = ExecuteSingle<DSRSectionSelect>(
                            "EXEC dbo.DSRSectionInsert @p0, @p1, @p2",
                            dsrId,
                            request.DSRSectionInsert.SectionId,
                            request.UserId
                        );
                    }

                    if (request.DSRStructureInsert != null)
                    {
                        _ = ExecuteSingle<DSRStructureSelect>(
                            "EXEC dbo.DSRStructureInsert @p0, @p1, @p2",
                            dsrId,
                            request.DSRStructureInsert.StructureId,
                            request.UserId
                        );
                    }

                    if (request.DSRWorkShiftInsert != null)
                    {
                        _ = ExecuteSingle<DSRWorkShiftSelect>(
                            "EXEC dbo.DSRWorkShiftInsert @p0, @p1, @p2",
                            dsrId,
                            request.DSRWorkShiftInsert.WorkShiftId,
                            request.UserId
                        );
                    }

                    if (request.DSRTaskInsert != null && request.DSRTaskInsert.Count > 0)
                    {
                        foreach (DSRTaskInsert task in request.DSRTaskInsert)
                        {
                            DSRTaskSelect? createdTask = ExecuteSingle<DSRTaskSelect>(
                                "EXEC dbo.DSRTaskInsert @p0, @p1, @p2, @p3",
                                dsrId,
                                task.TaskTypeId,
                                task.Title,
                                request.UserId
                            );

                            if (createdTask == null)
                            {
                                continue;
                            }

                            if (task.DSRTaskAssistantInsert != null)
                            {
                                foreach (DSRTaskAssistantInsert assistant in task.DSRTaskAssistantInsert)
                                {
                                    _ = ExecuteSingle<DSRTaskAssistantSelect>(
                                        "EXEC dbo.DSRTaskAssistantInsert @p0, @p1, @p2",
                                        createdTask.Id,
                                        assistant.UserId,
                                        assistant.SelectUser

                                    );
                                }
                            }
                        }
                    }

                    InsertEvent(dsrId, request.UserId, DsrEventType.WorkOrderOpened);

                    results.Add(dsr);
                }

                transaction.Commit();
                return results;
            }
            catch { transaction.Rollback(); throw; }
        }

        // =====================================================
        // BACKEND SELECT
        // =====================================================
        public List<DsrBackEndSelect>? DsrBackEndSelect(int DsrId)
        {
            throw new NotImplementedException();
        }

        public DSRSelect? DSRWorkOrderStarted(DSRControllerLifeCycle request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();

            try
            {
                // 1. DSR lifecycle update
                DSRSelect? result = ExecuteSingle<DSRSelect>(
                    "EXEC dbo.DSRControllerLifeCycle @p0, @p1, @p2",
                    request.Id,
                    request.UserId,
                    request.Status
                );

                if (result == null)
                {
                    transaction.Rollback();
                    return null;
                }

                // 2. Assistant varsa → redirect et
                if (request.DSRTaskAssistantControllerLifeCycle != null)
                {
                    DSRTaskAssistantSelect? assistant =
                        DSRTaskAssistantAccepted(request.DSRTaskAssistantControllerLifeCycle);

                    // istəsən attach edə bilərsən:
                    // result.Assistant = assistant;
                }

                // 3. Event log
                InsertEvent(request.Id, request.UserId, DsrEventType.WorkOrderStarted);

                transaction.Commit();
                return result;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public DSRTaskAssistantSelect? DSRTaskAssistantAccepted(DSRTaskAssistantControllerLifeCycle request)
        {
            try
            {
                DSRTaskAssistantSelect? result = ExecuteSingle<DSRTaskAssistantSelect>(
                    "EXEC dbo.DSRTaskAssistantControllerLifeCycle @p0, @p1, @p2",
                    request.DsrTaskId,
                    request.UserId,
                    request.Status
                );

                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.AssistantAccepted);
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        public DSRTaskAssistantSelect? DSRTaskAssistantDelivered(DSRTaskAssistantControllerLifeCycle request)
        {
            using IDbContextTransaction transaction = _ctx.Database.BeginTransaction();

            try
            {
                DSRTaskAssistantSelect? result = ExecuteSingle<DSRTaskAssistantSelect>(
                    "EXEC dbo.DSRTaskAssistantControllerLifeCycle @p0, @p1, @p2",
                    request.DsrTaskId,
                    request.UserId,
                    request.Status
                );

                if (result != null)
                {
                    InsertEvent(result.DsrId, request.UserId, DsrEventType.AssistantDelivered);
                }

                transaction.Commit();
                return result;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
