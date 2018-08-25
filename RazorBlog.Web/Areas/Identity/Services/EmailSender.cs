using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorBlog.Web.Areas.Identity.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfig _emailConfig = new EmailConfig();

        public EmailSender(IConfiguration config)
        {
            //_emailConfig.SmtpServer = config.GetValue<string>("EmailConfig:SmtpServer");
            //_emailConfig.SmtpUsername = config.GetValue<string>("EmailConfig:SmtpUsername");
            //_emailConfig.SmtpPassword = config.GetValue<string>("EmailConfig:SmtpPassword");
            //_emailConfig.SmtpPort = config.GetValue<int>("EmailConfig:SmtpPort");
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailConfig.SmtpUsername));
            message.To.Add(new MailboxAddress(email));
            message.Subject = subject;

            var textFormat = TextFormat.Html;
            message.Body = new TextPart(textFormat)
            {
                Text = htmlMessage
            };

            using (var client = new SmtpClient())
            {
                // Accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.SmtpPort, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                await client.AuthenticateAsync(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }


    }

    public class EmailConfig
    {
        public string SmtpServer { get; set; }

        public int SmtpPort { get; set; }

        public string SmtpUsername { get; set; }

        public string SmtpPassword { get; set; }
    }
}
