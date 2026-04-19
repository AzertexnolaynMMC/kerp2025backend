using kerp.Contexts;
using kerp.Enums;
using kerp.Prosedur.PreCheck.Document;
using kerp.Prosedur.PreCheck.Event;
using kerp.Prosedur.PreCheck.Group;
using kerp.Prosedur.PreCheck.Pre;
using kerp.Prosedur.PreCheck.Record;
using kerp.Prosedur.PreCheck.ResultType;
using kerp.Prosedur.PreCheck.Section;
using kerp.Prosedur.PreCheck.Structure;
using kerp.Prosedur.PreCheck.Template;
using kerp.Prosedur.PreCheck.WorkOrder;
using kerp.Prosedur.PreCheck.WorkShift;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.PreCheckRepository
{
    public class PreCheckRepository(KerpContext ctx) : IPreCheckRepository
    {
        private readonly KerpContext _ctx = ctx;

        // ─── Event ────────────────────────────────────────────────────────────

        public PreCheckEventSelect? PreCheckEventInsert(PreCheckEventInsert request)
        {
            return ExecuteSingle<PreCheckEventSelect>(
                "EXEC dbo.PreCheckEventInsert @p0, @p1, @p2, @p3",
                request.PreCheckId,
                request.UserId,
                request.EventType,
                request.WhoId
            );
        }

        public List<PreCheckEventSelect>? PreCheckEventSelect(int id)
        {
            return ExecuteList<PreCheckEventSelect>(
                "EXEC dbo.PreCheckEventSelect @p0", id);
        }

        // ─── Group ────────────────────────────────────────────────────────────

        public List<PreCheckGroupSelectForInsert>? PreCheckGroupSelectForInsert()
        {
            return ExecuteList<PreCheckGroupSelectForInsert>(
                "EXEC dbo.PreCheckGroupSelectForInsert");
        }

        // ─── PreCheck (main) ──────────────────────────────────────────────────

        public List<PreCheckSelect>? PreCheckInsert(List<PreCheckInsert> request)
        {
            List<PreCheckSelect> result = [];

            using Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction =
                _ctx.Database.BeginTransaction();
            try
            {
                foreach (PreCheckInsert item in request)
                {
                    PreCheckSelect? model = ExecuteSingle<PreCheckSelect>(
                        "EXEC dbo.PreCheckInsert @p0, @p1, @p2, @p3",
                        item.AssetId,
                        item.ShiftId,
                        item.StructureId,
                        item.UserId
                    );

                    if (model == null)
                    {
                        continue;
                    }

                    int id = model.Id;

                    if (item.PreCheckSectionInsert != null)
                    {
                        item.PreCheckSectionInsert.PreCheckId = id;
                        item.PreCheckSectionInsert.UserId = item.UserId;
                        _ = PreCheckSectionInsert(item.PreCheckSectionInsert);
                    }

                    if (item.PreCheckStructureInsert != null)
                    {
                        item.PreCheckStructureInsert.PreCheckId = id;
                        item.PreCheckStructureInsert.UserId = item.UserId;
                        _ = PreCheckStructureInsert(item.PreCheckStructureInsert);
                    }

                    if (item.PreCheckWorkOrderInsert != null)
                    {
                        item.PreCheckWorkOrderInsert.PreCheckId = id;
                        item.PreCheckWorkOrderInsert.UserId = item.UserId;
                        _ = PreCheckWorkOrderInsert(item.PreCheckWorkOrderInsert);
                    }

                    if (item.PreCheckTemplateExecuteInsert != null)
                    {
                        foreach (PreCheckTemplateExecuteInsert tpl in item.PreCheckTemplateExecuteInsert)
                        {
                            tpl.PreCheckId = id;
                            tpl.UserId = item.UserId;
                            _ = PreCheckTemplateExecuteInsert(tpl);
                        }
                    }

                    InsertEvent(id, item.UserId, PreCheckEventType.Created, item.UserId);

                    PreCheckSelect? full = PreCheckSelect(id);
                    if (full != null)
                    {
                        result.Add(full);
                    }
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
        public PreCheckSelect? PreCheckSelect(int id)
        {
            PreCheckSelect? model = ExecuteSingle<PreCheckSelect>(
                "EXEC dbo.PreCheckSelect @p0", id);

            if (model == null)
            {
                return null;
            }

            model.PreCheckSectionSelect =
                ExecuteList<PreCheckSectionSelect>(
                    "EXEC dbo.PreCheckSectionSelect @p0", id);

            model.PreCheckStructureSelect =
                ExecuteList<PreCheckStructureSelect>(
                    "EXEC dbo.PreCheckStructureSelect @p0", id);

            model.PreCheckTemplateExecuteSelect =
                ExecuteList<PreCheckTemplateExecuteSelect>(
                    "EXEC dbo.PreCheckTemplateExecuteSelect @p0", id);

            model.PreCheckWorkOrderSelect =
                ExecuteList<PreCheckWorkOrderSelect>(
                    "EXEC dbo.PreCheckWorkOrderTypeSelect @p0", id);

            // 🔥 BUNLAR SƏNDƏ YOXDUR — ƏLAVƏ ET

            model.PreCheckDocumentSelect =
                ExecuteList<PreCheckDocumentSelect>(
                    "EXEC dbo.PreCheckDocumentSelect @p0", id);

            model.PreCheckRecordSelect =
                ExecuteList<PreCheckRecordSelect>(
                    "EXEC dbo.PreCheckRecordSelect @p0", id);

            model.PreCheckEventSelect =
                ExecuteList<PreCheckEventSelect>(
                    "EXEC dbo.PreCheckEventSelect @p0", id);

            model.PreCheckEventsSelectMulti =
    ExecuteList<PreCheckEventsSelectMulti>(
        "EXEC dbo.PreCheckEventsSelectMulti @p0", id);

            return model;
        }
        // ─── ResultType ───────────────────────────────────────────────────────

        public List<PreCheckResultTypeSelectForInsert>? PreCheckResultTypeSelectForInsert()
        {
            return ExecuteList<PreCheckResultTypeSelectForInsert>(
                "EXEC dbo.PreCheckResultTypeSelectForInsert");
        }

        // ─── Section ──────────────────────────────────────────────────────────

        public PreCheckSectionSelect? PreCheckSectionInsert(PreCheckSectionInsert request)
        {
            return ExecuteSingle<PreCheckSectionSelect>(
                "EXEC dbo.PreCheckSectionInsert @p0, @p1, @p2",
                request.PreCheckId,
                request.SectionId,
                request.UserId
            );
        }

        public List<PreCheckSectionSelect>? PreCheckSectionSelect(int id)
        {
            return ExecuteList<PreCheckSectionSelect>(
                "EXEC dbo.PreCheckSectionSelect @p0", id);
        }

        // ─── Structure ────────────────────────────────────────────────────────

        public PreCheckStructureSelect? PreCheckStructureInsert(PreCheckStructureInsert request)
        {
            return ExecuteSingle<PreCheckStructureSelect>(
                "EXEC dbo.PreCheckStructureInsert @p0, @p1, @p2",
                request.PreCheckId,
                request.StructureId,
                request.UserId
            );
        }

        public List<PreCheckStructureSelect>? PreCheckStructureSelect(int id)
        {
            return ExecuteList<PreCheckStructureSelect>(
                "EXEC dbo.PreCheckStructureSelect @p0", id);
        }

        // ─── Template ─────────────────────────────────────────────────────────

        public PreCheckTemplateExecuteSelect? PreCheckTemplateExecuteInsert(PreCheckTemplateExecuteInsert request)
        {
            return ExecuteSingle<PreCheckTemplateExecuteSelect>(
                "EXEC dbo.PreCheckTemplateExecuteInsert @p0, @p1, @p2, @p3, @p4",
                request.PreCheckId,
                request.PreCheckTemplateId,
                request.PreCheckResultTypeId,
                request.Descreption,
                request.UserId
            );
        }

        public List<PreCheckTemplateExecuteSelect>? PreCheckTemplateExecuteSelect(int id)
        {
            return ExecuteList<PreCheckTemplateExecuteSelect>(
                "EXEC dbo.PreCheckTemplateExecuteSelect @p0", id);
        }

        public List<PreCheckTemplateSelectForInsert>? PreCheckTemplateSelectForInsert()
        {
            return ExecuteList<PreCheckTemplateSelectForInsert>(
                "EXEC dbo.PreCheckTemplateSelectForInsert");
        }

        // ─── WorkOrder ────────────────────────────────────────────────────────

        public PreCheckWorkOrderSelect? PreCheckWorkOrderInsert(PreCheckWorkOrderInsert request)
        {
            return ExecuteSingle<PreCheckWorkOrderSelect>(
                "EXEC dbo.PreCheckWorkOrderInsert @p0, @p1, @p2",
                request.PreCheckId,
                request.WorkOrderId,
                request.UserId
            );
        }

        public List<PreCheckWorkOrderSelect>? PreCheckWorkOrderSelect(int id)
        {
            return ExecuteList<PreCheckWorkOrderSelect>(
                "EXEC dbo.PreCheckWorkOrderTypeSelect @p0", id);
        }

        public List<PreCheckWorkOrderTypeLangSelectForInsert>? PreCheckWorkOrderTypeLangSelectForInsert()
        {
            return ExecuteList<PreCheckWorkOrderTypeLangSelectForInsert>(
                "EXEC dbo.PreCheckWorkOrderTypeLangSelectForInsert");
        }

        // ─── WorkShift ────────────────────────────────────────────────────────

        public List<PreCheckWorkShiftSelectForInsert>? PreCheckWorkShiftSelectForInsert()
        {
            return ExecuteList<PreCheckWorkShiftSelectForInsert>(
                "EXEC dbo.PreCheckWorkShiftSelectForInsert");
        }
        // ─── Document ─────────────────────────────────────────────────────────

        public List<PreCheckDocumentSelect>? PreCheckDocumentSelect(int id)
        {
            return ExecuteList<PreCheckDocumentSelect>(
                "EXEC dbo.PreCheckDocumentSelect @p0", id);
        }

        public PreCheckSelect? PreCheckDocumentInsert(PreCheckDocumentInsert request)
        {
            _ = ExecuteList<PreCheckDocumentSelect>(
                "EXEC dbo.PreCheckDocumentInsert @p0, @p1, @p2, @p3, @p4, @p5, @p6",
                request.FileName,
                request.FilePath,
                request.FileNameTitle,
                request.ContentType,
                request.FileSize,
                request.UserId,
                request.PreCheckId
            );

            // 🔥 EVENT
            InsertEvent(request.PreCheckId, request.UserId, PreCheckEventType.DocumentInserted, request.UserId);

            return PreCheckSelect(request.PreCheckId);
        }

        public PreCheckSelect? PreCheckDocumentUpdate(PreCheckDocumentUpdate request)
        {
            PreCheckDocumentSelect? doc = ExecuteSingle<PreCheckDocumentSelect>(
                "EXEC dbo.PreCheckDocumentUpdate @p0, @p1, @p2",
                request.FileNameTitle,
                request.UserId,
                request.Id
            );

            if (doc == null)
            {
                return null;
            }

            // 🔥 EVENT
            InsertEvent(doc.PreCheckId ?? 0, request.UserId, PreCheckEventType.DocumentUpdated, request.UserId);

            return PreCheckSelect(doc.PreCheckId ?? 0);
        }

        public PreCheckSelect? PreCheckDocumentStatus(PreCheckDocumentStatus request)
        {
            PreCheckDocumentSelect? doc = ExecuteSingle<PreCheckDocumentSelect>(
                "EXEC dbo.PreCheckDocumentStatus @p0, @p1",
                request.Id,
                request.UserId
            );

            if (doc == null)
            {
                return null;
            }

            // 🔥 EVENT
            InsertEvent(doc.PreCheckId ?? 0, request.UserId, PreCheckEventType.DocumentStatusChanged, request.UserId);

            return PreCheckSelect(doc.PreCheckId ?? 0);
        }
        // ─── Record ───────────────────────────────────────────────────────────


        public List<PreCheckRecordSelect>? PreCheckRecordSelect(int id)
        {
            return ExecuteList<PreCheckRecordSelect>(
                "EXEC dbo.PreCheckRecordSelect @p0", id);
        }
        public PreCheckSelect? PreCheckRecordInsert(PreCheckRecordInsert request)
        {
            _ = ExecuteSingle<PreCheckRecordSelect>(
                "EXEC dbo.PreCheckRecordInsert @p0, @p1, @p2",
                request.Title,
                request.UserId,
                request.PreCheckId
            );

            // 🔥 EVENT
            InsertEvent(request.PreCheckId, request.UserId, PreCheckEventType.RecordInserted, request.UserId);

            return PreCheckSelect(request.PreCheckId);
        }

        public PreCheckSelect? PreCheckRecordUpdate(PreCheckRecordUpdate request)
        {
            PreCheckRecordSelect? rec = ExecuteSingle<PreCheckRecordSelect>(
                "EXEC dbo.PreCheckRecordUpdate @p0, @p1, @p2",
                request.Id,
                request.Title,
                request.UserId
            );

            if (rec == null)
            {
                return null;
            }

            // 🔥 EVENT
            InsertEvent(rec.PreCheckId ?? 0, request.UserId, PreCheckEventType.RecordUpdated, request.UserId);

            return PreCheckSelect(rec.PreCheckId ?? 0);
        }

        public PreCheckSelect? PreCheckRecordStatus(PreCheckRecordStatus request)
        {
            PreCheckRecordSelect? rec = ExecuteSingle<PreCheckRecordSelect>(
                "EXEC dbo.PreCheckRecordStatus @p0, @p1",
                request.Id,
                request.UserId
            );

            if (rec == null)
            {
                return null;
            }

            // 🔥 EVENT
            InsertEvent(rec.PreCheckId ?? 0, request.UserId, PreCheckEventType.RecordStatusChanged, request.UserId);

            return PreCheckSelect(rec.PreCheckId ?? 0);
        }

        // ─── Helpers ──────────────────────────────────────────────────────────

        private void InsertEvent(int preCheckId, int userId, PreCheckEventType eventType, int whoId)
        {
            _ = ExecuteSingle<PreCheckEventSelect>(
                "EXEC dbo.PreCheckEventInsert @p0, @p1, @p2, @p3",
                preCheckId,
                userId,
                (int)eventType,
                whoId
            );
        }

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

        public PreCheckSelect? Accepted(PreCheckControllerLifeCircle request)
        {
            PreCheckSelect? result = ExecuteSingle<PreCheckSelect>(
                "EXEC dbo.PreCheckControllerLifeCircle @p0, @p1, @p2",
                request.Id,
                request.UserId,
                (int)PreCheckEventType.Accepted
            );

            if (result != null)
            {
                // 🔥 EVENT
                InsertEvent(request.Id, request.UserId, PreCheckEventType.Accepted, request.UserId);

                return PreCheckSelect(request.Id);
            }

            return null;
        }

        public PreCheckSelect? InReview(PreCheckControllerLifeCircle request)
        {
            PreCheckSelect? result = ExecuteSingle<PreCheckSelect>(
    "EXEC dbo.PreCheckControllerLifeCircle @p0, @p1, @p2",
    request.Id,
    request.UserId,
    (int)PreCheckEventType.InReview
);

            if (result != null)
            {
                // 🔥 EVENT
                InsertEvent(request.Id, request.UserId, PreCheckEventType.InReview, request.UserId);

                return PreCheckSelect(request.Id);
            }

            return null;
        }

        public PreCheckSelect? Approved(PreCheckControllerLifeCircle request)
        {
            PreCheckSelect? result = ExecuteSingle<PreCheckSelect>(
"EXEC dbo.PreCheckControllerLifeCircle @p0, @p1, @p2",
request.Id,
request.UserId,
(int)PreCheckEventType.Approved
);

            if (result != null)
            {
                // 🔥 EVENT
                InsertEvent(request.Id, request.UserId, PreCheckEventType.Approved, request.UserId);

                return PreCheckSelect(request.Id);
            }

            return null;
        }

        public PreCheckSelect? Closed(PreCheckControllerLifeCircle request)
        {
            PreCheckSelect? result = ExecuteSingle<PreCheckSelect>(
"EXEC dbo.PreCheckControllerLifeCircle @p0, @p1, @p2",
request.Id,
request.UserId,
(int)PreCheckEventType.Closed
);

            if (result != null)
            {
                // 🔥 EVENT
                InsertEvent(request.Id, request.UserId, PreCheckEventType.Closed, request.UserId);

                return PreCheckSelect(request.Id);
            }

            return null;
        }
        public List<PreCheckEventsSelectMulti>? PreCheckEventsSelectMulti(int id)
        {
            return ExecuteList<PreCheckEventsSelectMulti>(
                "EXEC dbo.PreCheckEventsSelectMulti @p0",
                id
            );
        }

    }
}