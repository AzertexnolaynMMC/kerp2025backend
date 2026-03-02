using kerp.Prosedur.MachineIncident.SelectModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace kerp.Prosedur.MachineIncident.Incident
{
    public class MachineIncidentSelectForBackEnd
    {
        public int Id { get; set; }
        public int CreateUserId { get; set; }
        public int WorkOrderTypeId { get; set; }
        public int StructureId { get; set; }

        public string? UserTitle { get; set; }
        public string? AssetTitle { get; set; }

        public string? ProjectTitle { get; set; }
        [NotMapped]
        public List<MachineIncidentSelectForBackEndCrashType>? MachineIncidentSelectForBackEndCrashType { get; set; }
        [NotMapped]
        public List<MachineIncidentSelectForBackEndWorkOrderType>? MachineIncidentSelectForBackEndWorkOrderType { get; set; }
    }
}
