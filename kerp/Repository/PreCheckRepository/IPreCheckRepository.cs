using kerp.Prosedur.PreCheck.Document;
using kerp.Prosedur.PreCheck.Event;
using kerp.Prosedur.PreCheck.Group;
using kerp.Prosedur.PreCheck.Incident;
using kerp.Prosedur.PreCheck.Pre;
using kerp.Prosedur.PreCheck.Record;
using kerp.Prosedur.PreCheck.ResultType;
using kerp.Prosedur.PreCheck.Section;
using kerp.Prosedur.PreCheck.Structure;
using kerp.Prosedur.PreCheck.Template;
using kerp.Prosedur.PreCheck.WorkOrder;
using kerp.Prosedur.PreCheck.WorkShift;

namespace kerp.Repository.PreCheckRepository
{
    public interface IPreCheckRepository
    {
        // =========================
        // EVENT
        // =========================
        PreCheckEventSelect? PreCheckEventInsert(PreCheckEventInsert request);
        List<PreCheckEventSelect>? PreCheckEventSelect(int id);
        List<PreCheckEventsSelectMulti>? PreCheckEventsSelectMulti(int id);

        // =========================
        // GROUP
        // =========================
        List<PreCheckGroupSelectForInsert>? PreCheckGroupSelectForInsert();

        // =========================
        // PRECHECK
        // =========================
        List<PreCheckSelect>? PreCheckInsert(List<PreCheckInsert> request);
        PreCheckSelect? PreCheckSelect(int id);

        // =========================
        // RESULT TYPE
        // =========================
        List<PreCheckResultTypeSelectForInsert>? PreCheckResultTypeSelectForInsert();

        // =========================
        // SECTION
        // =========================
        PreCheckSectionSelect? PreCheckSectionInsert(PreCheckSectionInsert request);
        List<PreCheckSectionSelect>? PreCheckSectionSelect(int id);

        // =========================
        // STRUCTURE
        // =========================
        PreCheckStructureSelect? PreCheckStructureInsert(PreCheckStructureInsert request);
        List<PreCheckStructureSelect>? PreCheckStructureSelect(int id);

        // =========================
        // TEMPLATE
        // =========================
        PreCheckTemplateExecuteSelect? PreCheckTemplateExecuteInsert(PreCheckTemplateExecuteInsert request);
        List<PreCheckTemplateExecuteSelect>? PreCheckTemplateExecuteSelect(int id);
        List<PreCheckTemplateSelectForInsert>? PreCheckTemplateSelectForInsert();

        // =========================
        // WORK ORDER
        // =========================
        PreCheckWorkOrderSelect? PreCheckWorkOrderInsert(PreCheckWorkOrderInsert request);
        List<PreCheckWorkOrderSelect>? PreCheckWorkOrderSelect(int id);

        List<PreCheckWorkOrderTypeLangSelectForInsert>? PreCheckWorkOrderTypeLangSelectForInsert();
        List<PreCheckWorkShiftSelectForInsert>? PreCheckWorkShiftSelectForInsert();

        // =========================
        // DOCUMENT
        // =========================
        List<PreCheckDocumentSelect>? PreCheckDocumentSelect(int id);
        PreCheckSelect? PreCheckDocumentInsert(PreCheckDocumentInsert request);
        PreCheckSelect? PreCheckDocumentUpdate(PreCheckDocumentUpdate request);
        PreCheckSelect? PreCheckDocumentStatus(PreCheckDocumentStatus request);

        // =========================
        // RECORD
        // =========================
        List<PreCheckRecordSelect>? PreCheckRecordSelect(int id);

        PreCheckSelect? PreCheckRecordInsert(PreCheckRecordInsert request);
        PreCheckSelect? PreCheckRecordUpdate(PreCheckRecordUpdate request);
        PreCheckSelect? PreCheckRecordStatus(PreCheckRecordStatus request);
        PreCheckSelect? Accepted(PreCheckControllerLifeCircle request);
        PreCheckSelect? InReview(PreCheckControllerLifeCircle request);
        PreCheckSelect? Approved(PreCheckControllerLifeCircle request);
        PreCheckSelect? Closed(PreCheckControllerLifeCircle request);
        PreCheckSelect? ElectricalController(PreCheckEventInsert request);
        PreCheckSelect? MechanicalController(PreCheckEventInsert request);

        List<PreCheckCrashTypeForIncidentSelect>? PreCheckCrashTypeForIncidentSelect();
        List<PreCheckProjectForIncidentSelect>? PreCheckProjectForIncidentSelect();
        List<PreCheckWorkOrderTypeForIncidentSelect>? PreCheckWorkOrderTypeForIncidentSelect();
        List<PreCheckWorkShiftForIncidentSelect>? PreCheckWorkShiftForIncidentSelect();
        List<PreCheckUserSelect>? PreCheckUserSelect(int id);
        PreCheckSelect? PreCheckCreateCM(PreCheckCreateCM request);


    }
}