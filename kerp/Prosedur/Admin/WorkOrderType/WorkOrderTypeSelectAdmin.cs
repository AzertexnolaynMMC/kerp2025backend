namespace kerp.Prosedur.Admin.WorkOrderType
{
    public class WorkOrderTypeSelectAdmin
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool Status { get; set; }
        public string? Keys { get; set; }  // ✅ əlavə edildi (SP select-də var)
    }
}
