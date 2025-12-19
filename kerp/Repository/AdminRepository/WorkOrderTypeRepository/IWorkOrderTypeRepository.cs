using kerp.Prosedur.Admin.WorkOrderType;

namespace kerp.Repository.AdminRepository.WorkOrderTypeRepository
{
    public interface IWorkOrderTypeRepository
    {
        List<WorkOrderTypeSelectAdmin>? Get();
        WorkOrderTypeSelectAdmin? Delete(WorkOrderTypeStatus StructureStatus);
        WorkOrderTypeSelectAdmin? Post(WorkOrderTypeInsert PageInsert);
        WorkOrderTypeSelectAdmin? Put(WorkOrderTypeUpdate StructureUpdate);
    }
}
