using System.ComponentModel.DataAnnotations.Schema;

namespace kerp.Prosedur.Dsr.Cost
{
    public class DSRWorkOrderEvaluated
    {

        [NotMapped]
        public List<DSRWorkOrderEvaluatedWorker>? DSRWorkOrderEvaluatedWorker { get; set; }
        [NotMapped]
        public DSRWorkOrderEvaluatedAll? DSRWorkOrderEvaluatedAll { get; set; }
    }
}
