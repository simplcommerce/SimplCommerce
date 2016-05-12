using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Orders.ApplicationServices
{
    public interface IOrderService
    {
        void CreateOrder(User user);
    }
}