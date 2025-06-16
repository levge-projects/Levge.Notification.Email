using Levge.Exceptions;
using Levge.Extensions;
using Levge.Notification.Email.Interfaces;
using Levge.Notification.Email.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Levge.Notification.Email.Providers
{
    internal class SmtpEmailSender : IEmailSender
    {
        private readonly EmailConfig _config;
        private readonly ILogger<SmtpEmailSender> _logger;

        public SmtpEmailSender(IOptions<EmailConfig> options, ILogger<SmtpEmailSender> logger)
        {
            _config = options.Value;
            _logger = logger;
        }

        public Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default, bool fireAndForget = false)
        {
            if (fireAndForget)
            {
                SendInternalAsync(message, cancellationToken).FireAndForget(_logger, nameof(SmtpEmailSender));
                return Task.CompletedTask;
            }

            return SendInternalAsync(message, cancellationToken);
        }

        private async Task SendInternalAsync(EmailMessage message, CancellationToken cancellationToken)
        {
            try
            {
                if (_config.Smtp is null)
                    throw new LevgeException("SMTP config is not provided.");

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
                    From = new MailAddress(smtp.From),
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email via SMTP.");
                throw new LevgeException("Failed to send email via SMTP.", ex);
            }
        }
    }
}
