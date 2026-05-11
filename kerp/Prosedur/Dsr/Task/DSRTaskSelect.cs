namespace kerp.Prosedur.Dsr.Task
{
    public class DSRTaskSelect
    {
        public int Id { get; set; }
        public int DsrId { get; set; }
        public int TaskTypeId { get; set; }
        public required string Title { get; set; }
        public required string TaskTypeTitle { get; set; }

    }
}
