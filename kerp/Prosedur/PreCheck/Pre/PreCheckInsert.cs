using kerp.Prosedur.PreCheck.Section;
using kerp.Prosedur.PreCheck.Structure;
using kerp.Prosedur.PreCheck.Template;
using kerp.Prosedur.PreCheck.WorkOrder;

namespace kerp.Prosedur.PreCheck.Pre
{
    public class PreCheckInsert
    {
        public int AssetId { get; set; }
        public int ShiftId { get; set; }
        public int StructureId { get; set; }
        public int UserId { get; set; }
        public PreCheckSectionInsert? PreCheckSectionInsert { get; set; }
        public PreCheckStructureInsert? PreCheckStructureInsert { get; set; }
        public PreCheckWorkOrderInsert? PreCheckWorkOrderInsert { get; set; }
        public List<PreCheckTemplateExecuteInsert>? PreCheckTemplateExecuteInsert { get; set; }
    }
}
