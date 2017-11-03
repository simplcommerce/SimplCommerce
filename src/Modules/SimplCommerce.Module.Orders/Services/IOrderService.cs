using System.Threading.Tasks;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Shipping.Models;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(User user, Address billingAddress, Address shippingAddress, ShippingMethod shippingmethod, PaymentType.Models.PaymentType paymentmethod);
    }
}
