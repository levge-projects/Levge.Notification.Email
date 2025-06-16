namespace Levge.Notification.Email.Models
{
    internal class EmailConfig
    {
        public string Provider { get; set; } = "Smtp";

        public SmtpConfig? Smtp { get; set; }
    }
}
