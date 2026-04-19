namespace kerp.Prosedur.PreCheck.WorkOrder
{
    public class PreCheckWorkOrderSelect
    {
        public int Id { get; set; }
        public int PreCheckId { get; set; }
        public int WorkOrderTypeId { get; set; }
        public required string Title { get; set; }
        public required string Keys { get; set; }
        public required string LangCode { get; set; }
        public int LangId { get; set; }
    }
}
