namespace kerp.Prosedur.PreCheck.Template
{
    public class PreCheckTemplateExecuteSelect
    {
        public int Id { get; set; }
        public int PreCheckId { get; set; }
        public int PreCheckTemplateId { get; set; }
        public string? Descreption { get; set; }
        public int PreCheckResultTypeId { get; set; }

        public string? PreCheckTemplateTitle { get; set; }
        public string? PreCheckResultTypeTitle { get; set; }

        public int PreCheckGroupId { get; set; }
        public bool IsComment { get; set; }
        public string? PreCheckGroupTite { get; set; }
    }
}
