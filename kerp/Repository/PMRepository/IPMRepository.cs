using kerp.Prosedur.Pm.PMChecklistTemplate;
using kerp.Prosedur.Pm.PmGroup;
using kerp.Prosedur.Pm.PMSchedule;
using kerp.Prosedur.Pm.PMScheduleAssignees;
using kerp.Prosedur.Pm.PMScheduleStructure;
using kerp.Prosedur.Pm.PMScheduleWorkOrderType;

namespace kerp.Repository.PMRepository
{
    public interface IPMRepository
    {
        List<PMChecklistGroupSelect>? GetGroup();
        PMChecklistGroupSelect? PostGroup(PMChecklistGroupInsert request);
        PMChecklistGroupSelect? PutGroup(PMChecklistGroupUpdate request);
        PMChecklistGroupSelect? StatusUpdateGroup(PMChecklistGroupStatusUpdate request);

        // Template
        List<PMChecklistTemplateSelect>? GetTemplate(int groupId);
        PMChecklistTemplateSelect? PostTemplate(PMChecklistTemplateInsert request);
        PMChecklistTemplateSelect? PutTemplate(PMChecklistTemplateUpdate request);
        PMChecklistTemplateSelect? StatusUpdateTemplate(PMChecklistTemplateStatusUpdate request);
        List<PMChecklistTemplateSelect>? ReorderTemplate(PMChecklistTemplateReorderRequest request);

        List<PMScheduleStructureSelect>? GetScheduleStructures(int pmScheduleId);
        PMScheduleStructureSelect? InsertScheduleStructure(PMScheduleStructureInsert request);
        PMScheduleStructureSelect? UpdateScheduleStructure(PMScheduleStructureUpdate request);

        List<PMScheduleWorkOrderTypeSelect>? GetScheduleWorkOrderTypes(int pmScheduleId);
        List<PMScheduleWorkOrderTypeSelectMulti>? GetPMScheduleWorkOrderTypeSelectMulti();
        PMScheduleWorkOrderTypeSelect? InsertScheduleWorkOrderType(PMScheduleWorkOrderTypeInsert request);
        PMScheduleWorkOrderTypeSelect? UpdateScheduleWorkOrderType(PMScheduleWorkOrderTypeUpdate request);


        List<PMScheduleAssigneesSelect>? GetScheduleAssignees(int pmScheduleId);
        PMScheduleAssigneesSelect? InsertScheduleAssignee(PMScheduleAssigneesInsert request);
        List<PMScheduleAssigneesSelect>? InsertScheduleAssignees(List<PMScheduleAssigneesInsert> request);
        PMScheduleAssigneesSelect? RoleUpdateScheduleAssignee(PMScheduleAssigneesRoleUpdate request);
        PMScheduleAssigneesSelect? StatusUpdateScheduleAssignee(PMScheduleAssigneesStatusUpdate request);


        List<PMScheduleSelect>? GetSchedules(string structureId);
        PMScheduleSelect? InsertSchedule(PMScheduleInsert request);
        PMScheduleSelect? UpdateSchedule(PMScheduleUpdate request);
        PMScheduleSelect? StatusUpdateSchedule(PMScheduleStatusUpdate request);
    }
}
