using System.Threading.Tasks;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.EmailSenderSendgrid
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message, bool isHtml = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
