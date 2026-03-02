using kerp.Prosedur.MachineIncident.SelectModels;

namespace kerp.SystemModel
{
    public class SendMailDto
    {
        public MailMachineIncidentResult? MailMachineIncidentResult { get; set; }
        public List<string> ToEmails { get; set; } = [];
        public string? AttachmentPath { get; set; }
    }
}
