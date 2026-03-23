namespace kerp.Prosedur.PMOrders
{
    public class PMChecklistExecutionUpdate
    {
        public string? ResponseValue { get; set; }
        public int FilledBy { get; set; }
        public bool IsInRange { get; set; }
        public string? Notes { get; set; }
        public string? PhotoPath { get; set; }
        public int Id { get; set; }
        public int ResponseType { get; set; }
        public IFormFile? File { get; set; }
    }
}
