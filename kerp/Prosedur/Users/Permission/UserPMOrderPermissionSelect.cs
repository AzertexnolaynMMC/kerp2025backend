namespace kerp.Prosedur.Users.Permission
{
    public class UserPMOrderPermissionSelect
    {
        public int Id { get; set; }

        public bool IsAdmin { get; set; }
        public bool AccepOrder { get; set; }
        public bool SaveOrder { get; set; }
        public bool SendOrder { get; set; }
        public bool ConfrimOrder { get; set; }
        public bool ClosedOrder { get; set; }

        public bool AddTechnician { get; set; }
        public bool DeleteTechnician { get; set; }

        public bool AddDocument { get; set; }
        public bool DeleteDocument { get; set; }
        public bool EditDocument { get; set; }

        public bool AddMaterial { get; set; }
        public bool DeleteMaterial { get; set; }
        public bool EditMaterial { get; set; }

        public bool CreateCm { get; set; }
        public bool ChecklistAccess { get; set; }
        public bool AddComment { get; set; }
        public bool EditComment { get; set; }
        public bool DeleteComment { get; set; }
        public bool AddAsset { get; set; }
        public bool DeleteAsset { get; set; }

    }
}
