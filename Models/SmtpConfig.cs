namespace Levge.Notification.Email.Models
{
    internal class SmtpConfig
    {
        public string Host { get; set; } = null!;
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; } = false;
        public string From { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
