namespace kerp.Prosedur.Admin.Permission.MachineIncidentReportPermission
{
    public class MachineIncidentReportPermissionSelect
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool CanChangeTitle { get; set; }
        public bool CanChangeProject { get; set; }
        public bool CanChangeCrashType { get; set; }
        public bool CanChangeServiceType { get; set; }
        public bool CanChangeWorkShift { get; set; }
        public bool CanUpdateTask { get; set; }
        public bool CanDeleteTask { get; set; }
        public bool CanAddTask { get; set; }
        public bool CanDeleteMaterial { get; set; }
        public bool CanAddMaterial { get; set; }
        public bool CanDeleteDocument { get; set; }
        public bool CanAddDocument { get; set; }
        public bool CanAddLostTime { get; set; }
        public bool CanDeleteLostTime { get; set; }
        public bool CanDeleteTechnician { get; set; }
        public bool CanAddTechnician { get; set; }
        public bool CanAddNote { get; set; }
        public bool CanDeleteNote { get; set; }
        public bool CanUpdateNote { get; set; }
        public bool CanChangeProcess { get; set; }
        public bool IsAdmin { get; set; }
        public string? FullName { get; set; }
    }
}
