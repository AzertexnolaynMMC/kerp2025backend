namespace kerp.Prosedur.Admin.Material
{
    public class MaterialSelectAdmin
    {
        public int? Id { get; set; }

        public string? Code { get; set; }   // LEFT JOIN olduğu üçün null ola bilər

        public string? Title { get; set; }   // LEFT JOIN olduğu üçün null ola bilər
        public string? Measure { get; set; }   // LEFT JOIN olduğu üçün null ola bilər

        // Status sütununun tipinə görə birini seç:
        public bool? Status { get; set; }
    }
}
