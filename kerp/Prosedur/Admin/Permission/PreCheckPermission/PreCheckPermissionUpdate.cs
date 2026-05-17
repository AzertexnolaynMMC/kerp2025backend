namespace kerp.Prosedur.Admin.Permission.PreCheckPermission
{
    public class PreCheckPermissionUpdate
    {
        public int UserId { get; set; }
        public int OperatorUserId { get; set; }
        public bool Check { get; set; }
        public int EnumType { get; set; }
    }
}
