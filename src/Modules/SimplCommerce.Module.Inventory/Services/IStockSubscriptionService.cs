using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Inventory.Services
{
    public interface IStockSubscriptionService
    {
        Task BackInStockSubscribeAsync(long productId, string customerEmail);

        Task BackInStockSendNotificationsAsync(long productId);
    }
}
