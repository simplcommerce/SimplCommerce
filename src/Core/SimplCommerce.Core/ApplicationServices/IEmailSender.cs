using System.Threading.Tasks;

namespace SimplCommerce.Core.ApplicationServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}