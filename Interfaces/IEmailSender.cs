using Levge.Notification.Email.Models;

namespace Levge.Notification.Email.Interfaces
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default);
    }
}
