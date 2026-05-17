namespace kerp.Prosedur.Users.Permission
{
    public class UserDSRPermissionSelect
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }

        public bool DsrAccept { get; set; }
        public bool DsrDeliver { get; set; }
        public bool DsrReject { get; set; }
        public bool DsrEvaluate { get; set; }
        public bool DsrFinish { get; set; }
        public bool DsrClose { get; set; }
        public bool DsrCostEvaluate { get; set; }
        public bool DsrCancel { get; set; }

        public bool DsrAddTask { get; set; }
        public bool DsrUpdateTask { get; set; }
        public bool DsrDeleteTask { get; set; }

        public bool DsrAddAssistant { get; set; }
        public bool DsrDeleteAssistant { get; set; }

        public bool DsrAddComment { get; set; }
        public bool DsrUpdateComment { get; set; }
        public bool DsrDeleteComment { get; set; }

        public bool DsrViewDocument { get; set; }
        public bool DsrAddDocument { get; set; }
        public bool DsrUpdateDocument { get; set; }
        public bool DsrDeleteDocument { get; set; }

        public bool DsrAddLostTime { get; set; }
        public bool DsrUpdateLostTime { get; set; }
        public bool DsrDeleteLostTime { get; set; }

        public bool DsrAddMaterial { get; set; }
        public bool DsrUpdateMaterial { get; set; }
        public bool DsrDeleteMaterial { get; set; }

        public bool DsrAddRecord { get; set; }
        public bool DsrUpdateRecord { get; set; }
        public bool DsrDeleteRecord { get; set; }
    }
}
