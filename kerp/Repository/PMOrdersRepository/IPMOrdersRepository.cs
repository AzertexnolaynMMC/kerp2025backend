using kerp.Prosedur.PMOrders;

namespace kerp.Repository.PMOrdersRepository
{
    public interface IPMOrdersRepository
    {
        PMOrdersSelect? GetPMOrder(int id);
        List<PMMaterialSelectMulti>? PMMaterialSelectMulti();
        PMOrdersSelect? PMOrderControllerLifeCrcyle(PMOrderControllerLifeCrcyle model);
        PMOrdersSelect? PMOrderSend(PMOrderControllerLifeCrcyle model);
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
    }
}
