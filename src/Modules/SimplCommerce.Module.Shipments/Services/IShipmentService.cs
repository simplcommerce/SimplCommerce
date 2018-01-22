using System.Collections.Generic;
using System.Threading.Tasks;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Shipments.Models;

namespace SimplCommerce.Module.Shipments.Services
{
    public interface IShipmentService
    {
        Task<IList<ShipmentItemVm>> GetShipmentItem(long orderId);

        Task<IList<ShipmentItemVm>> GetItemToShip(long orderId, long warehouseId);

        Task<Result> CreateShipment(Shipment shipment);
    }
}
