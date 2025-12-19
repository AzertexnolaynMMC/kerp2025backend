using kerp.Prosedur.Structure;

namespace kerp.Repository.AdminRepository.StructureRepository
{
    public interface IStructureRepository
    {
        List<StructureSelectAdmin>? StructureSelectAdmin();
        StructureSelectAdmin? StructureStatus(StructureStatus StructureStatus);
        StructureSelectAdmin? StructureInsert(StructureInsert PageInsert);
        StructureSelectAdmin? StructureUpdate(StructureUpdate StructureUpdate);
    }
}
