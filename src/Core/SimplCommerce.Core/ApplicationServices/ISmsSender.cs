using System.Threading.Tasks;

namespace SimplCommerce.Core.ApplicationServices
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}