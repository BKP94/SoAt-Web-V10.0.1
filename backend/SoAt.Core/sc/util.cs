using System.Net;
using System.Net.Mail;

namespace sc
{
    public class util
    {
        // ─── Temp file ────────────────────────────────────────────────────────────

        public static string getTempFile(string fileName)
        {
            var dir = Path.Combine(AppContext.BaseDirectory, "temp");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return Path.Combine(dir, fileName);
        }

        // ─── Email ────────────────────────────────────────────────────────────────

        public class SmtpSettings
        {
            public string Host     { get; set; } = string.Empty;
            public int    Port     { get; set; } = 587;
            public bool   EnableSsl { get; set; } = true;
            public string UserName { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        public static void sendEmail(SmtpSettings settings, string subject, string htmlBody, string toEmails)
        {
            using var client = new SmtpClient(settings.Host, settings.Port)
            {
                DeliveryMethod        = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials           = new NetworkCredential(settings.UserName, settings.Password),
                EnableSsl             = settings.EnableSsl
            };
            using var mail = new MailMessage(settings.UserName, toEmails)
            {
                Subject    = subject,
                Body       = htmlBody,
                IsBodyHtml = true
            };
            client.Send(mail);
        }
    }
}
