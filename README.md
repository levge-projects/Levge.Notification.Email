[🇹🇷 Türkçe dokümantasyon için buraya tıklayın.](README.tr.md)

# Levge.Notification.Email

[![Publish NuGet Package](https://github.com/levge-projects/Levge.Notification.Email/actions/workflows/main.yml/badge.svg)](https://github.com/levge-projects/Levge.Notification.Email/actions/workflows/main.yml)
[![NuGet](https://img.shields.io/nuget/v/Levge.Notification.Email.svg)](https://www.nuget.org/packages/Levge.Notification.Email)

Extensible, provider-based email notification library for .NET 8. Supports SMTP and Fake providers out of the box, with easy DI integration and custom provider extensibility.

---

## 📦 Installation
dotnet add package Levge.Notification.Email
---

## ⚙️ Configuration

Add your email configuration in `appsettings.json`:
"EmailConfig": {
  "Provider": "Smtp",
  "Smtp": {
    "Host": "smtp.gmail.com",
    "Port": 587,
    "EnableSsl": true,
    "From": "noreply@domain.com",
    "Username": "test@gmail.com",
    "Password": "supersecret",
    "UseDefaultCredentials": false
  }
}
---

## 🔧 Dependency Injection Setup
builder.Services.AddEmailNotification(builder.Configuration);
---

## 📤 Usage Example
public class WelcomeService
{
    private readonly IEmailSender _emailSender;

    public WelcomeService(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task SendAsync()
    {
        await _emailSender.SendAsync(new EmailMessage
        {
            To = new List<string> { "test@example.com" },
            Subject = "Welcome!",
            Body = "<h1>Hello there 👋</h1>",
            Cc = new List<string> { "copy@example.com" },
            Bcc = new List<string> { "hidden@example.com" }
        });
    }
}
---

## 🧩 Providers

| Provider   | Status         |
|------------|----------------|
| `Smtp`     | ✅ Supported   |
| `Fake`     | ✅ Supported   |
| `SendGrid` | 🔜 Coming soon |

You can add custom providers by implementing `IEmailSender`.

---

## 🛡️ License

MIT © [Levge](https://github.com/levge-projects)
