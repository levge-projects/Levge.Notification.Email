# Levge.Notification.Email

.NET 8 i�in geli�tirilebilir, provider tabanl� e-posta bildirim k�t�phanesi. SMTP ve Fake provider deste�iyle gelir, kolay DI entegrasyonu ve �zel provider ekleme imkan� sunar.

---

## ?? Kurulum
dotnet add package Levge.Notification.Email
---

## ?? Konfig�rasyon

`appsettings.json` dosyan�za a�a��daki gibi ekleyin:
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

## ?? Kullan�m �rne�i
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
            Subject = "Ho�geldiniz!",
            Body = "<h1>Merhaba ??</h1>",
            Cc = new List<string> { "copy@example.com" },
            Bcc = new List<string> { "hidden@example.com" }
        });
    }
}
---

## ?? Sa�lanan Providerlar

| Provider   | Durum           |
|------------|-----------------|
| `Smtp`     | ? Destekleniyor |
| `Fake`     | ? Destekleniyor |
| `SendGrid` | ?? Yak�nda      |

Kendi provider�n�z� eklemek i�in `IEmailSender` aray�z�n� implemente edebilirsiniz.

---

## ??? Lisans

MIT � [Levge](https://github.com/levge-projects)
