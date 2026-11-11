using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using Xunit;

namespace SimplCommerce.Module.Orders.Tests
{
    public class OrderServiceTests
    {
        // IsAwaitingPayment does not use any of the dependencies
        private readonly OrderService _orderService = new OrderService(null, null, null, null, null, null, null, null, null, null, null);

        [Theory]
        [InlineData(OrderStatus.PendingPayment, true)]
        [InlineData(OrderStatus.PaymentFailed, true)]
        [InlineData(OrderStatus.Canceled, false)]
        [InlineData(OrderStatus.PaymentReceived, false)]
        [InlineData(OrderStatus.New, false)]
        [InlineData(OrderStatus.Shipped, false)]
        public void IsAwaitingPayment_ReturnsTrueOnlyForUnpaidOrders(OrderStatus status, bool expected)
        {
            var order = new Order { OrderStatus = status };

            Assert.Equal(expected, _orderService.IsAwaitingPayment(order));
        }
    }
}
