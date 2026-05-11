namespace kerp.Prosedur.Dsr.TaskComment
{
    public class DSRTaskCommentSelect
    {
        public int Id { get; set; }
        public int DsrTaskId { get; set; }
        public int DsrId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UserTitel { get; set; } = string.Empty;
    }
}
