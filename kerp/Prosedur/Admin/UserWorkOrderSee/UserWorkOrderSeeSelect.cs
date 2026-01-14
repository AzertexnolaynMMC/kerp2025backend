namespace kerp.Prosedur.Admin.UserWorkOrderSee
{
    public class UserWorkOrderSeeSelect
    {
        public int Id { get; set; }
        public int WorkOrderId { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }   // Status kolonu BIT ise bool doğru tiptir
        public string? WorkOrderTitile { get; set; }
        public string? UserTitle { get; set; }
    }
}
