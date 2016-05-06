using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Orders.ApplicationServices
{
    public interface IOrderService
    {
        void CreateOrder(User user);
    }
}