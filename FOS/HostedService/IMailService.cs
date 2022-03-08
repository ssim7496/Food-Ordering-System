namespace FOS.HostedService
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
