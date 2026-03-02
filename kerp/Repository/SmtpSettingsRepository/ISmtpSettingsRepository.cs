using kerp.Prosedur.SmtpSettings;

namespace kerp.Repository.SmtpSettingsRepository
{
    public interface ISmtpSettingsRepository
    {
        SmtpSettingsResult? GetActiveSmtpSetting();
    }
}
