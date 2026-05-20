using kerp.Prosedur.Dsr.Assistant;
using kerp.Prosedur.Dsr.Chat;
using kerp.Prosedur.Dsr.Cost;
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

namespace kerp.Repository.DsrRepository
{
    public interface IDsrRepository
    {
        // TaskType
        List<DSRTaskTypeSelectAdmin>? DSRTaskTypeSelectAdmin();
        DSRTaskTypeSelectAdmin? DSRTaskTypeInsert(DSRTaskTypeInsert DSRTaskTypeInsert);
        DSRTaskTypeSelectAdmin? DSRTaskTypeUpdate(DSRTaskTypeUpdate DSRTaskTypeUpdate);
        DSRTaskTypeSelectAdmin? DSRTaskTypeStatus(DSRTaskTypeStatus DSRTaskTypeStatus);

        // WorkOrderType
        List<DSRWorkOrderTypeSelectMulti>? DSRWorkOrderTypeSelectMulti();
        List<DSRWorkOrderTypeSelect>? DSRWorkOrderTypeSelect(int DsrId);
        DSRWorkOrderTypeSelect? DSRWorkOrderTypeInsert(DSRWorkOrderTypeInsert DSRWorkOrderTypeInsert);

        // WorkShift
        List<DsrWorkShiftSelectMulti>? DsrWorkShiftSelectMulti();
        List<DSRWorkShiftSelect>? DSRWorkShiftSelect(int DsrId);
        DSRWorkShiftSelect? DSRWorkShiftInsert(DSRWorkShiftInsert DSRWorkShiftInsert);
        DSRWorkShiftSelect? DSRWorkShiftUpdate(DSRWorkShiftUpdate DSRWorkShiftUpdate);

        // TaskAssistant
        List<DSRTaskAssistantSelect>? DSRTaskAssistantSelect(int DsrId);
        DSRTaskAssistantSelect? DSRTaskAssistantInsert(DSRTaskAssistantInsert DSRTaskAssistantInsert);
        DSRTaskAssistantSelect? DSRTaskAssistantStatus(DSRTaskAssistantStatus DSRTaskAssistantStatus);



        // Event
        List<DSREventSelect>? DSREventSelect(int DsrId);
        DSREventSelect? DSREventInsert(DSREventInsert DSREventInsert);

        // Section
        List<DSRSectionSelect>? DSRSectionSelect(int DsrId);
        DSRSectionSelect? DSRSectionInsert(DSRSectionInsert DSRSectionInsert);

        // Structure
        List<DSRStructureSelect>? DSRStructureSelect(int DsrId);
        DSRStructureSelect? DSRStructureInsert(DSRStructureInsert DSRStructureInsert);

        // Task
        List<DSRTaskSelect>? DSRTaskSelect(int DsrId);
        DSRTaskSelect? DSRTaskInsert(DSRTaskInsert DSRTaskInsert);
        DSRTaskSelect? DSRTaskUpdate(DSRTaskUpdate DSRTaskUpdate);
        DSRTaskSelect? DSRTaskStatus(DSRTaskStatus DSRTaskStatus);

        // TaskComment
        List<DSRTaskCommentSelect>? DSRTaskCommentSelect(int DsrId);
        DSRTaskCommentSelect? DSRTaskCommentInsert(DSRTaskCommentInsert DSRTaskCommentInsert);
        DSRTaskCommentSelect? DSRTaskCommentUpdate(DSRTaskCommentUpdate DSRTaskCommentUpdate);
        DSRTaskCommentSelect? DSRTaskCommentDelete(DSRTaskCommentDelete DSRTaskCommentDelete);

        // DSR
        List<DSRSelect>? DSRInsert(List<DSRInsert> DSRInsert);
        DSRSelect? DSRSelect(int DsrId);
        List<DsrBackEndSelect>? DsrBackEndSelect(int DsrId);

        // Machine
        DSRMachineSelect? DSRMachineInsert(DSRMachineInsert DSRMachineInsert);
        DSRMachineSelect? DSRMachineSelect(int DsrId);

        // Chat
        List<DSRChatSelect>? DSRChatSelect(int DsrId);
        DSRChatSelect? DSRChatInsert(DSRChatInsert DSRChatInsert);

        // Document
        List<DSRDocumentSelect>? DSRDocumentSelect(int DsrId);
        DSRDocumentSelect? DSRDocumentInsert(DSRDocumentInsert DSRDocumentInsert);
        DSRDocumentSelect? DSRDocumentUpdate(DSRDocumentUpdate DSRDocumentUpdate);
        DSRDocumentSelect? DSRDocumentStatus(DSRDocumentStatus DSRDocumentStatus);

        // LostTime
        List<DSRLostTimeSelect>? DSRLostTimeSelect(int DsrId);
        DSRLostTimeSelect? DSRLostTimeInsert(DSRLostTimeInsert DSRLostTimeInsert);
        DSRLostTimeSelect? DSRLostTimeUpdate(DSRLostTimeUpdate DSRLostTimeUpdate);
        DSRLostTimeSelect? DSRLostTimeStatus(DSRLostTimeStatus DSRLostTimeStatus);

        // Material
        List<DSRMaterialSelectMulti>? DSRMaterialSelectMulti();
        List<DSRMaterialSelect>? DSRMaterialSelect(int DsrId);
        DSRMaterialSelect? DSRMaterialInsert(DSRMaterialInsert DSRMaterialInsert);
        DSRMaterialSelect? DSRMaterialUpdate(DSRMaterialUpdate DSRMaterialUpdate);
        DSRMaterialSelect? DSRMaterialStatus(DSRMaterialStatus DSRMaterialStatus);

        // Record
        List<DSRRecordSelect>? DSRRecordSelect(int DsrId);
        DSRRecordSelect? DSRRecordInsert(DSRRecordInsert DSRRecordInsert);
        DSRRecordSelect? DSRRecordUpdate(DSRRecordUpdate DSRRecordUpdate);
        DSRRecordSelect? DSRRecordStatus(DSRRecordStatus DSRRecordStatus);



        DSRSelect? DSRWorkOrderStarted(DSRControllerLifeCycle DSRControllerLifeCycle);
        DSRSelect? WorkOrderEvaluated(DSRControllerLifeCycle DSRControllerLifeCycle);
        DSRTaskAssistantSelect? DSRTaskAssistantAccepted(DSRTaskAssistantControllerLifeCycle DSRTaskAssistantControllerLifeCycle);
        DSRTaskAssistantSelect? DSRTaskAssistantDelivered(DSRTaskAssistantControllerLifeCycle DSRTaskAssistantControllerLifeCycle);
        DSRTaskAssistantSelect? DSRTaskAssistantRejected(DSRTaskAssistantReject DSRTaskAssistantReject);
        DSRSelect? DSRReject(DSRReject DSRTaskAssistantReject);
        DSRSelect? WorkOrderFinished(DSRControllerLifeCycle request);
        DSRSelect? WorkOrderClosed(DSRControllerLifeCycle request);

        // WorkOrderEvaluatedWorker
        List<DSRWorkOrderEvaluatedWorker>? DSRWorkOrderEvaluatedWorker(int DsrId);
        List<DSRWorkOrderEvaluatedAll>? DSRWorkOrderEvaluatedAll(int DsrId);
        DSRWorkOrderEvaluated? DSRWorkOrderEvaluated(int DsrId);

        // CostType
        List<DSRCostTypeSelect>? DSRCostTypeSelect();
        DSRCostSelect? DsrCostMaterialInsert(DsrCostMaterialInsert DSRCostInsert);
        List<DSRCostSelect>? DSRCostSelect(int DsrId);
        List<DsrCostMaterialSelect>? DsrCostMaterialSelect(int DsrId);
    }
}