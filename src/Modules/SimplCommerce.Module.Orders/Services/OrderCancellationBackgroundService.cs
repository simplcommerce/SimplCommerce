using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Orders.Events;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Services
{
    public class OrderCancellationBackgroundService : BackgroundService
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Order> _orderRepository;
        private readonly long SystemUserId = 2;

        public OrderCancellationBackgroundService(IMediator mediator, IRepository<Order> orderRepository)
        {
            _mediator = mediator;
            _orderRepository = orderRepository;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await CancelFailedPaymentOrders(stoppingToken);
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }

        private async Task CancelFailedPaymentOrders(CancellationToken stoppingToken)
        {
            var shouldCancelFailedPaymentOrders = _orderRepository.Query().Where(x => x.OrderStatus == OrderStatus.PendingPayment && x.UpdatedOn < DateTimeOffset.Now.AddMinutes(-5));
            foreach(var order in shouldCancelFailedPaymentOrders)
            {
                order.OrderStatus = OrderStatus.Canceled;
                order.UpdatedOn = DateTimeOffset.Now;
                // TODO Rollback product stock
                var orderStatusChanged = new OrderChanged
                {
                    OrderId = order.Id,
                    OldStatus = OrderStatus.PendingPayment,
                    NewStatus = OrderStatus.Canceled,
                    UserId = SystemUserId,
                    Order = order,
                    Note = "System cancel"
                };

                await _mediator.Publish(orderStatusChanged, stoppingToken);
            }

            await _orderRepository.SaveChangesAsync();
        }
    }
}
