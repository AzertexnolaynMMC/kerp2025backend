namespace kerp.Prosedur.Dsr.WorkOrderType
{
    public class DSRWorkOrderTypeSelect
    {
        public int Id { get; set; }
        public int DsrId { get; set; }
        public int WorkOrderTypeId { get; set; }
        public string? Title { get; set; }
        public string? Keys { get; set; }
        public string? LangCode { get; set; }
        public int LangId { get; set; }
    }
}
