using Levge.Notification.Email.Models;

namespace Levge.Notification.Email.Interfaces
{
    /// <summary>
    /// Defines the contract for sending emails.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email message asynchronously.
        /// </summary>
        /// <param name="message">The email message to send.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <param name="fireAndForget">If true, send operation is fire-and-forget.</param>
        Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default, bool fireAndForget = false);
    }
}
