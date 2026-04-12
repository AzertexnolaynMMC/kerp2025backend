using kerp.Prosedur.Admin.PreCheckGroup;
using kerp.Prosedur.Admin.PreCheckResultType;
using kerp.Prosedur.Admin.PreCheckTemplate;

namespace kerp.Repository.AdminRepository.PreCheckGroupTemplateAndTypeRepository
{
    public interface IPreCheckGroupTemplateAndTypeRepository
    {
        // PreCheckGroup
        List<PreCheckGroupSelect>? GetPreCheckGroups();
        PreCheckGroupSelect? DeletePreCheckGroup(PreCheckGroupStatusUpdate statusUpdate);
        PreCheckGroupSelect? PostPreCheckGroup(PreCheckGroupInsert insertModel);
        PreCheckGroupSelect? PutPreCheckGroup(PreCheckGroupUpdate updateModel);

        // PreCheckTemplate
        List<PreCheckTemplateSelect>? GetPreCheckTemplates();
        PreCheckTemplateSelect? DeletePreCheckTemplate(PreCheckTemplateStatusUpdate statusUpdate);
        PreCheckTemplateSelect? PostPreCheckTemplate(PreCheckTemplateInsert insertModel);
        PreCheckTemplateSelect? PutPreCheckTemplate(PreCheckTemplateUpdate updateModel);
        List<PreCheckTemplateGroupSelect>? GetPreCheckTemplateGroups();

        // PreCheckResultType
        List<PreCheckResultTypeSelect>? GetPreCheckResultTypes();
        PreCheckResultTypeSelect? DeletePreCheckResultType(PreCheckResultTypeStatusUpdate statusUpdate);
        PreCheckResultTypeSelect? PostPreCheckResultType(PreCheckResultTypeInsert insertModel);
        PreCheckResultTypeSelect? PutPreCheckResultType(PreCheckResultTypeUpdate updateModel);

    }
}
