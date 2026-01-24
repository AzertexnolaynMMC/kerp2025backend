using kerp.Prosedur.MachineIncident.Material;

namespace kerp.Prosedur.MachineIncident.Task
{
    public class MachineIncidentTaskInsert
    {
        public string? Title { get; set; }   // NVARCHAR(255)
        public int UserId { get; set; }
        public int AssetId { get; set; }
        public int MachineIncidentId { get; set; }
        public int CrashTypeId { get; set; }
        public List<MachineIncidentMaterialInsert>? MachineIncidentMaterialInsert { get; set; }
    }
}
