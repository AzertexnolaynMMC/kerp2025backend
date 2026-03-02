namespace kerp.Prosedur.Users.Permission
{
    public class UserMachineIncidentPermissionSelect
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }

        // ===== INITIATOR =====
        public bool AcceptInitiator { get; set; }
        public bool StartWorkInitiator { get; set; }
        public bool AddTaskInitiator { get; set; }
        public bool DeleteTaskInitiator { get; set; }
        public bool UpdateTaskInitiator { get; set; }
        public bool FinishWorkOrderInitiator { get; set; }
        public bool ApproveInitiator { get; set; }
        public bool CancelInitiator { get; set; }
        public bool CloseInitiator { get; set; }
        public bool RejectInitiator { get; set; }

        public bool AddDocumentInitiator { get; set; }
        public bool DeleteDocumentInitiator { get; set; }
        public bool AddLostTimeInitiator { get; set; }
        public bool DeleteLostTimeInitiator { get; set; }
        public bool AddNoteInitiator { get; set; }
        public bool DeleteNoteInitiator { get; set; }
        public bool UpdateNoteInitiator { get; set; }
        public bool AddTechnicianInitiator { get; set; }
        public bool DeleteTechnicianInitiator { get; set; }

        // 🔥 MATERIAL (INITIATOR)
        public bool AddMaterialInitiator { get; set; }
        public bool DeleteMaterialInitiator { get; set; }

        // 🔥 CHANGE (INITIATOR)
        public bool ChangeTitleInitiator { get; set; }
        public bool ChangeProjectInitiator { get; set; }
        public bool ChangeMachineInitiator { get; set; }
        public bool ChangeCrashTypeInitiator { get; set; }
        public bool ChangeServiceTypeInitiator { get; set; }
        public bool ChangeWorkShiftInitiator { get; set; }

        // ===== RECEIVER =====
        public bool AcceptReceiver { get; set; }
        public bool StartWorkReceiver { get; set; }
        public bool AddTaskReceiver { get; set; }
        public bool DeleteTaskReceiver { get; set; }
        public bool UpdateTaskReceiver { get; set; }
        public bool FinishWorkOrderReceiver { get; set; }
        public bool ApproveReceiver { get; set; }
        public bool CancelReceiver { get; set; }
        public bool CloseReceiver { get; set; }
        public bool RejectReceiver { get; set; }

        public bool AddDocumentReceiver { get; set; }
        public bool DeleteDocumentReceiver { get; set; }
        public bool AddLostTimeReceiver { get; set; }
        public bool DeleteLostTimeReceiver { get; set; }
        public bool AddNoteReceiver { get; set; }
        public bool DeleteNoteReceiver { get; set; }
        public bool UpdateNoteReceiver { get; set; }
        public bool AddTechnicianReceiver { get; set; }
        public bool DeleteTechnicianReceiver { get; set; }

        // 🔥 MATERIAL (RECEIVER)
        public bool AddMaterialReceiver { get; set; }
        public bool DeleteMaterialReceiver { get; set; }

        // 🔥 CHANGE (RECEIVER)
        public bool ChangeTitleReceiver { get; set; }
        public bool ChangeProjectReceiver { get; set; }
        public bool ChangeMachineReceiver { get; set; }
        public bool ChangeCrashTypeReceiver { get; set; }
        public bool ChangeServiceTypeReceiver { get; set; }
        public bool ChangeWorkShiftReceiver { get; set; }
    }
}
