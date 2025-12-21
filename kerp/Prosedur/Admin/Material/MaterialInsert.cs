namespace kerp.Prosedur.Admin.Material
{
    public class MaterialInsert
    {
        public int? UserId { get; set; }

        public string? Code { get; set; }   // LEFT JOIN olduğu üçün null ola bilər

        public string? Title { get; set; }   // LEFT JOIN olduğu üçün null ola bilər
        public string? Measure { get; set; }   // LEFT JOIN olduğu üçün null ola bilər
    }
}
