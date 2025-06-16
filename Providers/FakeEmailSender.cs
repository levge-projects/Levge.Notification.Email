using Levge.Notification.Email.Interfaces;
using Levge.Notification.Email.Models;

namespace Levge.Notification.Email.Providers
{
    internal class FakeEmailSender : IEmailSender
    {
        public Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"[FAKE EMAIL] To: {string.Join(",", message.To)} | Subject: {message.Subject}");
            return Task.CompletedTask;
        }
    }
}
