using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Inventory.Models;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Shipments.Models;

namespace SimplCommerce.Module.Shipments.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IRepository<ShipmentItem> _shipmentItemRepository;
        private readonly IRepository<Stock> _stockRepository;

        public ShipmentService(IRepository<OrderItem> orderItemRepository, IRepository<ShipmentItem> shipmentItemRepository, IRepository<Stock> stockRepository)
        {
            _orderItemRepository = orderItemRepository;
            _shipmentItemRepository = shipmentItemRepository;
            _stockRepository = stockRepository;
        }

        public async Task<IList<ShipmentItemVm>> GetItemToShip(long orderId, long warehouseId)
        {
            var itemsToShip = await GetShipmentItem(orderId);
            var stocks = await _stockRepository.Query().Where(x => x.WarehouseId == warehouseId && itemsToShip.Any(p => p.ProductId == x.ProductId)).ToListAsync();
            foreach(var item in itemsToShip)
            {
                var stock = stocks.FirstOrDefault(x => x.ProductId == item.ProductId);
                if(stock != null)
                {
                    item.AvailableQuantity = stock.Quantity;
                }
            }

            return itemsToShip;
        }

        public async Task<IList<ShipmentItemVm>> GetShipmentItem(long orderId)
        {
            var orderedItems = await _orderItemRepository.Query()
                .Where(x => x.Order.Id == orderId)
                .Select(x => new ShipmentItemVm
                {
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    ProductSku = x.Product.Sku,
                    OrderItemId = x.Id,
                    OrderedQuantity = x.Quantity
                })
                .ToListAsync();

            var shippedItems = await _shipmentItemRepository.Query()
                .Where(x => x.Shipment.OrderId == orderId)
                .ToListAsync();

            if(!shippedItems.Any())
            {
                return orderedItems;
            }

            foreach(var item in orderedItems)
            {
                var shippedItem = shippedItems.FirstOrDefault(x => x.ProductId == item.ProductId);
                if (shippedItem != null)
                {
                    item.ShippedQuantity = shippedItem.Quantity;
                }
            }

            return orderedItems;
        }
    }
}
