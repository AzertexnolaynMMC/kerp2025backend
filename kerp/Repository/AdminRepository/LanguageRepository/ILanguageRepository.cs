using kerp.Prosedur.Admin.Language;

namespace kerp.Repository.AdminRepository.LanguageRepository
{
    public interface ILanguageRepository
    {
        List<LanguageAdminAll>? LanguageAdminAll();
        LanguageAdminAll? LanguageActiveAndDeaktive(LanguageActiveAndDeaktive LanguageActiveAndDeaktive);
        LanguageAdminAll? LanguageInsert(LanguageInsert LanguageInsert);
        LanguageAdminAll? LanguageUpdate(LanguageUpdate LanguageUpdate);
    }
}
