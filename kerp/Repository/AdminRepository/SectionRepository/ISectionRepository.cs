using kerp.Prosedur.Admin.Section;

namespace kerp.Repository.AdminRepository.SectionRepository
{
    public interface ISectionRepository
    {
        List<SectionSelectAdmin>? Get();
        List<SectionStructureSelect>? GetSectionStructureSelect();
        SectionSelectAdmin? Delete(SectionStatus StructureStatus);
        SectionSelectAdmin? Post(SectionInsert PageInsert);
        SectionSelectAdmin? Put(SectionUpdate StructureUpdate);
    }
}
