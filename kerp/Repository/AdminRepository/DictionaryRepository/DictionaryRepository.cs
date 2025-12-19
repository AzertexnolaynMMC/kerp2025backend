using kerp.Contexts;
using kerp.Enums;
using kerp.Prosedur.Admin.Dictionary;
using Microsoft.EntityFrameworkCore;

namespace kerp.Repository.AdminRepository.DictionaryRepository
{
    public class DictionaryRepository(KerpContext ctx) : IDictionaryRepository
    {
        private readonly KerpContext _ctx = ctx;
        public List<DictionaryAdminAll>? DictionaryAdminAll(LangAdminProc table)
        {



            return [.. _ctx.DictionaryAdminAll.FromSqlRaw(
          GetTable(table)
          )];
        }

        public List<DictionarySelect>? DictionarySelect(LangAdminProc table)
        {
            return [.. _ctx.DictionarySelect.FromSqlRaw(
          GetSelectTable(table)
          )];
        }

        public List<DictionaryAdminAll>? DictionaryInsertRequest(List<DictionaryInsertRequest> table)
        {
            List<DictionaryAdminAll> list = [];

            foreach (DictionaryInsertRequest item in table)
            {
                // Proc null ola bilər deyə yoxlayırıq
                if (item.Proc is null)
                {
                    continue; // istəsən burada throw da ata bilərsən
                }

                List<DictionaryAdminAll> rows = _ctx.DictionaryAdminAll
                    .FromSqlRaw(
                        GetInsertTable(item.Proc.Value),
                        item.LangId,
                        item.ExternalId,
                        item.Title,
                        item.UserId
                    )
                    .ToList();

                if (rows is { Count: > 0 })
                {
                    list.AddRange(rows);
                }
            }

            return list;
        }


        public List<DictionarySelectLanguage>? DictionarySelectLanguage()
        {
            return [.. _ctx.DictionarySelectLanguage.FromSqlRaw(
          "EXEC dbo.DictionarySelectLanguage "
          )];
        }
        private string GetTable(LangAdminProc proc)
        {
            return proc switch
            {
                LangAdminProc.AssetTypeLangAdminAll => "EXEC dbo.DictionarySelectAssetTypeLangAdmin",//+
                LangAdminProc.AssetTitleLangAdminAll => "EXEC dbo.DictionarySelectAssetTitleLangAdmin",//+
                LangAdminProc.CrashTypeLangAdminAll => "EXEC dbo.DictionarySelectCrashTypeLangAdmin",//+
                LangAdminProc.LoginTypeLangsAdminAll => "EXEC dbo.DictionarySelectLoginTypeLangsAdmin",//+
                LangAdminProc.MealTitleLangAdminAll => "EXEC dbo.DictionarySelectMealTitleLangAdmin",//+
                LangAdminProc.SectionLangAdminAll => "EXEC dbo.DictionarySelectSectionLangAdmin",//+
                LangAdminProc.WorkOrderTypeLangAdminAll => "EXEC dbo.DictionarySelectWorkOrderTypeLangAdmin",
                LangAdminProc.Structure => "EXEC dbo.DictionarySelectStructureAdmin",
                _ => throw new ArgumentOutOfRangeException(nameof(proc), proc, null)
            };
        }

        private string GetSelectTable(LangAdminProc proc)
        {
            return proc switch
            {
                LangAdminProc.AssetTypeLangAdminAll => "EXEC dbo.DictionarySelectAssetType",//+
                LangAdminProc.AssetTitleLangAdminAll => "EXEC dbo.DictionarySelectAssetTitle",//+
                LangAdminProc.CrashTypeLangAdminAll => "EXEC dbo.DictionarySelectCrashType",//+
                LangAdminProc.LoginTypeLangsAdminAll => "EXEC dbo.DictionarySelectLoginType",//+
                LangAdminProc.MealTitleLangAdminAll => "EXEC dbo.DictionarySelectMealTitle",//+
                LangAdminProc.SectionLangAdminAll => "EXEC dbo.DictionarySelectSection",//+
                LangAdminProc.WorkOrderTypeLangAdminAll => "EXEC dbo.DictionarySelectWorkOrderType",
                LangAdminProc.Structure => "EXEC dbo.DictionarySelectStructure",
                _ => throw new ArgumentOutOfRangeException(nameof(proc), proc, null)
            };
        }

        private string GetInsertTable(LangAdminProc proc)
        {
            return proc switch
            {
                LangAdminProc.AssetTypeLangAdminAll => "EXEC dbo.DictionaryInsertAssetTypeLang @p0, @p1, @p2, @p3",
                LangAdminProc.AssetTitleLangAdminAll => "EXEC dbo.DictionaryInsertAssetTitleLang @p0, @p1, @p2, @p3",
                LangAdminProc.CrashTypeLangAdminAll => "EXEC dbo.DictionaryInsertCrashTypeLang @p0, @p1, @p2, @p3",
                LangAdminProc.LoginTypeLangsAdminAll => "EXEC dbo.DictionaryInsertLoginTypeLangs @p0, @p1, @p2, @p3",
                LangAdminProc.MealTitleLangAdminAll => "EXEC dbo.DictionaryInsertMealTitleLang @p0, @p1, @p2, @p3",
                LangAdminProc.SectionLangAdminAll => "EXEC dbo.DictionaryInsertSectionLang @p0, @p1, @p2, @p3",
                LangAdminProc.WorkOrderTypeLangAdminAll => "EXEC dbo.DictionaryInsertWorkOrderTypeLang @p0, @p1, @p2, @p3",
                LangAdminProc.Structure => "EXEC dbo.DictionaryInsertStructure @p0, @p1, @p2, @p3",
                _ => throw new ArgumentOutOfRangeException(nameof(proc), proc, null)
            };
        }

        private string GetUpdateTable(LangAdminProc? proc)
        {
            return proc switch
            {
                LangAdminProc.AssetTypeLangAdminAll => "EXEC dbo.DictionaryUpdateAssetTypeLang @p0, @p1, @p2, @p3, @p4",
                LangAdminProc.AssetTitleLangAdminAll => "EXEC dbo.DictionaryUpdateAssetTitleLang @p0, @p1, @p2, @p3, @p4",
                LangAdminProc.CrashTypeLangAdminAll => "EXEC dbo.DictionaryUpdateCrashTypeLang @p0, @p1, @p2, @p3, @p4",
                LangAdminProc.LoginTypeLangsAdminAll => "EXEC dbo.DictionaryUpdateLoginTypeLang @p0, @p1, @p2, @p3, @p4",
                LangAdminProc.MealTitleLangAdminAll => "EXEC dbo.DictionaryUpdateMealTitleLang @p0, @p1, @p2, @p3, @p4",
                LangAdminProc.SectionLangAdminAll => "EXEC dbo.DictionaryUpdateSectionLang @p0, @p1, @p2, @p3, @p4",
                LangAdminProc.WorkOrderTypeLangAdminAll => "EXEC dbo.DictionaryUpdateWorkOrderTypeLang @p0, @p1, @p2, @p3, @p4",
                LangAdminProc.Structure => "EXEC dbo.DictionaryUpdateStructure @p0, @p1, @p2, @p3, @p4",
                _ => throw new ArgumentOutOfRangeException(nameof(proc), proc, null)
            };
        }


        private string GetStatusTable(LangAdminProc? proc)
        {
            return proc switch
            {
                LangAdminProc.AssetTypeLangAdminAll => "EXEC dbo.DictionaryStatusAssetTypeLang @p0, @p1, @p2",
                LangAdminProc.AssetTitleLangAdminAll => "EXEC dbo.DictionaryStatusAssetTitleLang @p0, @p1, @p2",
                LangAdminProc.CrashTypeLangAdminAll => "EXEC dbo.DictionaryStatusCrashTypeLang @p0, @p1, @p2",
                LangAdminProc.LoginTypeLangsAdminAll => "EXEC dbo.DictionaryStatusLoginTypeLangs @p0, @p1, @p2",
                LangAdminProc.MealTitleLangAdminAll => "EXEC dbo.DictionaryStatusMealTitleLang @p0, @p1, @p2",
                LangAdminProc.SectionLangAdminAll => "EXEC dbo.DictionaryStatusSectionLang @p0, @p1, @p2",
                LangAdminProc.WorkOrderTypeLangAdminAll => "EXEC dbo.DictionaryStatusWorkOrderTypeLang @p0, @p1, @p24",
                LangAdminProc.Structure => "EXEC dbo.DictionaryStatusStructure @p0, @p1, @p24",
                _ => throw new ArgumentOutOfRangeException(nameof(proc), proc, null)
            };
        }

        public DictionaryAdminAll DictionaryUpdate(DictionaryUpdate table)
        {
            return _ctx.DictionaryAdminAll
                     .FromSqlRaw(
                         GetUpdateTable(table.Proc),
                         table.Id,
                         table.LangId,
                         table.ExternalId,
                         table.Title,
                         table.UserId
                     )
                     .ToList().FirstOrDefault()!;
        }

        public DictionaryAdminAll DictionaryStatus(DictionaryStatus table)
        {
            return _ctx.DictionaryAdminAll
          .FromSqlRaw(
              GetStatusTable(table.Proc),
              table.Id,
              table.UserId,
              table.Status
          )
          .ToList().FirstOrDefault()!;
        }
    }
}
//      Dictionary

/*
  














 */