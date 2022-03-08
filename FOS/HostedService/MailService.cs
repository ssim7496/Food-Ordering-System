using Microsoft.Extensions.Options;
using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace FOS.HostedService
{
    public class MailService : IMailService
    {
        private readonly EmailConfiguration _configuration;

        public MailService(EmailConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            using (SmtpClient client = new SmtpClient())
            {
                try
                {
                    var message = CreateMailMessage(mailRequest);
                    //client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    //client.CheckCertificateRevocation = false;
                    await client.ConnectAsync(_configuration.SmtpServer, _configuration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_configuration.UserName, _configuration.Password);
                    await client.SendAsync(message);
                }
                catch (Exception ex)
                {
                    string a = ex.Message;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }

        }

        public MimeMessage CreateMailMessage(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_configuration.From);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            return email;
        }
    }
}
