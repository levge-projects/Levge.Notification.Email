using Levge.Notification.Email.Interfaces;
using Levge.Notification.Email.Models;
using Levge.Notification.Email.Providers;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for registering email notification services in the dependency injection container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the email notification service using configuration from <see cref="IConfiguration"/>.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The application configuration.</param>
        /// <returns>The updated service collection.</returns>
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

        /// <summary>
        /// Registers the email notification service using a provided <see cref="EmailConfig"/> instance.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="config">The email configuration instance.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddEmailNotification(this IServiceCollection services, EmailConfig config)
        {
            var provider = config.Provider?.ToLowerInvariant();
            services.AddSingleton(config);

            return provider switch
            {
                "smtp" => services.AddSingleton<IEmailSender, SmtpEmailSender>(),
                "fake" => services.AddSingleton<IEmailSender, FakeEmailSender>(),
                _ => throw new NotSupportedException($"Email provider '{provider}' is not supported.")
            };
        }
    }
}
