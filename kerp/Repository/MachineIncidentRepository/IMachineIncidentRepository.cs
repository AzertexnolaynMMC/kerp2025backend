using kerp.Prosedur.MachineIncident.Document;
using kerp.Prosedur.MachineIncident.Event;
using kerp.Prosedur.MachineIncident.Incident;
using kerp.Prosedur.MachineIncident.MachineIncidentAssistant;
using kerp.Prosedur.MachineIncident.MachineIncidentChat;
using kerp.Prosedur.MachineIncident.MachineIncidentDocument;
using kerp.Prosedur.MachineIncident.MachineIncidentLostTime;
using kerp.Prosedur.MachineIncident.MachineIncidentTask;
using kerp.Prosedur.MachineIncident.MachineIncidentWorkShift;
using kerp.Prosedur.MachineIncident.Material;
using kerp.Prosedur.MachineIncident.Record;
using kerp.Prosedur.MachineIncident.SelectModels;
using kerp.Prosedur.MachineIncident.Task;
using kerp.Prosedur.MachineIncident.Type;
using kerp.Prosedur.MachineIncident.WorkOrderType;

namespace kerp.Repository.MachineIncidentRepository
{
    public interface IMachineIncidentRepository
    {
        List<MachineIncidentAssetSelectMulti>? MachineIncidentAssetSelectMulti(int Id);
        List<MachineIncidentMaterialSelectMulti>? MachineIncidentMaterialSelectMulti();
        List<MachineIncidentCrashTypeSelectMulti>? MachineIncidentCrashTypeSelectMulti();
        List<MachineIncidentProjectSelectMulti>? MachineIncidentProjectSelectMulti();
        List<MachineIncidentWorkOrderTypeSelectMulti>? MachineIncidentWorkOrderTypeSelectMulti();
        List<MachineIncidentWorkShiftSelectMulti>? MachineIncidentWorkShiftSelectMulti();
        List<MachineIncidentSelectForBackEnd> Post(List<MachineIncidentInsert> MachineIncidentInsert);
        MachineIncidentSelect? MachineIncidentSelect(int Id);
        MailMachineIncidentResult? MailMachineIncidentResult(int Id);
        MachineIncidentSelect? MachineIncidentTitleUpdate(MachineIncidentTitleUpdate Id);
        MachineIncidentSelect? MachineIncidentProjectUpdate(MachineIncidentProjectUpdate Id);
        MachineIncidentSelect? MachineIncidentAssetUpdate(MachineIncidentAssetUpdate Id);
        MachineIncidentSelect? MachineIncidentCrashTypeUpdate(MachineIncidentCrashTypeUpdate item);
        MachineIncidentSelect? MachineIncidentWorkOrderTypeUpdate(MachineIncidentWorkOrderTypeUpdate item);
        MachineIncidentSelect? MachineIncidentWorkShiftUpdate(MachineIncidentWorkShiftUpdate item);
        MachineIncidentSelect? MachineIncidentAccept(MachineIncidentAccept item);
        MachineIncidentSelect? MachineIncidentStart(List<MachineIncidentAssistantInsert> item);
        MachineIncidentSelect? MachineIncidentAssistantInsert(List<MachineIncidentAssistantInsert> item);
        MachineIncidentSelect? MachineIncidentAssistantStatus(MachineIncidentAssistantStatus item);
        MachineIncidentSelect? MachineIncidentDocumentInsert(MachineIncidentDocumentInsert item);
        MachineIncidentSelect? MachineIncidentDocumentStatus(MachineIncidentDocumentStatus item);
        MachineIncidentSelect? MachineIncidentTaskInsert(MachineIncidentTaskInsert item);
        MachineIncidentSelect? MachineIncidentTaskTitleCrashTypeUpdate(MachineIncidentTaskTitleCrashTypeUpdate item);
        MachineIncidentSelect? MachineIncidentTaskStatus(MachineIncidentTaskStatus item);
        MachineIncidentSelect? MachineIncidentMaterialInsert(MachineIncidentMaterialInsert item);
        MachineIncidentSelect? MachineIncidentMaterialStatus(MachineIncidentMaterialStatus item);
        MachineIncidentSelect? MachineIncidentResolved(MachineIncidentResolved item);
        MachineIncidentSelect? MachineIncidentAwaitingApproval(MachineIncidentAwaitingApproval item);
        MachineIncidentSelect? MachineIncidentClosed(MachineIncidentClosed item);
        MachineIncidentSelect? MachineIncidentCanceled(MachineIncidentCanceled item);
        MachineIncidentSelect? MachineIncidentReject(MachineIncidentReject item);
        MachineIncidentSelect? MachineIncidentRecordInsert(MachineIncidentRecordInsert item);
        MachineIncidentSelect? MachineIncidentRecordUpdate(MachineIncidentRecordUpdate item);
        MachineIncidentSelect? MachineIncidentRecordStatus(MachineIncidentRecordStatus item);
        MachineIncidentSelect? MachineIncidentChatInsert(MachineIncidentChatInsert item);
        MachineIncidentSelect? MachineIncidentLostTimeInsert(MachineIncidentLostTimeInsert item);
        MachineIncidentSelect? MachineIncidentLostTimeStatus(MachineIncidentLostTimeStatus item);
        MachineIncidentSelect? MachineIncidentEventUpdate(MachineIncidentEventUpdate item);

        MachineIncidentSelectForBackEnd? GetMachineIncidentForBackEnd(int id);
    }
}
