using kerp.Prosedur.MachineIncident.SelectModels;
using kerp.Prosedur.SmtpSettings;
using kerp.Repository.SmtpSettingsRepository;
using kerp.SystemModel;
using System.Net;
using System.Net.Mail;

namespace kerp.Service.MailService
{
    public class MailService : IMailService
    {
        private readonly ISmtpSettingsRepository _repo;

        public MailService(ISmtpSettingsRepository repo)
        {
            _repo = repo;
        }

        public async Task SendMailAsync(SendMailDto dto)
        {
            // SMTP ayarlarını al
            SmtpSettingsResult? smtp = _repo.GetActiveSmtpSetting();
            if (smtp == null)
                throw new Exception("SMTP ayarları tapılmadı.");

            // Subject və Body generasiya et
            string subject;
            string body;

            if (dto.MailMachineIncidentResult != null)
            {
                var mi = dto.MailMachineIncidentResult;

                // Subject: AssetTitle ( WorkOrderTypeTitle )
                subject = $"{mi.AssetTitle} ( {mi.WorkOrderTypeTitle} )";

                // Body: HTML formatında
                body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #f4f4f4; padding: 15px; border-radius: 5px; margin-bottom: 20px; }}
        .label {{ font-weight: bold; color: #555; display: inline-block; width: 120px; }}
        .value {{ color: #000; }}
        .row {{ margin-bottom: 10px; padding: 5px 0; border-bottom: 1px solid #eee; }}
        .footer {{ margin-top: 30px; font-size: 12px; color: #777; border-top: 2px solid #ddd; padding-top: 10px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h2 style='margin: 0; color: #d9534f;'>🛠️ Yeni İş Emri Açıldı</h2>
        </div>
        
        <div class='row'>
            <span class='label'>İş Emri №:</span>
            <span class='value'>#{mi.Id}</span>
        </div>
        
        <div class='row'>
            <span class='label'>Avadanlıq:</span>
            <span class='value'>{mi.AssetTitle}</span>
        </div>
        
        <div class='row'>
            <span class='label'>İş Tipi:</span>
            <span class='value'>{mi.WorkOrderTypeTitle}</span>
        </div>
        
        <div class='row'>
            <span class='label'>Arıza Tipi:</span>
            <span class='value'>{mi.CrashTypeTitle}</span>
        </div>
        
        <div class='row'>
            <span class='label'>Növbə:</span>
            <span class='value'>{mi.WorkShiftTile}</span>
        </div>
        
        <div class='row'>
            <span class='label'>Açıqlama:</span>
            <span class='value'>{mi.Descriptions}</span>
        </div>
        
        <div class='row'>
            <span class='label'>Açan şəxs:</span>
            <span class='value'>{mi.UserTitle}</span>
        </div>
        
        <div class='footer'>
            <p>Bu avtomatik bildirişdir. Zəhmət olmazsa, iş emri ilə bağlı tədbir görün.</p>
            <p>ERP Sistemi | {DateTime.Now:dd.MM.yyyy HH:mm}</p>
        </div>
    </div>
</body>
</html>";
            }
            else
            {
                throw new Exception("Mail məlumatları tapılmadı.");
            }

            // SMTP client ilə göndər
            using var client = new SmtpClient(smtp.Host, smtp.Port);
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(smtp.Username, smtp.Password);

            var message = new MailMessage
            {
                From = new MailAddress(smtp.FromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            foreach (string email in dto.ToEmails)
            {
                message.To.Add(email);
            }

            // Attachment varsa əlavə et
            if (!string.IsNullOrEmpty(dto.AttachmentPath) && File.Exists(dto.AttachmentPath))
            {
                message.Attachments.Add(new Attachment(dto.AttachmentPath));
            }

            await client.SendMailAsync(message);
        }
    }
}