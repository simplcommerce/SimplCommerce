using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.EmailSenderSendgrid
{
    public class EmailSender : IEmailSender
    {
        private readonly string _apiKey;
        private readonly string _fromEmail;
        private readonly string _fromName;

        public EmailSender(IConfiguration configuration)
        {
            _apiKey = configuration.GetValue<string>("SendGrid:ApiKey");
            _fromEmail = configuration.GetValue<string>("SendGrid:FromEmail");
            _fromName = configuration.GetValue<string>("SendGrid:FromName");

            Contract.Requires(string.IsNullOrWhiteSpace(_apiKey));
            Contract.Requires(string.IsNullOrWhiteSpace(_fromEmail));
            Contract.Requires(string.IsNullOrWhiteSpace(_fromName));
        }
        public async Task SendEmailAsync(string email, string subject, string message, bool isHtml = false)
        {
            Contract.Requires(string.IsNullOrWhiteSpace(email));
            Contract.Requires(string.IsNullOrWhiteSpace(subject));
            Contract.Requires(string.IsNullOrWhiteSpace(message));

            var sendGridMessage = new SendGridMessage();

            sendGridMessage.From = new EmailAddress(_fromEmail, _fromName);
            sendGridMessage.AddTo(new EmailAddress(email));
            sendGridMessage.Subject = subject;
            sendGridMessage.HtmlContent = isHtml ? message : "";
            sendGridMessage.PlainTextContent = isHtml ? Regex.Replace(message, "<[^>]*>", "") : message;

            var client = new SendGridClient(_apiKey);
            await client.SendEmailAsync(sendGridMessage);
        }
    }
}
