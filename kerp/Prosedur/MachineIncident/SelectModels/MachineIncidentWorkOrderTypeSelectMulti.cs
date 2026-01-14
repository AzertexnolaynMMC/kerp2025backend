namespace kerp.Prosedur.MachineIncident.SelectModels
{
    public class MachineIncidentWorkOrderTypeSelectMulti
    {
        public int Id { get; set; }
        public string? Code { get; set; }        // Language.Title
        public int WorkOrderTypeId { get; set; }
        public string? Title { get; set; }       // WorkOrderTypeLang.Title
    }
}
