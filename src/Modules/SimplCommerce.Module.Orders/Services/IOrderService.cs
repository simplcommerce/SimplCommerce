using System;
using System.Threading.Tasks;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Areas.Orders.ViewModels;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Services
{
    public interface IOrderService
    {
        Task<Result<Order>> CreateOrder(Guid checkoutId, string paymentMethod, decimal paymentFeeAmount, OrderStatus orderStatus = OrderStatus.New);

        Task<Result<Order>> CreateOrder(Guid checkoutId, string paymentMethod, decimal paymentFeeAmount, string shippingMethod, Address billingAddress, Address shippingAddress, OrderStatus orderStatus = OrderStatus.New);

        void CancelOrder(Order order);

        Task<decimal> GetTax(Guid checkoutId, string countryId, long stateOrProvinceId, string zipCode);
    }
}
