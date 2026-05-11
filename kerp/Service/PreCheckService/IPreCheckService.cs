using kerp.Prosedur.PreCheck.Document;
using kerp.Prosedur.PreCheck.Event;
using kerp.Prosedur.PreCheck.Incident;
using kerp.Prosedur.PreCheck.Pre;
using kerp.Prosedur.PreCheck.Record;

namespace kerp.Service.PreCheckService
{
    public interface IPreCheckService
    {
        Task<int> PreCheckInsert(List<PreCheckInsert> request);
        // =========================
        // DOCUMENT
        // =========================
        Task<int> PreCheckDocumentInsert(PreCheckDocumentInsert request);
        Task<int> PreCheckDocumentUpdate(PreCheckDocumentUpdate request);
        Task<int> PreCheckDocumentStatus(PreCheckDocumentStatus request);

        // =========================
        // RECORD
        // =========================
        Task<int> PreCheckRecordInsert(PreCheckRecordInsert request);
        Task<int> PreCheckRecordUpdate(PreCheckRecordUpdate request);
        Task<int> PreCheckRecordStatus(PreCheckRecordStatus request);

        // =========================
        // LIFECYCLE (KANBAN)
        // =========================
        Task<int> Accepted(PreCheckControllerLifeCircle request);
        Task<int> InReview(PreCheckControllerLifeCircle request);
        Task<int> Approved(PreCheckControllerLifeCircle request);
        Task<int> Closed(PreCheckControllerLifeCircle request);
        // =========================
        // CONTROLLER CHECK
        // =========================
        Task<int> ElectricalController(PreCheckEventInsert request);
        Task<int> MechanicalController(PreCheckEventInsert request);
        // =========================
        // CM (NEW)
        // =========================
        Task<int> PreCheckCreateCM(PreCheckCreateCM request);
    }
}
