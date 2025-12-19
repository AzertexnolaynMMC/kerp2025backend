using kerp.Enums;
using kerp.Prosedur.Admin.Dictionary;

namespace kerp.Repository.AdminRepository.DictionaryRepository
{
    public interface IDictionaryRepository
    {
        List<DictionaryAdminAll>? DictionaryAdminAll(LangAdminProc table);
        List<DictionaryAdminAll>? DictionaryInsertRequest(List<DictionaryInsertRequest> table);
        DictionaryAdminAll DictionaryUpdate(DictionaryUpdate table);
        DictionaryAdminAll DictionaryStatus(DictionaryStatus table);
        List<DictionarySelect>? DictionarySelect(LangAdminProc table);
        List<DictionarySelectLanguage>? DictionarySelectLanguage();
        // DictionaryAdminAll? LanguageActiveAndDeaktive(LanguageActiveAndDeaktive LanguageActiveAndDeaktive);
        // DictionaryAdminAll? LanguageInsert(LanguageInsert LanguageInsert);
        //DictionaryAdminAll? LanguageUpdate(LanguageUpdate LanguageUpdate);
    }
}
