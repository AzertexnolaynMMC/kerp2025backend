namespace kerp.Prosedur.MachineIncident.Incident
{
    public class MachineIncidentInsert
    {
        public string? Title { get; set; }   // NVARCHAR(255)
        public int UserId { get; set; }      // INT
        public int AssetId { get; set; }     // INT
        public int ProjectId { get; set; }     // INT


        // =========================
        // Burda qezani kim acibsa hemin adam oz iscisini secir Event ucun lazimdir.
        // =========================
        public int AsigntUserId { get; set; }     // INT
    }
}
