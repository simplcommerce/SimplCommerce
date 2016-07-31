using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Orders.Services
{
    public interface IOrderService
    {
        void CreateOrder(User user);
    }
}
