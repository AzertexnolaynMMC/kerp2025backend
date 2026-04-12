using kerp.Prosedur.PMOrders;
using kerp.Prosedur.PMOrders.Asset;
using kerp.Prosedur.PMOrders.Assigness;
using kerp.Prosedur.PMOrders.Chat;
using kerp.Prosedur.PMOrders.CheckList;
using kerp.Prosedur.PMOrders.Doc;
using kerp.Prosedur.PMOrders.Material;
using kerp.Prosedur.PMOrders.Order;
using kerp.Prosedur.PMOrders.Record;

namespace kerp.Repository.PMOrdersRepository
{
    public interface IPMOrdersRepository
    {
        PMOrdersSelect? GetPMOrder(int id);
        List<PMMaterialSelectMulti>? PMMaterialSelectMulti();
        PMOrdersSelect? PMOrderControllerLifeCrcyle(PMOrderControllerLifeCrcyle model);
        PMOrdersSelect? PMOrderSend(PMOrderControllerLifeCrcyle model);
        PMOrdersSelect? PMOrderClosed(PMOrderClosed model);
        PMOrdersSelect? PMOrderConfirm(PMOrderControllerLifeCrcyle model);
        PMOrdersSelect? PMRecordInsert(PMRecordInsert model);
        PMOrdersSelect? PMRecordStatus(PMRecordStatus model);
        PMOrdersSelect? PMRecordUpdate(PMRecordUpdate model);
        PMOrdersSelect? PMDocumentsInsert(PMDocumentsInsert model);
        PMOrdersSelect? PMDocumentsStatus(PMDocumentsStatus model);
        PMOrdersSelect? PMDocumentsUpdate(PMDocumentsUpdate model);
        PMOrdersSelect? PMMaterialInsert(PMMaterialInsert model);
        PMOrdersSelect? PMMaterialUpdate(PMMaterialUpdate model);
        PMOrdersSelect? PMMaterialStatus(PMMaterialStatus model);
        PMOrdersSelect? PMChecklistExecutionUpdate(List<PMChecklistExecutionUpdate> model);

        PMOrdersSelect? PMAssigneesInsert(List<PMAssigneesInsert> model);
        PMOrdersSelect? PMAssigneesStatus(PMAssigneesStatus model);
        PMOrdersSelect? PMChatInsert(PMChatInsert model);
        PMOrdersSelect? PMOrdersCreateCM(PMOrdersCreateCM model);

        List<PMOrderAssetSelect>? PMOrderAssetSelect(int pmOrderId);
        PMOrdersSelect? PMOrderAssetInsert(List<PMOrderAssetInsert> model);
        PMOrdersSelect? PMOrderAssetStatus(PMOrderAssetStatus model);
    }
}
