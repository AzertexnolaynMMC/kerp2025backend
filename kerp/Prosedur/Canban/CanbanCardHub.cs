using System.ComponentModel.DataAnnotations.Schema;

namespace kerp.Prosedur.Canban
{
    public class CanbanCardHub
    {
        public int Id { get; set; }

        public int LifeCrcileStatus { get; set; }

        public bool IsRejected { get; set; }

        public string? Title { get; set; }

        public DateTime? EventDate { get; set; }

        public int? CanbanStatus { get; set; }
        public Guid? Guids { get; set; }

        [NotMapped]
        public List<CanbanCardWorkOrderType>? CanbanCardWorkOrderType { get; set; }
        [NotMapped]
        public List<CanbanCardCrashType>? CanbanCardCrashType { get; set; }
        [NotMapped]
        public List<CanbanCardStructure>? CanbanCardStructure { get; set; }
        [NotMapped]
        public List<CanbanCardSection>? CanbanCardSection { get; set; }
    }
}
