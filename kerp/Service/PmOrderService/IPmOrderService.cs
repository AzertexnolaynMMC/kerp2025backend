using kerp.Prosedur.PMOrders;

namespace kerp.Service.PmOrderService
{
    public interface IPmOrderService
    {
        Task<int> PMOrderControllerLifeCrcyle(PMOrderControllerLifeCrcyle Id);
        Task<int> PMOrderSend(PMOrderControllerLifeCrcyle Id);
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
        Task<int> PMAssigneesInsert(List<PMAssigneesInsert> Id);
    }
}
