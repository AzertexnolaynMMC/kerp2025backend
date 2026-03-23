namespace kerp.Prosedur.PMOrders
{
    public class PMAssigneesSelect
    {
        public int Id { get; set; }

        public int PmOrderId { get; set; }

        public int UserId { get; set; }

        public required string AssistantTitle { get; set; }

        public int Role { get; set; }
    }
}
