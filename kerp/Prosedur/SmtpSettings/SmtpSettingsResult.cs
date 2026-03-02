namespace kerp.Prosedur.SmtpSettings
{
    public class SmtpSettingsResult
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FromEmail { get; set; } = string.Empty;

    }
}
