namespace kerp.Prosedur.Dsr.Material
{
    public class DSRMaterialUpdate
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public int UserId { get; set; }

        public int MaterialId { get; set; }
        public int DsrTaskId { get; set; }
    }
}
