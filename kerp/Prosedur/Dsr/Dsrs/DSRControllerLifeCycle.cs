using kerp.Prosedur.Dsr.Assistant;

namespace kerp.Prosedur.Dsr.Dsrs
{
    public class DSRControllerLifeCycle
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Status { get; set; }
        public DSRTaskAssistantControllerLifeCycle? DSRTaskAssistantControllerLifeCycle { get; set; }
    }
}
