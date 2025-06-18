# Levge.Notification.Email

.NET 8 için geliþtirilebilir, provider tabanlý e-posta bildirim kütüphanesi. SMTP ve Fake provider desteðiyle gelir, kolay DI entegrasyonu ve özel provider ekleme imkaný sunar.

---

## ?? Kurulum
dotnet add package Levge.Notification.Email
---

## ?? Konfigürasyon

`appsettings.json` dosyanýza aþaðýdaki gibi ekleyin:
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

## ?? DI Entegrasyonu
builder.Services.AddEmailNotification(builder.Configuration);
---

## ?? Kullaným Örneði
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
            Subject = "Hoþgeldiniz!",
            Body = "<h1>Merhaba ??</h1>",
            Cc = new List<string> { "copy@example.com" },
            Bcc = new List<string> { "hidden@example.com" }
        });
    }
}
---

## ?? Saðlanan Providerlar

| Provider   | Durum           |
|------------|-----------------|
| `Smtp`     | ? Destekleniyor |
| `Fake`     | ? Destekleniyor |
| `SendGrid` | ?? Yakýnda      |

Kendi providerýnýzý eklemek için `IEmailSender` arayüzünü implemente edebilirsiniz.

---

## ??? Lisans

MIT © [Levge](https://github.com/levge-projects)
