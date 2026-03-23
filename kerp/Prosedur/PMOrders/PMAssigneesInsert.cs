namespace kerp.Prosedur.PMOrders
{
    public class PMAssigneesInsert
    {
        public int PmOrderId { get; set; }
        public int UserId { get; set; }      // əməliyyatı edən user
        public int AssigneeId { get; set; }  // təyin olunan user
        public int Role { get; set; }
    }
}
