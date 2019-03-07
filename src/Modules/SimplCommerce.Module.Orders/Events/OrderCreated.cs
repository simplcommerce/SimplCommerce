using MediatR;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Events
{
    public class OrderCreated : INotification
    {
        public long OrderId { get; set; }

        public Order Order { get; set; }

        public long UserId { get; set; }

        public string Note { get; set; }
    }
}
