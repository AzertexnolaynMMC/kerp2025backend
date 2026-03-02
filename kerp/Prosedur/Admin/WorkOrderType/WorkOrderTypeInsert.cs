namespace kerp.Prosedur.Admin.WorkOrderType
{
    public class WorkOrderTypeInsert
    {
        public string Title { get; set; } = null!;
        public int UserId { get; set; }
        public int Status { get; set; }
        public string? Keys { get; set; }  // ✅ əlavə edildi
    }
}
