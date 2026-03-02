namespace kerp.Prosedur.Pm.PMChecklistTemplate
{
    public class PMChecklistTemplateReorderRequest
    {
        public int GroupId { get; set; }
        public List<PMChecklistTemplateReorderItem> Items { get; set; } = [];
        public int UserId { get; set; }
    }
}
