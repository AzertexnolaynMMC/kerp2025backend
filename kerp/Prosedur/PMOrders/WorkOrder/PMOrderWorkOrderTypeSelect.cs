namespace kerp.Prosedur.PMOrders.WorkOrder
{
    public class PMOrderWorkOrderTypeSelect
    {
        public int Id { get; set; }
        public int PMOrdersId { get; set; }
        public int WorkOrderTypeId { get; set; }
        public string? Title { get; set; }
        public string? Keys { get; set; }
        public string? LangCode { get; set; }
        public int LangId { get; set; }
    }
}
