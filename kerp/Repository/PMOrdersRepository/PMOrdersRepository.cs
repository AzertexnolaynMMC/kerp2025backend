using kerp.Contexts;
using kerp.Enums;
using kerp.Prosedur.PMOrders;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.PMOrdersRepository
{
    public class PMOrdersRepository(KerpContext ctx) : IPMOrdersRepository
    {
        private readonly KerpContext _ctx = ctx;

        public PMOrdersSelect? GetPMOrder(int id)
        {
            PMOrdersSelect? order = ExecuteSingle<PMOrdersSelect>(
                "EXEC dbo.PMOrdersSelect @p0",
                id
            );

            if (order == null)
            {
                return null;
            }

            order.PMOrderWorkOrderTypeSelect = ExecuteList<PMOrderWorkOrderTypeSelect>(
                "EXEC dbo.PMOrderWorkOrderTypeSelect @p0", id);

            order.PMRecordSelect = ExecuteList<PMRecordSelect>(
                "EXEC dbo.PMRecordSelect @p0", id);

            order.PMMaterialSelect = ExecuteList<PMMaterialSelect>(
                "EXEC dbo.PMMaterialSelect @p0", id);

            order.PMDocumentsSelect = ExecuteList<PMDocumentsSelect>(
                "EXEC dbo.PMDocumentsSelect @p0", id);

            order.PMAssigneesSelect = ExecuteList<PMAssigneesSelect>(
                "EXEC dbo.PMAssigneesSelect @p0", id);

            order.PMChatSelect = ExecuteList<PMChatSelect>(
                "EXEC dbo.PMChatSelect @p0", id);

            order.PMEventSelect = ExecuteList<PMEventSelect>(
                "EXEC dbo.PMEventSelect @p0", id);

            order.PMEventSelectMulti = ExecuteList<PMEventSelectMulti>(
                "EXEC dbo.PMEventSelectMulti @p0", id);

            order.PMChecklistExecutionSelect = ExecuteList<PMChecklistExecutionSelect>(
                "EXEC dbo.PMChecklistExecutionSelect @p0", id);

            return order;
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

        private List<T>? ExecuteList<T>(string sql, params object[] parameters) where T : class
        {
            return [.. _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()];
        }

        public PMOrdersSelect? PMOrderControllerLifeCrcyle(PMOrderControllerLifeCrcyle model)
        {
            PMOrdersSelect? result = ExecuteSingle<PMOrdersSelect>(
                "EXEC dbo.PMOrderControllerLifeCrcyle @p0, @p1, @p2",
                model.Id,
                model.UserId,
                model.Status
            );

            if (result != null)
            {
                InsertPMEvent(model.Id, model.UserId, PMOrderEventType.Accepted, model.UserId);
                return GetPMOrder(model.Id);
            }

            return null;
        }
        #endregion
        private void InsertPMEvent(
    int orderId,
    int userId,
    PMOrderEventType eventType,
    int targetUserId)
        {
            _ = ExecuteSingle<PMEventSelect>(
                "EXEC dbo.PMOrderEventInsert @p0, @p1, @p2, @p3",
                orderId,
                userId,
                (int)eventType,
                targetUserId
            );
        }

        public PMOrdersSelect? PMChecklistExecutionUpdate(List<PMChecklistExecutionUpdate> model)
        {
            if (model == null || model.Count == 0)
            {
                return null;
            }

            int orderId = 0;
            int userId = model[0].FilledBy;

            foreach (PMChecklistExecutionUpdate item in model)
            {
                PMChecklistExecutionSelect? result = ExecuteSingle<PMChecklistExecutionSelect>(
                    "EXEC dbo.PMChecklistExecutionUpdate @p0,@p1,@p2,@p3,@p4,@p5",
                    item.ResponseValue,
                    item.FilledBy,
                    item.IsInRange,
                    item.Notes,
                    item.PhotoPath,
                    item.Id
                );

                if (result != null)
                {
                    orderId = result.PmOrderId ?? 0;
                }
            }

            // Event yaz
            InsertPMEvent(orderId, userId, PMOrderEventType.TaskAdded, userId);

            // Yenilənmiş PMOrder qaytar
            return GetPMOrder(orderId);
        }

        public PMOrdersSelect? PMOrderSend(PMOrderControllerLifeCrcyle model)
        {
            PMOrdersSelect? result = ExecuteSingle<PMOrdersSelect>(
    "EXEC dbo.PMOrderControllerLifeCrcyle @p0, @p1, @p2",
    model.Id,
    model.UserId,
    model.Status
);

            if (result != null)
            {
                InsertPMEvent(model.Id, model.UserId, PMOrderEventType.Completed, model.UserId);
                return GetPMOrder(model.Id);
            }

            return null;
        }

        public PMOrdersSelect? PMRecordInsert(PMRecordInsert model)
        {
            List<PMRecordSelect>? result = ExecuteList<PMRecordSelect>(
                "EXEC dbo.PMRecordInsert @p0, @p1, @p2",
                model.PmOrderId,
                model.UserId,
                model.Note
            );

            if (result != null)
            {
                InsertPMEvent(model.PmOrderId, model.UserId, PMOrderEventType.NoteAdded, model.UserId);
                return GetPMOrder(model.PmOrderId);
            }

            return null;
        }

        public PMOrdersSelect? PMRecordStatus(PMRecordStatus model)
        {
            PMRecordSelect? result = ExecuteSingle<PMRecordSelect>(
                "EXEC dbo.PMRecordStatus @p0, @p1",
                model.Id,
                model.UserId
            );

            if (result != null)
            {
                InsertPMEvent(result.Id, model.UserId, PMOrderEventType.NoteDeleted, model.UserId);
                return GetPMOrder(result.PmOrderId);
            }

            return null;
        }

        public PMOrdersSelect? PMRecordUpdate(PMRecordUpdate model)
        {
            PMRecordSelect? result = ExecuteSingle<PMRecordSelect>(
                "EXEC dbo.PMRecordUpdate @p0, @p1, @p2",
                model.Id,
                model.Note,
                model.UserId
            );

            if (result != null)
            {
                InsertPMEvent(result.PmOrderId, model.UserId, PMOrderEventType.NoteUpdate, model.UserId);
                return GetPMOrder(result.PmOrderId);
            }

            return null;
        }

        public PMOrdersSelect? PMDocumentsInsert(PMDocumentsInsert model)
        {
            // Insert prosedurunu çağır
            PMDocumentsSelect? result = ExecuteSingle<PMDocumentsSelect>(
                "EXEC dbo.PMDocumentsInsert @p0,@p1,@p2,@p3,@p4,@p5,@p6",
                model.FileName,
                model.FilePath,
                model.FileNameTitle,
                model.ContentType,
                Convert.ToInt64(model.FileSize),
                model.UserId,
                model.PmOrderId
            );

            if (result != null)
            {
                // Event yaz
                InsertPMEvent(model.PmOrderId, model.UserId, PMOrderEventType.DocumentAdded, model.UserId);

                // Yenilənmiş PMOrder qaytar
                return GetPMOrder(result.PmOrderId);
            }

            return null;
        }

        public PMOrdersSelect? PMDocumentsStatus(PMDocumentsStatus model)
        {
            // Status prosedurunu çağır
            PMDocumentsSelect? result = ExecuteSingle<PMDocumentsSelect>(
                "EXEC dbo.PMDocumentsStatus @p0,@p1",
                model.UserId,
                model.Id
            );

            if (result != null)
            {
                InsertPMEvent(result.PmOrderId, model.UserId, PMOrderEventType.DocumentDeleted, model.UserId);
                return GetPMOrder(result.PmOrderId);
            }

            return null;
        }

        public PMOrdersSelect? PMDocumentsUpdate(PMDocumentsUpdate model)
        {
            // Update prosedurunu çağır
            PMDocumentsSelect? result = ExecuteSingle<PMDocumentsSelect>(
                "EXEC dbo.PMDocumentsUpdate @p0,@p1,@p2",
                model.FileNameTitle,
                model.UserId,
                model.Id
            );

            if (result != null)
            {
                InsertPMEvent(result.PmOrderId, model.UserId, PMOrderEventType.DocumentUpdate, model.UserId);
                return GetPMOrder(result.PmOrderId);
            }

            return null;
        }

        public PMOrdersSelect? PMMaterialInsert(PMMaterialInsert model)
        {
            PMMaterialSelect? result = ExecuteSingle<PMMaterialSelect>(
                "EXEC dbo.PMMaterialInsert @p0,@p1,@p2,@p3",
                model.MaterialId,
                model.PmOrderId,
                model.Amount,
                model.UserId
            );

            if (result != null)
            {
                InsertPMEvent(result.PmOrderId, model.UserId, PMOrderEventType.MaterialAdded, model.UserId);
                return GetPMOrder(model.PmOrderId);
            }

            return null;
        }

        public PMOrdersSelect? PMMaterialUpdate(PMMaterialUpdate model)
        {
            PMMaterialSelect? result = ExecuteSingle<PMMaterialSelect>(
                "EXEC dbo.PMMaterialUpdate @p0,@p1,@p2,@p3",
                model.Id,
                model.Amount,
                model.UserId,
                model.MaterialId
            );

            if (result != null)
            {
                InsertPMEvent(result.PmOrderId, model.UserId, PMOrderEventType.MaterialUpdate, model.UserId);
                return GetPMOrder(result.PmOrderId);
            }

            return null;
        }

        public PMOrdersSelect? PMMaterialStatus(PMMaterialStatus model)
        {
            PMMaterialSelect? result = ExecuteSingle<PMMaterialSelect>(
                "EXEC dbo.PMMaterialStatus @p0,@p1",
                model.Id,
                model.UserId
            );

            if (result != null)
            {
                InsertPMEvent(result.PmOrderId, model.UserId, PMOrderEventType.MaterialDeleted, model.UserId);
                return GetPMOrder(result.PmOrderId);
            }

            return null;
        }

        public List<PMMaterialSelectMulti>? PMMaterialSelectMulti()
        {
            // Proseduru çağır və nəticəni list olaraq götür
            return [.. _ctx.Set<PMMaterialSelectMulti>()
                       .FromSqlRaw("EXEC dbo.PMMaterialSelectMulti")
                       .AsNoTracking()];
        }

        public PMOrdersSelect? PMAssigneesInsert(List<PMAssigneesInsert> models)
        {
            if (models == null || models.Count == 0)
            {
                return null;
            }

            int orderId = models[0].PmOrderId; // Hamısı eyni PmOrderId olmalıdır
            _ = models[0].UserId;

            foreach (PMAssigneesInsert item in models)
            {
                PMAssigneesSelect? result = ExecuteSingle<PMAssigneesSelect>(
                    "EXEC dbo.PMAssigneesInsert @p0,@p1,@p2,@p3",
                    item.PmOrderId,
                    item.UserId,
                    item.AssigneeId,
                    item.Role
                );

                if (result != null)
                {
                    // Event yaz
                    InsertPMEvent(item.PmOrderId, item.UserId, PMOrderEventType.AssigneesAdded, item.AssigneeId);
                }
            }

            // Yenilənmiş PMOrder qaytar
            return GetPMOrder(orderId);
        }

        public PMOrdersSelect? PMAssigneesStatus(PMAssigneesStatus model)
        {
            PMAssigneesSelect? result = ExecuteSingle<PMAssigneesSelect>(
                "EXEC dbo.PMAssigneesStatus @p0,@p1",
                model.Id,
                model.UserId
            );

            if (result != null)
            {
                InsertPMEvent(result.PmOrderId, model.UserId, PMOrderEventType.AssigneesDeleted, model.UserId);

                return GetPMOrder(result.PmOrderId);
            }

            return null;
        }

        public PMOrdersSelect? PMChatInsert(PMChatInsert model)
        {
            // Proseduru çağır və nəticəni al
            PMChatSelect? result = ExecuteSingle<PMChatSelect>(
                "EXEC dbo.PMChatInsert @p0, @p1, @p2",
                model.Title,
                model.UserId,
                model.PmOrderId
            );

            if (result != null)
            {
                // Event əlavə etmək istəyirsənsə, burada edə bilərsən, məsələn:
                InsertPMEvent(model.PmOrderId, model.UserId, PMOrderEventType.ChatAdded, model.UserId);

                // Yenilənmiş PMOrder qaytar
                return GetPMOrder(model.PmOrderId);
            }

            return null;
        }
    }
}