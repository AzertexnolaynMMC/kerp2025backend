namespace kerp.Prosedur.Pm.PMScheduleAssignees
{
    public class PMScheduleAssigneesSelect
    {
        public int Id { get; set; }
        public int PmScheduleId { get; set; }
        public int UserId { get; set; }
        public int? Role { get; set; }
        public string? UserTitle { get; set; }
        public bool Status { get; set; }
    }
}
