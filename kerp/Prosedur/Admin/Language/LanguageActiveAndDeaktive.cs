namespace kerp.Prosedur.Admin.Language
{
    public class LanguageActiveAndDeaktive
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        /// <summary>
        /// 0 = Pasif, 1 = Aktif (veya senin prosedürde ne kullanılıyorsa)
        /// </summary>
        public int Status { get; set; }
    }
}
