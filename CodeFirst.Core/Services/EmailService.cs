using CodeFirst.Core.Interfaces;
using CodeFirst.Domain.Settings;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace CodeFirst.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public void Send(string to, string subject, string html)
        {
            MailMessage email = new(_mailSettings.From, to, subject, html);

            email.IsBodyHtml = true;

            SmtpClient _smtpClient = new(_mailSettings.SmtpServer);
            _smtpClient.EnableSsl = _mailSettings.EnableSsl;
            _smtpClient.UseDefaultCredentials = false;

            _smtpClient.Port = _mailSettings.Port;
            _smtpClient.Credentials = new System.Net.NetworkCredential(_mailSettings.From, _mailSettings.Password);

            _smtpClient.Send(email);

            _smtpClient.Dispose();

        }
    }
}