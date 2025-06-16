using System.Net.Mail;

namespace Levge.Notification.Email.Models
{
    public class EmailMessage
    {
        public List<string> To { get; set; } = new();
        public List<string>? Cc { get; set; }
        public List<string>? Bcc { get; set; }

        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public bool IsHtml { get; set; } = true;

        public List<Attachment>? Attachments { get; set; }
    }
}
