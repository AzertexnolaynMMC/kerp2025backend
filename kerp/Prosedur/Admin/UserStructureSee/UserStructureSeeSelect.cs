namespace kerp.Prosedur.Admin.UserStructureSee
{
    public class UserStructureSeeSelect
    {
        public int Id { get; set; }
        public int StructureId { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }   // Status kolonu BIT ise bool doğru tiptir
        public string StructureTitile { get; set; }
        public string UserTitle { get; set; }
    }
}
