namespace kerp.Prosedur.Admin.WorkOrderType
{
    public class WorkOrderTypeUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int UserId { get; set; }   // prosedurda istifadə olunmur
    }
}
