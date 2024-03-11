using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimplCommerce.Module.Inventory.Services;

namespace SimplCommerce.Module.Inventory.Event
{
    public class ProductBackInStockSendEmailHandler : INotificationHandler<ProductBackInStock>
    {
        public readonly IStockSubscriptionService _stockSubscriptionService;

        public ProductBackInStockSendEmailHandler(IStockSubscriptionService stockSubscriptionService)
            => _stockSubscriptionService = stockSubscriptionService;

        public async Task Handle(ProductBackInStock notification, CancellationToken cancellationToken)
            => await _stockSubscriptionService.ProductBackInStockSendNotificationsAsync(notification.ProductId);
    }
}
