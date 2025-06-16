using Levge.Notification.Email.Interfaces;
using Levge.Notification.Email.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Levge.Notification.Email.Providers
{
    internal class SmtpEmailSender : IEmailSender
    {
        private readonly EmailConfig _config;

        public SmtpEmailSender(IOptions<EmailConfig> options)
        {
            _config = options.Value;
        }

        public async Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default)
        {
            if (_config.Smtp is null)
                throw new InvalidOperationException("SMTP config is not provided.");

            var smtp = _config.Smtp;

            using var client = new SmtpClient(smtp.Host, smtp.Port)
            {
                EnableSsl = smtp.EnableSsl,
                Credentials = smtp.UseDefaultCredentials
                    ? CredentialCache.DefaultNetworkCredentials
                    : new NetworkCredential(smtp.Username, smtp.Password)
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_config.Smtp.From),
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = message.IsHtml,
            };

            message.To.ForEach(to => mail.To.Add(to));
            message.Cc?.ForEach(cc => mail.CC.Add(cc));
            message.Bcc?.ForEach(bcc => mail.Bcc.Add(bcc));
            message.Attachments?.ForEach(a => mail.Attachments.Add(a));

            await client.SendMailAsync(mail, cancellationToken);
        }
    }
}
