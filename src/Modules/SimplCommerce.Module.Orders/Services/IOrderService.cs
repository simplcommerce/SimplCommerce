using System.Threading.Tasks;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Create order for user from active cart
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Order> CreateOrder(User user, string paymentMethod);

        Task<Order> CreateOrder(User user, string paymentMethod, string shippingMethod, Address billingAddress, Address shippingAddress);

        Task<decimal> GetTax(long cartOwnerUserId, long countryId, long stateOrProvinceId);
    }
}
