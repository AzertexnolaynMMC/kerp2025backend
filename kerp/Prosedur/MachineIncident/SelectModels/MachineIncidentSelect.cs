using kerp.Prosedur.MachineIncident.Assistant;
using kerp.Prosedur.MachineIncident.Chat;
using kerp.Prosedur.MachineIncident.Event;
using kerp.Prosedur.MachineIncident.Group;
using kerp.Prosedur.MachineIncident.MachineIncidentDocument;
using kerp.Prosedur.MachineIncident.MachineIncidentLostTime;
using kerp.Prosedur.MachineIncident.Material;
using kerp.Prosedur.MachineIncident.Section;
using kerp.Prosedur.MachineIncident.Structure;
using kerp.Prosedur.MachineIncident.Task;
using kerp.Prosedur.MachineIncident.Type;
using kerp.Prosedur.MachineIncident.WorkOrderType;
using kerp.Prosedur.MachineIncident.WorkShift;
using System.ComponentModel.DataAnnotations.Schema;

namespace kerp.Prosedur.MachineIncident.SelectModels
{
    public class MachineIncidentSelect
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public Guid? Guids { get; set; }

        public int LifeCrcileStatus { get; set; }

        public DateTime CreateDate { get; set; }

        public string? UserTitle { get; set; }

        public string? ProjectTitle { get; set; }

        public string? AssetTitle { get; set; }

        public int? AssetId { get; set; }

        public int? ProjectId { get; set; }
        [NotMapped]
        public List<MachineIncidentCrashTypeSelect>? MachineIncidentCrashTypeSelect { get; set; }

        [NotMapped]
        public List<MachineIncidentAssistantSelect>? MachineIncidentAssistantSelect { get; set; }

        [NotMapped]
        public List<MachineIncidentChatSelect>? MachineIncidentChatSelect { get; set; }

        [NotMapped]
        public List<MachineIncidentCrashGroupSelect>? MachineIncidentCrashGroupSelect { get; set; }

        [NotMapped]
        public List<MachineIncidentDocumentSelect>? MachineIncidentDocumentSelect { get; set; }

        [NotMapped]
        public List<MachineIncidentEventSelect>? MachineIncidentEventSelect { get; set; }

        [NotMapped]
        public List<MachineIncidentLostTimeSelect>? MachineIncidentLostTimeSelect { get; set; }

        [NotMapped]
        public List<MachineIncidentMaterialSelect>? MachineIncidentMaterialSelect { get; set; }

        [NotMapped]
        public List<MachineIncidentSectionSelect>? MachineIncidentSectionSelect { get; set; }

        [NotMapped]
        public List<MachineIncidentStructureSelect>? MachineIncidentStructureSelect { get; set; }

        [NotMapped]
        public List<MachineIncidentTaskSelect>? MachineIncidentTaskSelect { get; set; }

        [NotMapped]
        public List<MachineIncidentWorkOrderTypeSelect>? MachineIncidentWorkOrderTypeSelect { get; set; }

        [NotMapped]
        public List<MachineIncidentWorkShiftSelect>? MachineIncidentWorkShiftSelect { get; set; }

    }
}
