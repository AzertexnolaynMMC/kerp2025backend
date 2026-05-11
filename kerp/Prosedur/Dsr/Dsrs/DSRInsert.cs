using kerp.Prosedur.Dsr.Machine;
using kerp.Prosedur.Dsr.Section;
using kerp.Prosedur.Dsr.Structure;
using kerp.Prosedur.Dsr.Task;
using kerp.Prosedur.Dsr.WorkOrderType;
using kerp.Prosedur.Dsr.WorkShift;

namespace kerp.Prosedur.Dsr.Dsrs
{
    public class DSRInsert
    {
        public string? Title { get; set; }
        public int StructureId { get; set; }
        public bool IsMachinePartRepair { get; set; }
        public bool IsRemovedFromMachine { get; set; }
        public int UserId { get; set; }
        public DSRMachineInsert? DSRMachineInsert { get; set; }
        public DSRWorkOrderTypeInsert? DSRWorkOrderTypeInsert { get; set; }
        public DSRSectionInsert? DSRSectionInsert { get; set; }
        public DSRStructureInsert? DSRStructureInsert { get; set; }
        public DSRWorkShiftInsert? DSRWorkShiftInsert { get; set; }
        public List<DSRTaskInsert>? DSRTaskInsert { get; set; }
    }
}
