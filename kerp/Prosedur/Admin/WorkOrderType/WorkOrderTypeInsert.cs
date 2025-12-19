namespace kerp.Prosedur.Admin.WorkOrderType
{
    public class WorkOrderTypeInsert
    {
        public string Title { get; set; } = null!;
        public int UserId { get; set; }   // prosedurda istifadə olunmur
        public int Status { get; set; }
    }
}
