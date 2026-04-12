namespace kerp.Prosedur.PM.PMScheduleAsset
{
    public class PMScheduleAssetSelect
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int PMScheduleId { get; set; }
        public bool Status { get; set; }
        public string? Title { get; set; }
    }
}