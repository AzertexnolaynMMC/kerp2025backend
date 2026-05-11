using kerp.Prosedur.MachineIncident.Incident;
using kerp.Prosedur.PMOrders;
using kerp.Prosedur.PMOrders.Asset;
using kerp.Prosedur.PMOrders.Assigness;
using kerp.Prosedur.PMOrders.Chat;
using kerp.Prosedur.PMOrders.CheckList;
using kerp.Prosedur.PMOrders.Doc;
using kerp.Prosedur.PMOrders.Material;
using kerp.Prosedur.PMOrders.Order;
using kerp.Prosedur.PMOrders.Record;

namespace kerp.Service.PmOrderService
{
    public interface IPmOrderService
    {
        Task<int> PMOrderControllerLifeCrcyle(PMOrderControllerLifeCrcyle Id);
        Task<int> PMOrderSend(PMOrderControllerLifeCrcyle Id);
        Task<int> PMOrderConfirm(PMOrderControllerLifeCrcyle Id);
        Task<int> PMOrderClosed(PMOrderClosed Id);
        Task<int> PMRecordInsert(PMRecordInsert Id);
        Task<int> PMRecordStatus(PMRecordStatus Id);
        Task<int> PMRecordUpdate(PMRecordUpdate Id);
        Task<int> PMDocumentsInsert(PMDocumentsInsert Id);
        Task<int> PMDocumentsStatus(PMDocumentsStatus Id);
        Task<int> PMDocumentsUpdate(PMDocumentsUpdate Id);
        Task<int> PMMaterialInsert(PMMaterialInsert Id);
        Task<int> PMMaterialUpdate(PMMaterialUpdate Id);
        Task<int> PMMaterialStatus(PMMaterialStatus Id);
        Task<int> PMChecklistExecutionUpdate(List<PMChecklistExecutionUpdate> Id);
        Task<int> PMAssigneesStatus(PMAssigneesStatus Id);
        Task<int> PMChatInsert(PMChatInsert Id);
        Task<int> PMOrdersCreateCM(PMOrdersCreateCM Id);
        Task<int> PMAssigneesInsert(List<PMAssigneesInsert> Id);

        Task<int> PMOrderAssetInsert(List<PMOrderAssetInsert> model);
        Task<int> PMOrderAssetStatus(PMOrderAssetStatus model);
        Task SendAndroidPushNotifications(List<MachineIncidentSelectForBackEnd> incidents);
    }
}
