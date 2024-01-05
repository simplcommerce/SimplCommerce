using System.Threading.Tasks; 
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.EmailSenderSmtp
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfig _emailConfig = new EmailConfig();

        public EmailSender(IConfiguration config)
        {
            _emailConfig.SmtpServer = config.GetValue<string>("SmtpServer");
            _emailConfig.SmtpUsername = config.GetValue<string>("SmtpUsername");
            _emailConfig.SmtpPassword = config.GetValue<string>("SmtpPassword");
            _emailConfig.SmtpPort = config.GetValue<int>("SmtpPort");
        }

        public async Task SendEmailAsync(string email, string subject, string body, bool isHtml = false)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailConfig.SmtpUsername, _emailConfig.SmtpUsername));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = subject;

            var textFormat = isHtml ? TextFormat.Html : TextFormat.Plain;
            message.Body = new TextPart(textFormat)
            {
                Text = body
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
}
