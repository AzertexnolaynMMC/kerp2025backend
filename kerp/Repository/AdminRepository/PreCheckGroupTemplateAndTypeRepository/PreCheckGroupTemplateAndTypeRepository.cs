using kerp.Contexts;
using kerp.Prosedur.Admin.PreCheckGroup;
using kerp.Prosedur.Admin.PreCheckResultType;
using kerp.Prosedur.Admin.PreCheckTemplate;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.PreCheckGroupTemplateAndTypeRepository
{
    public class PreCheckGroupTemplateAndTypeRepository(KerpContext ctx) : IPreCheckGroupTemplateAndTypeRepository
    {
        private readonly KerpContext _ctx = ctx;

        #region Helpers
        private T? ExecuteSingle<T>(string sql, params object[] parameters) where T : class
        {
            return _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()
                       .FirstOrDefault();
        }

        private List<T>? ExecuteList<T>(string sql, params object[] parameters) where T : class
        {
            return _ctx.Set<T>()
                       .FromSqlRaw(sql, parameters)
                       .AsNoTracking()
                       .AsEnumerable()
                       .ToList();
        }
        #endregion

        #region PreCheckGroup
        public List<PreCheckGroupSelect>? GetPreCheckGroups()
        {
            return ExecuteList<PreCheckGroupSelect>("EXEC dbo.PreCheckGroupSelect");
        }

        public PreCheckGroupSelect? PostPreCheckGroup(PreCheckGroupInsert insertModel)
        {
            return ExecuteSingle<PreCheckGroupSelect>("EXEC dbo.PreCheckGroupInsert @p0, @p1",
                                                          insertModel.Title!,
                                                          insertModel.UserId);
        }

        public PreCheckGroupSelect? PutPreCheckGroup(PreCheckGroupUpdate updateModel)
        {
            return ExecuteSingle<PreCheckGroupSelect>("EXEC dbo.PreCheckGroupUpdate @p0, @p1, @p2",
                                                          updateModel.Id,
                                                          updateModel.Title!,
                                                          updateModel.UserId);
        }

        public PreCheckGroupSelect? DeletePreCheckGroup(PreCheckGroupStatusUpdate statusUpdate)
        {
            return ExecuteSingle<PreCheckGroupSelect>("EXEC dbo.PreCheckGroupStatusUpdate @p0, @p1",
                                                          statusUpdate.Id,
                                                          statusUpdate.UserId);
        }
        #endregion

        #region PreCheckTemplate
        public List<PreCheckTemplateSelect>? GetPreCheckTemplates()
        {
            return ExecuteList<PreCheckTemplateSelect>("EXEC dbo.PreCheckTemplateSelect");
        }

        public List<PreCheckTemplateGroupSelect>? GetPreCheckTemplateGroups()
        {
            return ExecuteList<PreCheckTemplateGroupSelect>("EXEC dbo.PreCheckTemplateGroupSelect");
        }

        public PreCheckTemplateSelect? PostPreCheckTemplate(PreCheckTemplateInsert insertModel)
        {
            return ExecuteSingle<PreCheckTemplateSelect>("EXEC dbo.PreCheckTemplateInsert @p0, @p1, @p2",
                                                             insertModel.Title!,
                                                             insertModel.PreCheckGroupId,
                                                             insertModel.UserId);
        }

        public PreCheckTemplateSelect? PutPreCheckTemplate(PreCheckTemplateUpdate updateModel)
        {
            return ExecuteSingle<PreCheckTemplateSelect>("EXEC dbo.PreCheckTemplateUpdate @p0, @p1, @p2, @p3",
                                                             updateModel.Id,
                                                             updateModel.Title!,
                                                             updateModel.PreCheckGroupId,
                                                             updateModel.UserId);
        }

        public PreCheckTemplateSelect? DeletePreCheckTemplate(PreCheckTemplateStatusUpdate statusUpdate)
        {
            return ExecuteSingle<PreCheckTemplateSelect>("EXEC dbo.PreCheckTemplateStatusUpdate @p0, @p1",
                                                             statusUpdate.Id,
                                                             statusUpdate.UserId);
        }
        #endregion

        #region PreCheckResultType
        public List<PreCheckResultTypeSelect>? GetPreCheckResultTypes()
        {
            return ExecuteList<PreCheckResultTypeSelect>("EXEC dbo.PreCheckResultTypeSelect");
        }

        public PreCheckResultTypeSelect? PostPreCheckResultType(PreCheckResultTypeInsert insertModel)
        {
            return ExecuteSingle<PreCheckResultTypeSelect>("EXEC dbo.PreCheckResultTypeInsert @p0, @p1, @p2, @p3",
                                                              insertModel.Title!,
                                                              insertModel.Descreption,
                                                              insertModel.UserId,
                                                              insertModel.IsComment
                        );
        }

        public PreCheckResultTypeSelect? PutPreCheckResultType(PreCheckResultTypeUpdate updateModel)
        {
            return ExecuteSingle<PreCheckResultTypeSelect>("EXEC dbo.PreCheckResultTypeUpdate @p0, @p1, @p2, @p3, @p4",
                                                              updateModel.Id,
                                                              updateModel.Title!,
                                                              updateModel.Descreption,
                                                              updateModel.UserId,
                                                              updateModel.IsComment);
        }

        public PreCheckResultTypeSelect? DeletePreCheckResultType(PreCheckResultTypeStatusUpdate statusUpdate)
        {
            return ExecuteSingle<PreCheckResultTypeSelect>("EXEC dbo.PreCheckResultTypeStatusUpdate @p0, @p1",
                                                              statusUpdate.Id,
                                                              statusUpdate.UserId);
        }
        #endregion
    }
}