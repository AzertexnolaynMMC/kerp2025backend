namespace kerp.Prosedur.Dsr.Assistant
{
    public class DSRTaskAssistantSelect
    {
        public int Id { get; set; }
        public int DsrTaskId { get; set; }
        public int DsrId { get; set; }
        public int UserId { get; set; }
        public int LifeCircle { get; set; }
        public bool? IsReject { get; set; }
        public string? RejectTitle { get; set; }
        public string? UserTitle { get; set; }
    }
}
