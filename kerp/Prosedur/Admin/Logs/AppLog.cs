namespace kerp.Prosedur.Admin.Logs
{
    public class AppLog
    {
        public int LogId { get; set; }                 // PK, IDENTITY

        public int? UserId { get; set; }               // NULL ola bilər

        public DateTime TimestampUtc { get; set; }     // DATETIME2(3)
        public DateTime ReceivedAtUtc { get; set; }    // DATETIME2(3) DEFAULT SYSUTCDATETIME()

        public string Level { get; set; } = default!;  // VARCHAR(10)
        public string Message { get; set; } = default!; // NVARCHAR(2048)

        public string? Env { get; set; }               // VARCHAR(32)
        public string? Service { get; set; }           // VARCHAR(64)
        public string? Logger { get; set; }            // NVARCHAR(128)
        public string? AppVersion { get; set; }        // VARCHAR(32)

        public string? Host { get; set; }              // NVARCHAR(128)
        public string? TraceId { get; set; }           // VARCHAR(64)
        public string? SpanId { get; set; }            // VARCHAR(64)
        public string? RequestId { get; set; }         // VARCHAR(64)
        public string? UserName { get; set; }         // VARCHAR(64)

        // JSON string-lər (NVARCHAR(MAX))
        public string? UserJson { get; set; }
        public string? HttpJson { get; set; }
        public string? BusinessJson { get; set; }
        public string? ErrorJson { get; set; }
        public string? SystemJson { get; set; }
        public string? ExtraJson { get; set; }
    }
}
