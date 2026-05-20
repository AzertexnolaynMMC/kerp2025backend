using kerp.Prosedur.Admin.Material;

namespace kerp.Prosedur.Dsr.Cost
{
    public class DsrCostMaterialInsert
    {
        public bool? IsMaterial { get; set; }
        public MaterialInsert? MaterialInsert { get; set; }
        public List<DSRCostInsert>? DSRCostInsert { get; set; }

    }
}
