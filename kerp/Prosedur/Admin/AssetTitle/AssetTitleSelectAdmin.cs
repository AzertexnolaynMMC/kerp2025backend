namespace kerp.Prosedur.Admin.AssetTitle
{
    public class AssetTitleSelectAdmin
    {
        public int? Id { get; set; }


        public string? Title { get; set; }   // LEFT JOIN olduğu üçün null ola bilər

        // Status sütununun tipinə görə birini seç:
        public bool? Status { get; set; }
    }
}
