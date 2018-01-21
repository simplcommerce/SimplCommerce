using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Shipments.Models;
using SimplCommerce.Module.Shipments.Services;
using SimplCommerce.Module.Shipments.ViewModels;

namespace SimplCommerce.Module.Shipments.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/shipments")]
    public class ShipmentApiController : Controller
    {
        private readonly IRepository<Shipment> _shipmentRepository;
        private readonly IShipmentService _shipmentService;
        private readonly IWorkContext _workContext;

        public ShipmentApiController(IRepository<Shipment> shipmentRepository, IShipmentService shipmentService, IWorkContext workContext)
        {
            _shipmentRepository = shipmentRepository;
            _shipmentService = shipmentService;
            _workContext = workContext;
        }

        [HttpGet("/api/orders/{orderId}/items-to-ship")]
        public async Task<IActionResult> GetItemsToShip(long orderId, long warehouseId)
        {
            var model = new ShipmentForm
            {
                OrderId = orderId,
                WarehouseId = warehouseId
            };

            var itemsToShip = await _shipmentService.GetItemToShip(orderId, warehouseId);
            foreach(var item in itemsToShip)
            {
                item.QuantityToShip = item.OrderedQuantity - item.ShippedQuantity;
            }

            model.Items = itemsToShip;
            return Ok(model);
        }

        [HttpGet("/api/orders/{orderId}/shipments")]
        public async Task<IActionResult> Get(long orderId)
        {
            var shipments = await _shipmentRepository.Query()
                .Where(x => x.OrderId == orderId)
                .Select(x => new
                {
                   
                }).ToListAsync();

            return Ok(shipments);
        }

        public async Task<IActionResult> Post([FromBody] ShipmentForm model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _workContext.GetCurrentUser();
                var shipment = new Shipment
                {
                    OrderId = model.OrderId,
                    WarehouseId = model.WarehouseId,
                    CreatedById = currentUser.Id,
                    TrackingNumber = model.TrackingNumber,
                    CreatedOn = DateTimeOffset.Now,
                    UpdatedOn = DateTimeOffset.Now
                };

                foreach(var item in model.Items)
                {
                    var shipmentItem = new ShipmentItem
                    {
                        Shipment = shipment,
                        Quantity = item.QuantityToShip,
                        ProductId = item.ProductId,
                        OrderItemId = item.OrderItemId
                    };

                    shipment.Items.Add(shipmentItem);
                }

                _shipmentRepository.Add(shipment);
                await _shipmentRepository.SaveChangesAsync();
                return NoContent();
            }

            return BadRequest(ModelState);
        }
    }
}
