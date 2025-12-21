using kerp.Prosedur.Admin.Material;

namespace kerp.Repository.AdminRepository.MaterialRepository
{
    public interface IMaterialRepository
    {
        List<MaterialSelectAdmin>? Get();
        MaterialSelectAdmin? Delete(MaterialStatus StructureStatus);
        MaterialSelectAdmin? Post(MaterialInsert PageInsert);
        MaterialSelectAdmin? Put(MaterialUpdate StructureUpdate);
    }
}
