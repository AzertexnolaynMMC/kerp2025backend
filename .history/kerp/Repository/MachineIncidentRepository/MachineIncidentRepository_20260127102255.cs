using kerp.Contexts;
using kerp.Enums;
using kerp.Prosedur.MachineIncident.Assistant;
using kerp.Prosedur.MachineIncident.Chat;
using kerp.Prosedur.MachineIncident.Document;
using kerp.Prosedur.MachineIncident.Event;
using kerp.Prosedur.MachineIncident.Group;
using kerp.Prosedur.MachineIncident.Incident;
using kerp.Prosedur.MachineIncident.MachineIncidentAssistant;
using kerp.Prosedur.MachineIncident.MachineIncidentDocument;
using kerp.Prosedur.MachineIncident.MachineIncidentLostTime;
using kerp.Prosedur.MachineIncident.MachineIncidentTask;
using kerp.Prosedur.MachineIncident.MachineIncidentWorkShift;
using kerp.Prosedur.MachineIncident.Material;
using kerp.Prosedur.MachineIncident.Record;
using kerp.Prosedur.MachineIncident.Section;
using kerp.Prosedur.MachineIncident.SelectModels;
using kerp.Prosedur.MachineIncident.Structure;
using kerp.Prosedur.MachineIncident.Task;
using kerp.Prosedur.MachineIncident.Type;
using kerp.Prosedur.MachineIncident.WorkOrderType;
using kerp.Prosedur.MachineIncident.WorkShift;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.MachineIncidentRepository
{
    public class MachineIncidentRepository(KerpContext ctx) : IMachineIncidentRepository
    {
        private readonly KerpContext _ctx = ctx;



        public MachineIncidentSelect? MachineIncidentTaskStatus(MachineIncidentTaskStatus item)
        {
            MachineIncidentTaskSelect MachineIncidentAssistantSelect = ExecuteSingle<MachineIncidentTaskSelect>(
"EXEC dbo.MachineIncidentTaskStatus @p0, @p1",
item.UserId,
item.Id
);
            InsertEvent(MachineIncidentAssistantSelect.MachineIncidentId, item.UserId, MachineIncidentEventType.TaskRemoved, item.UserId);
            return MachineIncidentSelect(MachineIncidentAssistantSelect.MachineIncidentId);
        }
        public MachineIncidentSelect? MachineIncidentTaskTitleCrashTypeUpdate(MachineIncidentTaskTitleCrashTypeUpdate item)
        {
            MachineIncidentTaskSelect MachineIncidentAssistantSelect = ExecuteSingle<MachineIncidentTaskSelect>(
"EXEC dbo.MachineIncidentTaskTitleCrashTypeUpdate @p0, @p1, @p2, @p3",
item.UserId,
item.Id,
item.Title,
item.CrashTypeId
);
"s"
            InsertEvent(MachineIncidentAssistantSelect.MachineIncidentId, item.UserId, MachineIncidentEventType.TaskUpdated, item.UserId);
            return MachineIncidentSelect(MachineIncidentAssistantSelect.MachineIncidentId);
        }

        public MachineIncidentSelect? MachineIncidentDocumentStatus(MachineIncidentDocumentStatus item)
        {
            MachineIncidentDocumentSelect MachineIncidentAssistantSelect = ExecuteSingle<MachineIncidentDocumentSelect>(
"EXEC dbo.MachineIncidentDocumentStatus @p0, @p1",
item.UserId,
item.Id
);
            InsertEvent(MachineIncidentAssistantSelect.MachineIncidentId, item.UserId, MachineIncidentEventType.DocumentRemoved, item.UserId);


            return MachineIncidentSelect(MachineIncidentAssistantSelect.MachineIncidentId);
        }
        public MachineIncidentSelect? MachineIncidentDocumentInsert(MachineIncidentDocumentInsert item)
        {
            MachineIncidentDocumentSelect MachineIncidentAssistantSelect = ExecuteSingle<MachineIncidentDocumentSelect>(
"EXEC dbo.MachineIncidentDocumentInsert @p0, @p1, @p2, @p3, @p4, @p5, @p6",
item.FileName,
item.FilePath,
item.FileNameTitle,
item.ContentType,
item.FileSize,
item.UserId,
item.MachineIncidentId

);
            InsertEvent(MachineIncidentAssistantSelect.MachineIncidentId, item.UserId, MachineIncidentEventType.DocumentAdded, item.UserId);


            return MachineIncidentSelect(MachineIncidentAssistantSelect.MachineIncidentId);
        }


        public MachineIncidentSelect? MachineIncidentMaterialStatus(MachineIncidentMaterialStatus item)
        {
            MachineIncidentMaterialSelect MachineIncidentMaterialSelect = ExecuteSingle<MachineIncidentMaterialSelect>(
"EXEC dbo.MachineIncidentMaterialStatus @p0, @p1",
item.Id,
item.UserId

);
            InsertEvent(MachineIncidentMaterialSelect.MachineIncidentId, item.UserId, MachineIncidentEventType.MaterialRemoved, item.UserId);
            return MachineIncidentSelect(MachineIncidentMaterialSelect.MachineIncidentId);
        }

        public MachineIncidentSelect? MachineIncidentMaterialInsert(MachineIncidentMaterialInsert item)
        {
            MachineIncidentMaterialSelect MachineIncidentMaterialSelect = ExecuteSingle<MachineIncidentMaterialSelect>(
"EXEC dbo.MachineIncidentMaterialInsert @p0, @p1, @p2, @p3",
item.MaterialId,
item.UserId,
item.MachineIncidentTaskId,
item.Amount

);
            InsertEvent(MachineIncidentMaterialSelect.MachineIncidentId, item.UserId, MachineIncidentEventType.MaterialAdded, item.UserId);
            return MachineIncidentSelect(MachineIncidentMaterialSelect.MachineIncidentId);

        }
        public MachineIncidentSelect? MachineIncidentTaskInsert(MachineIncidentTaskInsert item)
        {
            MachineIncidentTaskSelect MachineIncidentAssistantSelect = ExecuteSingle<MachineIncidentTaskSelect>(
"EXEC dbo.MachineIncidentTaskInsert @p0, @p1, @p2, @p3, @p4",
item.Title,
item.UserId,
item.AssetId,
item.MachineIncidentId,
item.CrashTypeId

);
            InsertEvent(item.MachineIncidentId, item.UserId, MachineIncidentEventType.TaskAdded, item.UserId);
            if (item.MachineIncidentMaterialInsert != null)
            {
                foreach (MachineIncidentMaterialInsert item1 in item.MachineIncidentMaterialInsert)
                {
                    MachineIncidentMaterialSelect MachineIncidentMaterialSelect = ExecuteSingle<MachineIncidentMaterialSelect>(
"EXEC dbo.MachineIncidentMaterialInsert @p0, @p1, @p2, @p3",
item1.MaterialId,
item1.UserId,
MachineIncidentAssistantSelect!.Id,
item1.Amount

);
                    InsertEvent(MachineIncidentMaterialSelect.MachineIncidentId, item.UserId, MachineIncidentEventType.MaterialAdded, item.UserId);


                }
            }
            return MachineIncidentSelect(item.MachineIncidentId);

        }

        public MachineIncidentSelect? MachineIncidentAssistantStatus(MachineIncidentAssistantStatus item)
        {
            MachineIncidentAssistantSelect MachineIncidentAssistantSelect = ExecuteSingle<MachineIncidentAssistantSelect>(
"EXEC dbo.MachineIncidentAssistantStatus @p0, @p1",
item.Id,
item.UserId

);
            if (MachineIncidentAssistantSelect.TypeEnum == 1)
            {
                InsertEvent(MachineIncidentAssistantSelect.CrashId, item.UserId, MachineIncidentEventType.MasterRemoved, MachineIncidentAssistantSelect.AssistantId);

            }
            else
            {
                InsertEvent(MachineIncidentAssistantSelect.CrashId, item.UserId, MachineIncidentEventType.HelperRemoved, MachineIncidentAssistantSelect.AssistantId);

            }

            return MachineIncidentSelect(MachineIncidentAssistantSelect.CrashId);
        }

        public MachineIncidentSelect? MachineIncidentReject(MachineIncidentReject item)
        {
            _ = ExecuteSingle<MachineIncidentSelectForBackEnd>(
"EXEC dbo.MachineIncidentReject @p0, @p1 , @p2, @p3",
item.Id,
item.UserId,
item.TypeEnum,
item.Title
);
            if (item.TypeEnum == 1)
            {
                InsertEvent(item.Id, item.UserId, MachineIncidentEventType.RejectedByCounterParty, item.UserId);
            }
            else
            {
                InsertEvent(item.Id, item.UserId, MachineIncidentEventType.RejectedByReceiver, item.UserId);
            }
            return MachineIncidentSelect(item.Id);

        }

        public MachineIncidentSelect? MachineIncidentResolved(MachineIncidentResolved item)
        {
            _ = ExecuteSingle<MachineIncidentSelectForBackEnd>(
"EXEC dbo.MachineIncidentResolved @p0, @p1",
item.Id,
item.UserId
);
            InsertEvent(item.Id, item.UserId, MachineIncidentEventType.ApprovedByForeman, item.UserId);
            return MachineIncidentSelect(item.Id);
        }

        public MachineIncidentSelect? MachineIncidentAwaitingApproval(MachineIncidentAwaitingApproval item)
        {
            _ = ExecuteSingle<MachineIncidentSelectForBackEnd>(
"EXEC dbo.MachineIncidentAwaitingApproval @p0, @p1",
item.Id,
item.UserId
);
            InsertEvent(item.Id, item.UserId, MachineIncidentEventType.ApprovedByCounterParty, item.UserId);
            return MachineIncidentSelect(item.Id);
        }
        public MachineIncidentSelect? MachineIncidentClosed(MachineIncidentClosed item)
        {
            _ = ExecuteSingle<MachineIncidentSelectForBackEnd>(
"EXEC dbo.MachineIncidentClosed @p0, @p1",
item.Id,
item.UserId
);
            InsertEvent(item.Id, item.UserId, MachineIncidentEventType.Closed, item.UserId);
            return MachineIncidentSelect(item.Id);
        }
        public MachineIncidentSelect? MachineIncidentCanceled(MachineIncidentCanceled item)
        {
            _ = ExecuteSingle<MachineIncidentSelectForBackEnd>(
"EXEC dbo.MachineIncidentCanceled @p0, @p1",
item.Id,
item.UserId
);
            InsertEvent(item.Id, item.UserId, MachineIncidentEventType.CancelledByCounterParty, item.UserId);
            return MachineIncidentSelect(item.Id);
        }
        public MachineIncidentSelect? MachineIncidentStart(List<MachineIncidentAssistantInsert> item)
        {
            MachineIncidentSelectForBackEnd MachineIncidentSelectForBackEnd = ExecuteSingle<MachineIncidentSelectForBackEnd>(
"EXEC dbo.MachineIncidentStart @p0, @p1",
item[0].CrashId,
item[0].UserId
);
            InsertEvent(item[0].CrashId, item[0].UserId, MachineIncidentEventType.Started, item[0].UserId);


            foreach (MachineIncidentAssistantInsert item1 in item)
            {
                _ = ExecuteSingle<MachineIncidentAssistantSelect>(
     "EXEC dbo.MachineIncidentAssistantInsert @p0, @p1,@p2, @p3",
     item1.CrashId,
     item1.UserId,
     item1.AssistantId,
     item1.TypeEnum
 );

                if (item1.TypeEnum == 1)
                {
                    InsertEvent(item1.CrashId, item1.UserId, MachineIncidentEventType.MasterAdded, item1.AssistantId);
                    InsertEvent(item1.CrashId, item1.UserId, MachineIncidentEventType.StartedByMaster, item1.AssistantId);
                }
                else
                {
                    InsertEvent(item1.CrashId, item1.UserId, MachineIncidentEventType.HelperAdded, item1.AssistantId);
                }
            }

            return MachineIncidentSelect(MachineIncidentSelectForBackEnd.Id);
        }
        public MachineIncidentSelect? MachineIncidentAssistantInsert(List<MachineIncidentAssistantInsert> item)
        {

            MachineIncidentAssistantSelect? MachineIncidentAssistantSelect = new();

            foreach (MachineIncidentAssistantInsert item1 in item)
            {
                MachineIncidentAssistantSelect = ExecuteSingle<MachineIncidentAssistantSelect>(
     "EXEC dbo.MachineIncidentAssistantInsert @p0, @p1,@p2, @p3",
     item1.CrashId,
     item1.UserId,
     item1.AssistantId,
     item1.TypeEnum
 );

                if (item1.TypeEnum == 1)
                {
                    InsertEvent(item1.CrashId, item1.UserId, MachineIncidentEventType.MasterAdded, item1.AssistantId);
                }
                else
                {
                    InsertEvent(item1.CrashId, item1.UserId, MachineIncidentEventType.HelperAdded, item1.AssistantId);
                }
            }

            return MachineIncidentSelect(MachineIncidentAssistantSelect.CrashId);
        }
        public MachineIncidentSelect? MachineIncidentAccept(MachineIncidentAccept item)
        {
            MachineIncidentSelectForBackEnd MachineIncidentSelectForBackEnd = ExecuteSingle<MachineIncidentSelectForBackEnd>(
     "EXEC dbo.MachineIncidentAccept @p0, @p1",
     item.Id,
     item.UserId
 );
            InsertEvent(item.Id, item.UserId, MachineIncidentEventType.Accepted, item.UserId);
            return MachineIncidentSelect(MachineIncidentSelectForBackEnd.Id);
        }
        public MachineIncidentSelect? MachineIncidentTitleUpdate(MachineIncidentTitleUpdate item)
        {
            MachineIncidentSelectForBackEnd MachineIncidentSelectForBackEnd = ExecuteSingle<MachineIncidentSelectForBackEnd>(
                "EXEC dbo.MachineIncidentTitleUpdate @p0, @p1, @p2",
                item.Id,
                item.Title,
                item.UserId
            );
            InsertEvent(item.Id, item.UserId, MachineIncidentEventType.DescriptionChanged, item.UserId);
            return MachineIncidentSelect(MachineIncidentSelectForBackEnd.Id);
        }
        public MachineIncidentSelect? MachineIncidentProjectUpdate(MachineIncidentProjectUpdate item)
        {
            MachineIncidentSelectForBackEnd MachineIncidentSelectForBackEnd = ExecuteSingle<MachineIncidentSelectForBackEnd>(
    "EXEC dbo.MachineIncidentProjectUpdate @p0, @p1, @p2",
    item.Id,
    item.ProjectId,
    item.UserId
);
            InsertEvent(item.Id, item.UserId, MachineIncidentEventType.ProjectChanged, item.UserId);
            return MachineIncidentSelect(MachineIncidentSelectForBackEnd.Id);
        }
        public MachineIncidentSelect? MachineIncidentAssetUpdate(MachineIncidentAssetUpdate item)
        {
            MachineIncidentSelectForBackEnd MachineIncidentSelectForBackEnd = ExecuteSingle<MachineIncidentSelectForBackEnd>(
"EXEC dbo.MachineIncidentAssetUpdate @p0, @p1, @p2",
item.Id,
item.AssetId,
item.UserId
);
            InsertEvent(item.Id, item.UserId, MachineIncidentEventType.AssetChanged, item.UserId);
            return MachineIncidentSelect(MachineIncidentSelectForBackEnd.Id);
        }

        public MachineIncidentSelect? MachineIncidentWorkShiftUpdate(MachineIncidentWorkShiftUpdate item)
        {
            MachineIncidentWorkShiftSelect MachineIncidentSelectForBackEnd = ExecuteSingle<MachineIncidentWorkShiftSelect>(
"EXEC dbo.MachineIncidentWorkShiftUpdate @p0, @p1, @p2",
item.Id,
item.WorkShiftId,
item.UserId
);


            InsertEvent(MachineIncidentSelectForBackEnd.CrashId, item.UserId, MachineIncidentEventType.WorkShiftChanged, item.UserId);
            return MachineIncidentSelect(MachineIncidentSelectForBackEnd.CrashId);
        }


        public MachineIncidentSelect? MachineIncidentCrashTypeUpdate(MachineIncidentCrashTypeUpdate item)
        {
            MachineIncidentCrashTypeSelect MachineIncidentSelectForBackEnd = ExecuteSingle<MachineIncidentCrashTypeSelect>(
"EXEC dbo.MachineIncidentCrashTypeUpdate @p0, @p1, @p2",
item.Id,
item.CrashTypeId,
item.UserId
);


            InsertEvent(MachineIncidentSelectForBackEnd.CrashId, item.UserId, MachineIncidentEventType.TypeChanged, item.UserId);
            return MachineIncidentSelect(MachineIncidentSelectForBackEnd.CrashId);
        }


        public MachineIncidentSelect? MachineIncidentWorkOrderTypeUpdate(MachineIncidentWorkOrderTypeUpdate item)
        {
            MachineIncidentWorkOrderTypeSelect MachineIncidentSelectForBackEnd = ExecuteSingle<MachineIncidentWorkOrderTypeSelect>(
"EXEC dbo.MachineIncidentWorkOrderTypeUpdate @p0, @p1, @p2",
item.Id,
item.WorkOrderTypeId,
item.UserId
);


            InsertEvent(MachineIncidentSelectForBackEnd.CrashId, item.UserId, MachineIncidentEventType.ServiceTypeChanged, item.UserId);
            return MachineIncidentSelect(MachineIncidentSelectForBackEnd.CrashId);
        }
        #region Select Multi
        public List<MachineIncidentAssetSelectMulti>? MachineIncidentAssetSelectMulti(int Id)
        {

            return ExecuteList<MachineIncidentAssetSelectMulti>(
                "EXEC dbo.MachineIncidentAssetSelectMulti @p0", Id);
        }

        public List<MachineIncidentProjectSelectMulti>? MachineIncidentProjectSelectMulti()
        {
            return ExecuteList<MachineIncidentProjectSelectMulti>(
                "EXEC dbo.MachineIncidentProjectSelectMulti");
        }
        public List<MachineIncidentMaterialSelectMulti>? MachineIncidentMaterialSelectMulti()
        {
            return ExecuteList<MachineIncidentMaterialSelectMulti>(
                "EXEC dbo.MachineIncidentMaterialSelectMulti");
        }


        public List<MachineIncidentCrashTypeSelectMulti>? MachineIncidentCrashTypeSelectMulti()
        {
            return ExecuteList<MachineIncidentCrashTypeSelectMulti>(
                "EXEC dbo.MachineIncidentCrashTypeSelectMulti");
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




        public MachineIncidentSelect? MachineIncidentSelect(int Id)
        {
            MachineIncidentSelect? model = ExecuteSingle<MachineIncidentSelect>(
                "EXEC dbo.MachineIncidentSelect @p0",
                Id
            );

            if (model == null)
            {
                return null;
            }

            // 🔽 HAMISI EYNİ Id İLƏ
            model.MachineIncidentCrashTypeSelect =
                ExecuteList<MachineIncidentCrashTypeSelect>(
                    "EXEC dbo.MachineIncidentCrashTypeSelect @p0", Id);

            model.MachineIncidentAssistantSelect =
                ExecuteList<MachineIncidentAssistantSelect>(
                    "EXEC dbo.MachineIncidentAssistantSelect @p0", Id);

            model.MachineIncidentChatSelect =
                ExecuteList<MachineIncidentChatSelect>(
                    "EXEC dbo.MachineIncidentChatSelect @p0", Id);

            model.MachineIncidentCrashGroupSelect =
                ExecuteList<MachineIncidentCrashGroupSelect>(
                    "EXEC dbo.MachineIncidentCrashGroupSelect @p0", Id);

            model.MachineIncidentDocumentSelect =
                ExecuteList<MachineIncidentDocumentSelect>(
                    "EXEC dbo.MachineIncidentDocumentSelect @p0", Id);

            model.MachineIncidentEventSelect =
                ExecuteList<MachineIncidentEventSelect>(
                    "EXEC dbo.MachineIncidentEventSelect @p0", Id);

            model.MachineIncidentLostTimeSelect =
                ExecuteList<MachineIncidentLostTimeSelect>(
                    "EXEC dbo.MachineIncidentLostTimeSelect @p0", Id);

            model.MachineIncidentMaterialSelect =
                ExecuteList<MachineIncidentMaterialSelect>(
                    "EXEC dbo.MachineIncidentMaterialSelect @p0", Id);

            model.MachineIncidentSectionSelect =
                ExecuteList<MachineIncidentSectionSelect>(
                    "EXEC dbo.MachineIncidentSectionSelect @p0", Id);

            model.MachineIncidentStructureSelect =
                ExecuteList<MachineIncidentStructureSelect>(
                    "EXEC dbo.MachineIncidentStructureSelect @p0", Id);

            model.MachineIncidentTaskSelect =
                ExecuteList<MachineIncidentTaskSelect>(
                    "EXEC dbo.MachineIncidentTaskSelect @p0", Id);

            model.MachineIncidentWorkOrderTypeSelect =
                ExecuteList<MachineIncidentWorkOrderTypeSelect>(
                    "EXEC dbo.MachineIncidentWorkOrderTypeSelect @p0", Id);

            model.MachineIncidentWorkShiftSelect =
                ExecuteList<MachineIncidentWorkShiftSelect>(
                    "EXEC dbo.MachineIncidentWorkShiftSelect @p0", Id);
            model.MachineIncidentRecordSelect = ExecuteList<MachineIncidentRecordSelect>(
                    "EXEC dbo.MachineIncidentRecordSelect @p0", Id);

            return model;
        }



        #endregion

        #region Post

        public List<MachineIncidentSelectForBackEnd> Post(
            List<MachineIncidentInsert> inserts)
        {
            List<MachineIncidentSelectForBackEnd> insertedIncidents = [];

            using Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction =
                _ctx.Database.BeginTransaction();

            try
            {
                foreach (MachineIncidentInsert item in inserts)
                {
                    // 1️⃣ MAIN INSERT
                    MachineIncidentSelectForBackEnd? incident =
                        InsertMachineIncident(item) ?? throw new Exception("MachineIncidentInsert failed");

                    // 🔥 ÇOX VACİB – list-ə yığırıq
                    insertedIncidents.Add(incident);

                    // 2️⃣ RELATIONS
                    InsertCrashType(incident.Id, item);
                    InsertWorkOrderType(incident.Id, item);
                    InsertSection(incident.Id, item);
                    InsertStructure(incident.Id, item);
                    InsertWorkShift(incident.Id, item);

                    // 3️⃣ EVENTS
                    InsertCreatedEvent(incident.Id, item.UserId);
                    InsertAssignedEvent(
                        incident.Id,
                        item.UserId,
                        item.AsigntUserId
                    );
                }

                transaction.Commit();

                // ✅ ARTIQ DÜZGÜN QAYTARIR
                return insertedIncidents;
            }
            catch
            {
                transaction.Rollback();
                throw; // ❗ Service bunu tutacaq
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
            InsertEvent(incidentId, userId, MachineIncidentEventType.CreatedWithWorkerAssigned, assignUserId);
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
            return [.. _ctx.Set<T>()
                       .FromSqlRaw(sql)
                       .AsNoTracking()
                       .AsEnumerable()];
        }

        private T? ExecuteSingle<T>(string sql, params object[] parameters) where T : class
        {
            return _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()   // 🔥 VACİB
                       .FirstOrDefault();
        }

        private List<T>? ExecuteList<T>(string sql, params object[] parameters) where T : class
        {
            return [.. _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()];
        }























        #endregion





    }
}
