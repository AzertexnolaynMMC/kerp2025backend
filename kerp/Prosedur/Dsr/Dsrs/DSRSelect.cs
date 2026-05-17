using kerp.Prosedur.Dsr.Assistant;
using kerp.Prosedur.Dsr.Chat;
using kerp.Prosedur.Dsr.Cost;
using kerp.Prosedur.Dsr.Document;
using kerp.Prosedur.Dsr.Event;
using kerp.Prosedur.Dsr.LostTime;
using kerp.Prosedur.Dsr.Machine;
using kerp.Prosedur.Dsr.Material;
using kerp.Prosedur.Dsr.Record;
using kerp.Prosedur.Dsr.Section;
using kerp.Prosedur.Dsr.Structure;
using kerp.Prosedur.Dsr.Task;
using kerp.Prosedur.Dsr.TaskComment;
using kerp.Prosedur.Dsr.WorkOrderType;
using kerp.Prosedur.Dsr.WorkShift;
using System.ComponentModel.DataAnnotations.Schema;

namespace kerp.Prosedur.Dsr.Dsrs
{
    public class DSRSelect
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsMachinePartRepair { get; set; }
        public bool IsRemovedFromMachine { get; set; }
        public int LifeCircle { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsReject { get; set; }
        public string? RejectTitle { get; set; }

        [NotMapped]
        public DSRMachineSelect? DSRMachineSelect { get; set; }
        [NotMapped]
        public List<DSRTaskAssistantSelect>? DSRTaskAssistantSelect { get; set; }
        [NotMapped]
        public List<DSREventSelect>? DSREventSelect { get; set; }
        [NotMapped]
        public List<DSRSectionSelect>? DSRSectionSelect { get; set; }
        [NotMapped]
        public List<DSRStructureSelect>? DSRStructureSelect { get; set; }
        [NotMapped]
        public List<DSRTaskSelect>? DSRTaskSelect { get; set; }
        [NotMapped]
        public List<DSRWorkOrderTypeSelect>? DSRWorkOrderTypeSelect { get; set; }
        [NotMapped]
        public List<DSRWorkShiftSelect>? DSRWorkShiftSelect { get; set; }

        // Yeni əlavələr
        [NotMapped]
        public List<DSRChatSelect>? DSRChatSelect { get; set; }
        [NotMapped]
        public List<DSRDocumentSelect>? DSRDocumentSelect { get; set; }
        [NotMapped]
        public List<DSRLostTimeSelect>? DSRLostTimeSelect { get; set; }
        [NotMapped]
        public List<DSRMaterialSelect>? DSRMaterialSelect { get; set; }
        [NotMapped]
        public List<DSRRecordSelect>? DSRRecordSelect { get; set; }
        [NotMapped]
        public List<DSRTaskCommentSelect>? DSRTaskCommentSelect { get; set; }   
        [NotMapped]
        public List<DSRCostSelect>? DSRCostSelect { get; set; }


    }
}
