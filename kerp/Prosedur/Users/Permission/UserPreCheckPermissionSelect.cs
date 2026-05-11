namespace kerp.Prosedur.Users.Permission
{
    public class UserPreCheckPermissionSelect
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }

        public bool Accepted { get; set; }
        public bool ElectricalController { get; set; }
        public bool MechanicalController { get; set; }
        public bool PreCheckCreateCM { get; set; }

        public bool PreCheckDocumentInsert { get; set; }
        public bool PreCheckDocumentUpdate { get; set; }
        public bool PreCheckDocumentStatus { get; set; }

        public bool PreCheckRecordInsert { get; set; }
        public bool PreCheckRecordUpdate { get; set; }
        public bool PreCheckRecordStatus { get; set; }

        public bool InReview { get; set; }
        public bool Approved { get; set; }
        public bool Closed { get; set; }
    }
}
