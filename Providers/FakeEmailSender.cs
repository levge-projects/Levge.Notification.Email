using Levge.Exceptions;
using Levge.Extensions;
using Levge.Notification.Email.Interfaces;
using Levge.Notification.Email.Models;
using Microsoft.Extensions.Logging;

namespace Levge.Notification.Email.Providers
{
    /// <summary>
    /// Provides a fake email sender for testing and development purposes.
    /// </summary>
    internal class FakeEmailSender : IEmailSender
    {
        private readonly ILogger<FakeEmailSender> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeEmailSender"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public FakeEmailSender(ILogger<FakeEmailSender> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default, bool fireAndForget = false)
        {
            if (fireAndForget)
            {
                SendInternalAsync(message).FireAndForget(_logger, nameof(FakeEmailSender));
                return Task.CompletedTask;
            }

            return SendInternalAsync(message);
        }

        /// <summary>
        /// Simulates sending an email message for testing purposes.
        /// </summary>
        /// <param name="message">The email message to simulate sending.</param>
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
