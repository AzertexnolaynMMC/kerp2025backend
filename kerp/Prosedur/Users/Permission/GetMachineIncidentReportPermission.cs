namespace kerp.Prosedur.Users.Permission
{
    public class GetMachineIncidentReportPermission
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        // Başlıq və Əsas Məlumatlar
        public bool CanChangeTitle { get; set; }

        public bool CanChangeProject { get; set; }

        public bool CanChangeCrashType { get; set; }

        public bool CanChangeServiceType { get; set; }

        public bool CanChangeWorkShift { get; set; }

        // Task Əməliyyatları
        public bool CanUpdateTask { get; set; }

        public bool CanDeleteTask { get; set; }

        public bool CanAddTask { get; set; }

        // Material Əməliyyatları
        public bool CanDeleteMaterial { get; set; }

        public bool CanAddMaterial { get; set; }

        // Sənəd Əməliyyatları
        public bool CanDeleteDocument { get; set; }

        public bool CanAddDocument { get; set; }

        // İtirilmiş Vaxt Əməliyyatları
        public bool CanAddLostTime { get; set; }

        public bool CanDeleteLostTime { get; set; }

        // Təyin Edilən (Texniki/İşçi) Əməliyyatları
        public bool CanDeleteTechnician { get; set; }

        public bool CanAddTechnician { get; set; }

        // Qeyd Əməliyyatları
        public bool CanAddNote { get; set; }

        public bool CanDeleteNote { get; set; }

        public bool CanUpdateNote { get; set; }

        // Proses
        public bool CanChangeProcess { get; set; }

        // Ümumi İcazələr
        public bool IsAdmin { get; set; }

    }
}
