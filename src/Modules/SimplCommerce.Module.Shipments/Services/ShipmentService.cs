using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Inventory.Models;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Shipments.Models;

namespace SimplCommerce.Module.Shipments.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IRepository<Shipment> _shipmentRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IRepository<ShipmentItem> _shipmentItemRepository;
        private readonly IRepository<Stock> _stockRepository;

        public ShipmentService(IRepository<Shipment> shipmentRepository, IRepository<OrderItem> orderItemRepository, IRepository<ShipmentItem> shipmentItemRepository, IRepository<Stock> stockRepository)
        {
            _shipmentRepository = shipmentRepository;
            _orderItemRepository = orderItemRepository;
            _shipmentItemRepository = shipmentItemRepository;
            _stockRepository = stockRepository;
        }

        public async Task<IList<ShipmentItemVm>> GetItemToShip(long orderId, long warehouseId)
        {
            var itemsToShip = await GetShipmentItem(orderId);
            var productIdsToShip = itemsToShip.Select(x => x.ProductId);
            var stocks = await _stockRepository.Query().Where(x => x.WarehouseId == warehouseId && productIdsToShip.Contains(x.ProductId)).ToListAsync();
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
                var shippedItemsByProduct = shippedItems.Where(x => x.ProductId == item.ProductId);
                foreach(var shippedItemByProduct in shippedItemsByProduct)
                {
                    item.ShippedQuantity = item.ShippedQuantity + shippedItemByProduct.Quantity;
                }
            }

            return orderedItems;
        }

        public async Task<Result> CreateShipment(Shipment shipment)
        {
            if (!shipment.Items.Any())
            {
                return Result.Fail($"No item to ship");
            }

            var orderedItems = await GetShipmentItem(shipment.OrderId);
            foreach (var item in shipment.Items)
            {
                var orderedItem = orderedItems.FirstOrDefault(x => x.OrderItemId == item.OrderItemId);
                if(orderedItem == null)
                {
                    return Result.Fail($"Order item {item.OrderItemId} is not found");
                }

                if(item.Quantity > orderedItem.OrderedQuantity - orderedItem.ShippedQuantity)
                {
                    return Result.Fail($"Quantity to ship cannot be larger than ordered quantity + shipped quantity");
                }

                var stock = await _stockRepository.Query().Where(x => x.ProductId == item.ProductId && x.WarehouseId == shipment.WarehouseId).FirstOrDefaultAsync();
                if(stock == null || stock.Quantity < item.Quantity)
                {
                    return Result.Fail($"The product {item.ProductId} is out of stock in warehouse {shipment.WarehouseId}");
                }

                stock.Quantity = stock.Quantity - item.Quantity;
            }

            _shipmentRepository.Add(shipment);
            await _shipmentRepository.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
