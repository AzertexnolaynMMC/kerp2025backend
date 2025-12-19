namespace kerp.SystemModel
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryMinutes { get; set; }

        // Varsayılan değerlerle birlikte bir constructor tanımlayabilirsin
        public JwtSettings()
        {
            Key = "41d1b3415f10ddaaa83b63f9978fb8b083be60820028fdcdf9089e266f6f625d"; // Varsayılan olarak kullanmak istediğin değer
            Issuer = "https://localhost:44381"; // Issuer değeri
            Audience = "https://localhost:44381/"; // Audience değeri
            ExpiryMinutes = 780; // Token geçerlilik süresi (dakika cinsinden)
        }
    }
}
