using System.Net.Mail;

namespace Levge.Notification.Email.Models
{
    /// <summary>
    /// Represents an email message with recipients, subject, body, and optional attachments.
    /// </summary>
    public class EmailMessage
    {
        /// <summary>
        /// Gets or sets the list of recipient email addresses.
        /// </summary>
        public List<string> To { get; set; } = new();

        /// <summary>
        /// Gets or sets the list of CC recipient email addresses.
        /// </summary>
        public List<string>? Cc { get; set; }

        /// <summary>
        /// Gets or sets the list of BCC recipient email addresses.
        /// </summary>
        public List<string>? Bcc { get; set; }

        /// <summary>
        /// Gets or sets the sender email address.
        /// </summary>
        public string? From { get; set; }

        /// <summary>
        /// Gets or sets the subject of the email.
        /// </summary>
        public string Subject { get; set; } = null!;

        /// <summary>
        /// Gets or sets the body content of the email.
        /// </summary>
        public string Body { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating whether the body is HTML.
        /// </summary>
        public bool IsHtml { get; set; } = true;

        /// <summary>
        /// Gets or sets the list of attachments for the email.
        /// </summary>
        public List<Attachment>? Attachments { get; set; }
    }
}
