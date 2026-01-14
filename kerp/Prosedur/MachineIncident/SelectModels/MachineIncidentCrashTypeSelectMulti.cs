namespace kerp.Prosedur.MachineIncident.SelectModels
{
    public class MachineIncidentCrashTypeSelectMulti
    {
        public int Id { get; set; }
        public string? Code { get; set; }      // Language.Title
        public int CrashTypeId { get; set; }
        public string? Title { get; set; }     // CrashTypeLang.Title
    }
}
