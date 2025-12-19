using kerp.Enums;

namespace kerp.Prosedur.Admin.Dictionary
{
    public class DictionaryUpdate
    {
        public LangAdminProc Proc { get; set; }

        public int? Id { get; set; }
        public int? LangId { get; set; }
        public int? ExternalId { get; set; }
        public string? Title { get; set; }
        public int? UserId { get; set; }

        // AssetTypeId, AssetTitleId, CrashTypeId və s. hamısı buraya ExternalId kimi düşür

    }
}
