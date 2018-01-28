using System.Threading.Tasks;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Services
{
    public interface IOrderEmailService
    {
        Task SendEmailToUser(User user, Order order);
    }
}
