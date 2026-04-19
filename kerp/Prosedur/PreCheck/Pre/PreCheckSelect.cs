using kerp.Prosedur.PreCheck.Document;
using kerp.Prosedur.PreCheck.Event;
using kerp.Prosedur.PreCheck.Record;
using kerp.Prosedur.PreCheck.Section;
using kerp.Prosedur.PreCheck.Structure;
using kerp.Prosedur.PreCheck.Template;
using kerp.Prosedur.PreCheck.WorkOrder;
using System.ComponentModel.DataAnnotations.Schema;

namespace kerp.Prosedur.PreCheck.Pre
{
    public class PreCheckSelect
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string? AssetTitle { get; set; }
        public string? UserTitle { get; set; }
        public int ShiftId { get; set; }
        public int LifeCircle { get; set; }
        public int CreateUserId { get; set; }
        public string? WorkShift { get; set; }
        [NotMapped]
        public List<PreCheckSectionSelect>? PreCheckSectionSelect { get; set; }
        [NotMapped]
        public List<PreCheckStructureSelect>? PreCheckStructureSelect { get; set; }
        [NotMapped]
        public List<PreCheckTemplateExecuteSelect>? PreCheckTemplateExecuteSelect { get; set; }
        [NotMapped]
        public List<PreCheckWorkOrderSelect>? PreCheckWorkOrderSelect { get; set; }
        [NotMapped]
        public List<PreCheckDocumentSelect>? PreCheckDocumentSelect { get; set; }
        [NotMapped]
        public List<PreCheckRecordSelect>? PreCheckRecordSelect { get; set; }
        [NotMapped]
        public List<PreCheckEventSelect>? PreCheckEventSelect { get; set; }
        [NotMapped]
        public List<PreCheckEventsSelectMulti>? PreCheckEventsSelectMulti { get; set; }
    }
}
