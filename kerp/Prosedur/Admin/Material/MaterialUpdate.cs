namespace kerp.Prosedur.Admin.Material
{
    public class MaterialUpdate
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }

        public string? Code { get; set; }   // LEFT JOIN olduğu üçün null ola bilər

        public string? Title { get; set; }   // LEFT JOIN olduğu üçün null ola bilər
        public string? Measure { get; set; }
    }
}
