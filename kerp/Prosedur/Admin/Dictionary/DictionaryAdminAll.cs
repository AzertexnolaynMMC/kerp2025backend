namespace kerp.Prosedur.Admin.Dictionary
{
    public class DictionaryAdminAll
    {
        public int? Id { get; set; }

        public int? LangId { get; set; }
        public string? LangTitle { get; set; }

        // AssetTypeId, AssetTitleId, CrashTypeId və s. hamısı buraya ExternalId kimi düşür
        public int? ExternalId { get; set; }
        public string? ExternalTitle { get; set; }

        public string? Title { get; set; }

        // Status səndə nədirsə ona uyğun dəyiş: tinyint -> byte, bit -> bool və s.
        public bool? Status { get; set; }
    }
}
