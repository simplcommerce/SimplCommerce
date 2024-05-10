using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Events
{
    public class OrderCreatedCreateDataRecomendationHandler : INotificationHandler<OrderCreated>
    {
        private readonly ILogger _logger;
        private readonly IRepository<OrderHistory> _orderHistoryRepository;
        private static string dataPath = Path.Combine(Environment.CurrentDirectory, "MLData/data.txt");

        public OrderCreatedCreateDataRecomendationHandler(
            IRepository<OrderHistory> orderHistoryRepository,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<OrderCreatedCreateDataRecomendationHandler>();
            _orderHistoryRepository = orderHistoryRepository;
        }

        public async Task Handle(OrderCreated notification, CancellationToken cancellationToken)
        {
            try
            {
                if (notification.Order != null
                    && notification.Order.OrderItems != null && notification.Order.OrderItems.Count > 1)
                {
                    StringBuilder sb = new StringBuilder();
                    for (var i = 0; i < notification.Order.OrderItems.Count - 1; i++)
                    {
                        var item = notification.Order.OrderItems[i];
                        for (var i2 = i + 1; i2 <= i + 2; i2++)
                        {
                            if (i2 < notification.Order.OrderItems.Count)
                            {
                                var item2 = notification.Order.OrderItems[i2];
                                if (item.ProductId != item2.ProductId)
                                {
                                    sb.AppendLine(string.Format("{0}\t{1}", item.ProductId, item2.ProductId));
                                }
                            }
                        }
                    }
                    await File.AppendAllTextAsync(dataPath, sb.ToString());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed executing event handler {GetType().Name}: {ex.Message}");
            }
        }
    }
}
