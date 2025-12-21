namespace kerp.Prosedur.Admin.ManagerEmploye
{
    public class ManagerEmployeSelect
    {
        public int? Id { get; set; }

        public int? ManagerId { get; set; }
        public string? ManagerName { get; set; }   // LEFT JOIN olduğu üçün null ola bilər

        public int? WorkerId { get; set; }
        public string? EmployeName { get; set; }   // LEFT JOIN olduğu üçün null ola bilər

        // Status sütununun tipinə görə birini seç:
        public bool? Status { get; set; }            // əgər int-dirsə
                                                     // public bool Status { get; set; }         // əgər bit-dirsə
                                                     // public string? Status { get; set; }      // əgər varchar/nvarchar-dirsə
    }
}
