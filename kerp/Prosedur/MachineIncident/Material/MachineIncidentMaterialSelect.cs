namespace kerp.Prosedur.MachineIncident.Material
{
    public class MachineIncidentMaterialSelect
    {
        public string? Title { get; set; }   // NVARCHAR(255)
        public string? Measure { get; set; }   // NVARCHAR(255)
        public string? Code { get; set; }   // NVARCHAR(255)
        public int Id { get; set; }      // INT
        public int MaterialId { get; set; }      // INT
        public int MachineIncidentId { get; set; }      // INT
        public double Amount { get; set; }      // INT
    }
}
