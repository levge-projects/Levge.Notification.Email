using Levge.Exceptions;
using Levge.Extensions;
using Levge.Notification.Email.Interfaces;
using Levge.Notification.Email.Models;
using Microsoft.Extensions.Logging;

namespace Levge.Notification.Email.Providers
{
    internal class FakeEmailSender : IEmailSender
    {
        private readonly ILogger<FakeEmailSender> _logger;

        public FakeEmailSender(ILogger<FakeEmailSender> logger)
        {
            _logger = logger;
        }

        public Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default, bool fireAndForget = false)
        {
            if (fireAndForget)
            {
                SendInternalAsync(message).FireAndForget(_logger, nameof(FakeEmailSender));
                return Task.CompletedTask;
            }

            return SendInternalAsync(message);
        }

        private Task SendInternalAsync(EmailMessage message)
        {
            try
            {
                _logger.LogInformation("[FAKE EMAIL] → To: {To} | Subject: {Subject}", string.Join(", ", message.To), message.Subject);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "FakeEmailSender.SendAsync");
                throw new LevgeException("Fake email sending failed.", ex);
            }
        }
    }
}
