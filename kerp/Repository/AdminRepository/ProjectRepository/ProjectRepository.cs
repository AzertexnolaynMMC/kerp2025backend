using kerp.Contexts;
using kerp.Prosedur.Admin.Project;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.ProjectRepository
{
    public class ProjectRepository(KerpContext ctx) : IProjectRepository
    {
        private readonly KerpContext _ctx = ctx;
        public ProjectSelectAdmin? Delete(ProjectStatus StructureStatus)
        {
            return _ctx.ProjectSelectAdmin.FromSqlRaw(
"EXEC dbo.ProjectStatus @p0, @p1, @p2",
StructureStatus.Id,
StructureStatus.Status,
StructureStatus.UserId

).ToList().FirstOrDefault();
        }

        public List<ProjectSelectAdmin>? Get()
        {
            return [.. _ctx.ProjectSelectAdmin.FromSqlRaw(
          "EXEC dbo.ProjectSelectAdmin "
          )];
        }

        public ProjectSelectAdmin? Post(ProjectInsert PageInsert)
        {
            return _ctx.ProjectSelectAdmin.FromSqlRaw(
"EXEC dbo.ProjectInsert @p0, @p1",
PageInsert.Title,
PageInsert.UserId

).ToList().FirstOrDefault();
        }

        public ProjectSelectAdmin? Put(ProjectUpdate StructureUpdate)
        {
            return _ctx.ProjectSelectAdmin.FromSqlRaw(
"EXEC dbo.ProjectUpdate @p0, @p1, @p2",
StructureUpdate.Id,
StructureUpdate.Title,
StructureUpdate.UserId

).ToList().FirstOrDefault();
        }
    }
}
