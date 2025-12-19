using kerp.Enums;

namespace kerp.Prosedur.Admin.Dictionary
{
    public class DictionaryInsertRequest
    {
        public LangAdminProc? Proc { get; set; }

        public int? LangId { get; set; }
        public int? UserId { get; set; }

        // AssetTypeId, AssetTitleId, CrashTypeId və s. hamısı buraya ExternalId kimi düşür
        public int? ExternalId { get; set; }

        public string? Title { get; set; }

        // Status səndə nədirsə ona uyğun dəyiş: tinyint -> byte, bit -> bool və s.
    }
}
