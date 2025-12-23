namespace kerp.Prosedur.Admin.Logs
{
    public class SqlLogSelect
    {
        public int Id { get; set; }

        public string? TableName { get; set; }
        public int? RecordId { get; set; }

        public string? OperatorType { get; set; }       // Insert/Update/Delete və s.

        public int? ChangedByUserId { get; set; }
        public DateTime? ChangeAt { get; set; }

        public string? OldData { get; set; }
        public string? NewData { get; set; }

        public string? ProcedureTitle { get; set; }

        public string? UserName { get; set; }
    }
}
