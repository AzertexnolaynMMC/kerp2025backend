using kerp.Prosedur.Admin.Project;

namespace kerp.Repository.AdminRepository.ProjectRepository
{
    public interface IProjectRepository
    {
        List<ProjectSelectAdmin>? Get();
        ProjectSelectAdmin? Delete(ProjectStatus StructureStatus);
        ProjectSelectAdmin? Post(ProjectInsert PageInsert);
        ProjectSelectAdmin? Put(ProjectUpdate StructureUpdate);
    }
}
