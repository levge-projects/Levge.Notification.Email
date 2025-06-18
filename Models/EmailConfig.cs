namespace Levge.Notification.Email.Models
{
    /// <summary>
    /// Represents the configuration settings for email providers.
    /// </summary>
    public class EmailConfig
    {
        /// <summary>
        /// Gets or sets the email provider type (e.g., Smtp, Fake).
        /// </summary>
        public string Provider { get; set; } = "Smtp";

        /// <summary>
        /// Gets or sets the SMTP configuration if the provider is SMTP.
        /// </summary>
        public SmtpConfig? Smtp { get; set; }
    }
}
