namespace kerp.Prosedur.Admin.Logs
{
    public class AppLogsInsert
    {
        public int? UserId { get; set; }
        public DateTime TimestampUtc { get; set; }          // UTC olmalıdır
        public string Level { get; set; } = default!;       // "INFO","ERROR"...
        public string Message { get; set; } = default!;

        public string? Env { get; set; }
        public string? Service { get; set; }
        public string? Logger { get; set; }
        public string? AppVersion { get; set; }

        public string? Host { get; set; }
        public string? TraceId { get; set; }
        public string? SpanId { get; set; }
        public string? RequestId { get; set; }

        // JSON string-lər (NVARCHAR(MAX))
        public string? UserJson { get; set; }
        public string? HttpJson { get; set; }
        public string? BusinessJson { get; set; }
        public string? ErrorJson { get; set; }
        public string? SystemJson { get; set; }
        public string? ExtraJson { get; set; }
    }
}
