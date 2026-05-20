using kerp.Prosedur.Dsr.Assistant;
using kerp.Prosedur.Dsr.Chat;
using kerp.Prosedur.Dsr.Cost;
using kerp.Prosedur.Dsr.Document;
using kerp.Prosedur.Dsr.Dsrs;
using kerp.Prosedur.Dsr.LostTime;
using kerp.Prosedur.Dsr.Material;
using kerp.Prosedur.Dsr.Record;
using kerp.Prosedur.Dsr.Task;
using kerp.Prosedur.Dsr.TaskComment;
using kerp.Prosedur.Dsr.WorkShift;

namespace kerp.Service.DsrService
{
    public interface IDsrService
    {
        // DSR
        Task<int> DSRInsert(List<DSRInsert> request);
        // WorkShift
        Task<int> DSRWorkShiftUpdate(DSRWorkShiftUpdate request);
        // Task
        Task<int> DSRTaskInsert(DSRTaskInsert request);
        Task<int> DSRTaskUpdate(DSRTaskUpdate request);
        Task<int> DSRTaskStatus(DSRTaskStatus request);

        // TaskAssistant
        Task<int> DSRTaskAssistantInsert(DSRTaskAssistantInsert request);
        Task<int> DSRTaskAssistantStatus(DSRTaskAssistantStatus request);

        // TaskComment
        Task<int> DSRTaskCommentInsert(DSRTaskCommentInsert request);
        Task<int> DSRTaskCommentUpdate(DSRTaskCommentUpdate request);
        Task<int> DSRTaskCommentDelete(DSRTaskCommentDelete request);

        // Chat
        Task<int> DSRChatInsert(DSRChatInsert request);

        // Document
        Task<int> DSRDocumentInsert(DSRDocumentInsert request);
        Task<int> DSRDocumentUpdate(DSRDocumentUpdate request);
        Task<int> DSRDocumentStatus(DSRDocumentStatus request);

        // LostTime
        Task<int> DSRLostTimeInsert(DSRLostTimeInsert request);
        Task<int> DSRLostTimeUpdate(DSRLostTimeUpdate request);
        Task<int> DSRLostTimeStatus(DSRLostTimeStatus request);

        // Material
        Task<int> DSRMaterialInsert(DSRMaterialInsert request);
        Task<int> DSRMaterialUpdate(DSRMaterialUpdate request);
        Task<int> DSRMaterialStatus(DSRMaterialStatus request);

        // Record
        Task<int> DSRRecordInsert(DSRRecordInsert request);
        Task<int> DSRRecordUpdate(DSRRecordUpdate request);
        Task<int> DSRRecordStatus(DSRRecordStatus request);
        Task<int> DSRWorkOrderStarted(DSRControllerLifeCycle request);
        Task<int> WorkOrderClosed(DSRControllerLifeCycle request);
        Task<int> WorkOrderEvaluated(DSRControllerLifeCycle request);
        Task<int> DSRTaskAssistantDelivered(DSRTaskAssistantControllerLifeCycle request);
        Task<int> DSRTaskAssistantRejected(DSRTaskAssistantReject request);
        Task<int> DSRReject(DSRReject request);
        Task<int> WorkOrderFinished(DSRControllerLifeCycle request);
        Task<int> DsrCostMaterialInsert(DsrCostMaterialInsert request);
    }
}
