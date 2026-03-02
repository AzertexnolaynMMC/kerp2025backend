namespace kerp.Prosedur.Users.Permission
{
    public class UserProfilePermissionSelect
    {
        public int Id { get; set; }

        // ================= ADMIN =================
        public bool IsAdmin { get; set; }

        // ================= PHONE =================
        public bool PhoneSee { get; set; }
        public bool PhoneInsert { get; set; }
        public bool PhoneEdit { get; set; }
        public bool PhoneStatus { get; set; }

        // ================= MAIL ==================
        public bool MailSee { get; set; }
        public bool MailInsert { get; set; }
        public bool MailEdit { get; set; }
        public bool MailStatus { get; set; }

        // ================= EMPLOYER ==============
        public bool EmployerSee { get; set; }
        public bool EmployerInsert { get; set; }
        public bool EmployerStatus { get; set; }

        // ================= MACHINE ===============
        public bool MachineSee { get; set; }
        public bool MachineInsert { get; set; }
        public bool MachineStatus { get; set; }

        // ================= LOGIN =================
        public bool LoginSee { get; set; }
        public bool LoginInsert { get; set; }
        public bool LoginEdit { get; set; }
        public bool LoginStatus { get; set; }

        // ================= USER ==================
    }
}
