using kerp.Prosedur.PMOrders.Asset;
using kerp.Prosedur.PMOrders.CheckList;
using kerp.Prosedur.PMOrders.Doc;
using kerp.Prosedur.PMOrders.Event;
using kerp.Prosedur.PMOrders.Record;
using kerp.Prosedur.PMOrders.WorkOrder;
using System.ComponentModel.DataAnnotations.Schema;

namespace kerp.Prosedur.PMOrders.Order
{
    public class PMOrdersSelect
    {
        public int Id { get; set; }
        public int FrequencyDays { get; set; }
        public int LifeCycle { get; set; }
        public int PmScheduleId { get; set; }
        public string? MachineCondition { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Title { get; set; }

        [NotMapped]
        public List<PMOrderWorkOrderTypeSelect>? PMOrderWorkOrderTypeSelect { get; set; }
        [NotMapped]
        public List<PMRecordSelect>? PMRecordSelect { get; set; }
        [NotMapped]
        public List<PMMaterialSelect>? PMMaterialSelect { get; set; }
        [NotMapped]
        public List<PMDocumentsSelect>? PMDocumentsSelect { get; set; }
        [NotMapped]
        public List<PMAssigneesSelect>? PMAssigneesSelect { get; set; }
        [NotMapped]
        public List<PMChatSelect>? PMChatSelect { get; set; }
        [NotMapped]
        public List<PMEventSelect>? PMEventSelect { get; set; }
        [NotMapped]
        public List<PMEventSelectMulti>? PMEventSelectMulti { get; set; }
        [NotMapped]
        public List<PMChecklistExecutionSelect>? PMChecklistExecutionSelect { get; set; }    
        [NotMapped]
        public List<PMOrderAssetSelect>? PMOrderAssetSelect { get; set; }

    }
}
