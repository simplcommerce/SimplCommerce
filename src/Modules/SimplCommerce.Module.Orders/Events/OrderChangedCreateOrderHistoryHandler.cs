using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Events
{
    public class OrderChangedCreateOrderHistoryHandler : INotificationHandler<OrderChanged>
    {
        private readonly IRepository<OrderHistory> _orderHistoryRepository;

        public OrderChangedCreateOrderHistoryHandler(IRepository<OrderHistory> orderHistoryRepository)
        {
            _orderHistoryRepository = orderHistoryRepository;
        }

        public async Task Handle(OrderChanged notification, CancellationToken cancellationToken)
        {
            var orderHistory = new OrderHistory
            {
                OrderId = notification.OrderId,
                CreatedOn = DateTimeOffset.Now,
                CreatedById = notification.UserId,
                OldStatus = notification.OldStatus,
                NewStatus = notification.NewStatus,
                Note = notification.Note,
            };

            if(notification.Order != null)
            {
                orderHistory.OrderSnapshot = JsonConvert.SerializeObject(notification.Order);
            }

            _orderHistoryRepository.Add(orderHistory);
            await _orderHistoryRepository.SaveChangesAsync();
        }
    }
}
