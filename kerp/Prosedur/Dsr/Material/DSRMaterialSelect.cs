namespace kerp.Prosedur.Dsr.Material
{
    public class DSRMaterialSelect
    {
        public int Id { get; set; }

        public int MaterialId { get; set; }
        public int DsrTaskId { get; set; }

        public double Amount { get; set; }

        public string? Measure { get; set; }

        public string? Code { get; set; }

        public string? Title { get; set; }

        public int DsrId { get; set; }
    }
}
