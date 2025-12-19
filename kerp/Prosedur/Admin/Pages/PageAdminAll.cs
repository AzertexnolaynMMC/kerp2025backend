namespace kerp.Prosedur.Admin.Pages
{
    public class PageAdminAll
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;        // Məs: "Texniki xidmət və təmir"

        public string Route { get; set; } = null!;        // Məs: "/tech_service"

        public string Icon { get; set; } = null!;         // Məs: "Icons.build_outlined"

        public string LangRoute { get; set; } = null!;    // Məs: "pages.maintenance"

        /// <summary>
        /// 0 isə üst səhifədir, digər hallarda parent səhifənin Id-si.
        /// </summary>
        public int UnderPageId { get; set; }

        /// <summary>
        /// 1 = Aktiv, 0 = Passiv
        /// </summary>
        public bool Status { get; set; }
    }
}
