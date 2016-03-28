using System.Threading.Tasks;

namespace Shopcuatoi.Core.ApplicationServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}