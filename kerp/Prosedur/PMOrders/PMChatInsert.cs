namespace kerp.Prosedur.PMOrders
{
    public class PMChatInsert
    {
        public required string Title { get; set; }           // Yeni chatın mətni
        public int UserId { get; set; }             // Chatı yazan istifadəçi Id
        public int PmOrderId { get; set; }          // Hansi PMOrder-ə aid olduğu
    }
}
