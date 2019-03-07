using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Orders.Events;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Services
{
    public class OrderCancellationBackgroundService : BackgroundService
    {
        private readonly long SystemUserId = 2;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public OrderCancellationBackgroundService(IServiceProvider serviceProvider, ILogger<OrderCancellationBackgroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("OrderCancellationBackgroundService is starting.");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("OrderCancellationBackgroundService is working.");
                using (var scope = _serviceProvider.CreateScope())
                {
                    var orderRepository = scope.ServiceProvider.GetRequiredService<IRepository<Order>>();
                    var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    await CancelFailedPaymentOrders(orderRepository, orderService, mediator, stoppingToken);
                }

                await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
            }

            _logger.LogInformation("OrderCancellationBackgroundService is stopping.");
        }

        private async Task CancelFailedPaymentOrders(IRepository<Order> orderRepository, IOrderService orderService, IMediator mediator, CancellationToken stoppingToken)
        {
            var durationToCancel = DateTimeOffset.Now.AddMinutes(-5);
            var failedPaymentOrders = orderRepository.Query().Where(x =>
                (x.OrderStatus == OrderStatus.PendingPayment || x.OrderStatus == OrderStatus.PaymentFailed)
                && x.LatestUpdatedOn < durationToCancel);

            foreach (var order in failedPaymentOrders)
            {
                orderService.CancelOrder(order);
                var orderStatusChanged = new OrderChanged
                {
                    OrderId = order.Id,
                    OldStatus = OrderStatus.PendingPayment,
                    NewStatus = OrderStatus.Canceled,
                    UserId = SystemUserId,
                    Order = order,
                    Note = "System canceled"
                };

                await mediator.Publish(orderStatusChanged, stoppingToken);
            }

            await orderRepository.SaveChangesAsync();
        }
    }
}
