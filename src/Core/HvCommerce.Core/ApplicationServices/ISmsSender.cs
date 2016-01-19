using System.Threading.Tasks;

namespace HvCommerce.Core.ApplicationServices
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}