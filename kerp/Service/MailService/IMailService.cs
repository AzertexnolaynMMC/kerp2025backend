using kerp.SystemModel;

namespace kerp.Service.MailService
{
    public interface IMailService
    {
        Task SendMailAsync(SendMailDto dto);
    }
}
