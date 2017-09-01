using System.Threading.Tasks;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Orders.Services
{
    public interface IOrderService
    {
        Task CreateOrder(User user, Address billingAddress, Address shippingAddress);
    }
}
