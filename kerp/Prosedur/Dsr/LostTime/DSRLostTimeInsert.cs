namespace kerp.Prosedur.Dsr.LostTime
{
    public class DSRLostTimeInsert
    {
        public string Title { get; set; } = null!;

        public int UserId { get; set; }
        public int DsrTaskAssistantId { get; set; }

        public int DsrId { get; set; }

        public long Second { get; set; }
    }
}
