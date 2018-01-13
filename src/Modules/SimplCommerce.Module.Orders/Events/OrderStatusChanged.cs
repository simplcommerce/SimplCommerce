using MediatR;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Events
{
    public class OrderStatusChanged : INotification
    {
        public long OrderId { get; set; }

        public OrderStatus OldStatus { get; set; }

        public OrderStatus NewStatus { get; set; }

        public long UserId { get; set; }

        public string Note { get; set; }
    }
}
