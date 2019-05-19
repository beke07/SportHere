using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace SportHere.Bll.Services
{
    public class EmailSettings
    {
        public string PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public string SecondayDomain { get; set; }
        public int SecondayPort { get; set; }
        public string UsernameEmail { get; set; }
        public string UsernamePassword { get; set; }
        public string FromEmail { get; set; }
    }

    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings emailSettings;
        private readonly IHostEnvironment env;

        public EmailSender(
            IOptions<EmailSettings> emailSettings,
            IHostEnvironment env)
        {
            this.emailSettings = emailSettings.Value;
            this.env = env;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                    mimeMessage.From.Add(new MailboxAddress(emailSettings.UsernameEmail, emailSettings.FromEmail));
                    mimeMessage.To.Add(new MailboxAddress(email));
                    mimeMessage.Subject = subject;
                    mimeMessage.Body = new TextPart("html")
                    {
                        Text = message
                    };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    if (env.IsDevelopment())
                    {
                        await client.ConnectAsync(emailSettings.PrimaryDomain, emailSettings.PrimaryPort, true);
                    }
                    else
                    {
                        await client.ConnectAsync(emailSettings.PrimaryDomain);
                    }

                    await client.AuthenticateAsync(emailSettings.UsernameEmail, emailSettings.UsernamePassword);
                    await client.SendAsync(mimeMessage);

                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

        }
    }
}
