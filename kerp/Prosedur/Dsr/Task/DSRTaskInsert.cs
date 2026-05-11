using kerp.Prosedur.Dsr.Assistant;

namespace kerp.Prosedur.Dsr.Task
{
    public class DSRTaskInsert
    {
        public int DsrId { get; set; }
        public int TaskTypeId { get; set; }
        public required string Title { get; set; }
        public int UserId { get; set; }
        public List<DSRTaskAssistantInsert>? DSRTaskAssistantInsert { get; set; }
    }
}
