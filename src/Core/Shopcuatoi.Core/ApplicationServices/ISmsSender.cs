using System.Threading.Tasks;

namespace Shopcuatoi.Core.ApplicationServices
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}