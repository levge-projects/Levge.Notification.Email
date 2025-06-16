using Levge.Notification.Email.Interfaces;
using Levge.Notification.Email.Models;
using Levge.Notification.Email.Providers;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailNotification(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailConfig>(configuration.GetSection("EmailConfig"));

            var config = configuration.GetSection("EmailConfig").Get<EmailConfig>();
            var provider = config.Provider?.ToLowerInvariant();

            return provider switch
            {
                "smtp" => services.AddSingleton<IEmailSender, SmtpEmailSender>(),
                "fake" => services.AddSingleton<IEmailSender, FakeEmailSender>(),
                _ => throw new NotSupportedException($"Email provider '{provider}' is not supported.")
            };
        }
    }
}
