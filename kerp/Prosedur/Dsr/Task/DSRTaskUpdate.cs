namespace kerp.Prosedur.Dsr.Task
{
    public class DSRTaskUpdate
    {
        public int Id { get; set; }
        public int TaskTypeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
