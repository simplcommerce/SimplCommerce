using System.Threading.Tasks;

namespace SimplCommerce.Module.Core.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}