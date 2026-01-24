
using kerp.Prosedur.MachineIncident.Document;
using kerp.Prosedur.MachineIncident.Incident;
using kerp.Prosedur.MachineIncident.MachineIncidentAssistant;
using kerp.Prosedur.MachineIncident.MachineIncidentDocument;
using kerp.Prosedur.MachineIncident.MachineIncidentWorkShift;
using kerp.Prosedur.MachineIncident.Task;
using kerp.Prosedur.MachineIncident.Type;
using kerp.Prosedur.MachineIncident.WorkOrderType;

namespace kerp.Service.IncidentService
{
    public interface IIncidentService
    {
        Task<List<MachineIncidentSelectForBackEnd>> InsertAsync(
            List<MachineIncidentInsert> inserts);

        Task<int> MachineIncidentTitleUpdateAsync(MachineIncidentTitleUpdate Id);
        Task<int> MachineIncidentProjectUpdate(MachineIncidentProjectUpdate Id);
        Task<int> MachineIncidentAssetUpdate(MachineIncidentAssetUpdate Id);
        Task<int> MachineIncidentCrashTypeUpdate(MachineIncidentCrashTypeUpdate Id);
        Task<int> MachineIncidentWorkOrderTypeUpdate(MachineIncidentWorkOrderTypeUpdate Id);
        Task<int> MachineIncidentWorkShiftUpdate(MachineIncidentWorkShiftUpdate Id);
        Task<int> MachineIncidentAccept(MachineIncidentAccept Id);
        Task<int> MachineIncidentStart(List<MachineIncidentAssistantInsert> item);
        Task<int> MachineIncidentAssistantInsert(List<MachineIncidentAssistantInsert> item);
        Task<int> MachineIncidentAssistantStatus(MachineIncidentAssistantStatus item);
        Task<int> MachineIncidentDocumentInsert(MachineIncidentDocumentInsert item);
        Task<int> MachineIncidentDocumentStatus(MachineIncidentDocumentStatus item);
        Task<int> MachineIncidentTaskInsert(MachineIncidentTaskInsert item);
    }
}
