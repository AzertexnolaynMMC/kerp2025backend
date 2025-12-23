namespace kerp.Prosedur.Admin.Asset
{
    public class AssetSelectAdmin
    {
        public int Id { get; set; }

        public int? AssetTitleId { get; set; }
        public string? AssetTitle { get; set; }         // atl.Title

        public int? AssetTypeId { get; set; }
        public string? AssetTypeTitle { get; set; }     // aty.Title

        public int? StructureId { get; set; }
        public string? StructureTitle { get; set; }     // st.Title

        public bool Status { get; set; }                // SQL bit -> C# bool

        public int? UnderAssetId { get; set; }
    }
}
