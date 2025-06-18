namespace Levge.Notification.Email.Models
{
    /// <summary>
    /// Represents the configuration settings for SMTP email provider.
    /// </summary>
    public class SmtpConfig
    {
        /// <summary>
        /// Gets or sets the SMTP server host.
        /// </summary>
        public string Host { get; set; } = null!;

        /// <summary>
        /// Gets or sets the SMTP server port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SSL is enabled for SMTP.
        /// </summary>
        public bool EnableSsl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use default credentials.
        /// </summary>
        public bool UseDefaultCredentials { get; set; } = false;

        /// <summary>
        /// Gets or sets the sender email address.
        /// </summary>
        public string From { get; set; } = null!;

        /// <summary>
        /// Gets or sets the username for SMTP authentication.
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Gets or sets the password for SMTP authentication.
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
