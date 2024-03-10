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
    public class BackInStockSendEmailHandler : INotificationHandler<BackInStock>
    {
        public readonly IStockSubscriptionService _stockSubscriptionService;

        public BackInStockSendEmailHandler(IStockSubscriptionService stockSubscriptionService)
        {
            _stockSubscriptionService = stockSubscriptionService;
        }

        public async Task Handle(BackInStock notification, CancellationToken cancellationToken)
        {
            await _stockSubscriptionService.BackInStockSendNotificationsAsync(notification.ProductId);
        }
    }
}
