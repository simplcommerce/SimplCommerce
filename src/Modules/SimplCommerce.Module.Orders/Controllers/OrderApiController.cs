using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.ViewModels;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.Orders.Controllers
{
    [Authorize(Roles = "admin, vendor")]
    [Route("api/orders")]
    public class OrderApiController : Controller
    {
        private readonly IMediaService _mediaService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IWorkContext _workContext;

        public OrderApiController(IRepository<Order> orderRepository, IMediaService mediaService, IWorkContext workContext)
        {
            _orderRepository = orderRepository;
            _mediaService = mediaService;
            _workContext = workContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get(int status, int numRecords)
        {
            var orderStatus = (OrderStatus) status;
            if ((numRecords <= 0) || (numRecords > 100))
            {
                numRecords = 5;
            }

            var query = _orderRepository
                .Query()
                .Where(x => x.OrderStatus == orderStatus);

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin"))
            {
                query = query.Where(x => x.VendorId == currentUser.VendorId);
            }

            var model = query.OrderByDescending(x => x.CreatedOn)
                .Take(numRecords)
                .Select(x => new
                {
                    x.Id,
                    CustomerName = x.CreatedBy.FullName, x.SubTotal,
                    OrderStatus = x.OrderStatus.ToString(), x.CreatedOn
                });

            return Json(model);
        }

        [HttpPost("grid")]
        public async Task<ActionResult> List([FromBody] SmartTableParam param)
        {
            IQueryable<Order> query = _orderRepository
                .Query();

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin"))
            {
                query = query.Where(x => x.VendorId == currentUser.VendorId);
            }

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;
                if (search.Id != null)
                {
                    long id = search.Id;
                    query = query.Where(x => x.Id == id);
                }

                if (search.Status != null)
                {
                    var status = (OrderStatus) search.Status;
                    query = query.Where(x => x.OrderStatus == status);
                }

                if (search.CustomerName != null)
                {
                    string customerName = search.CustomerName;
                    query = query.Where(x => x.CreatedBy.FullName.Contains(customerName));
                }

                if (search.CreatedOn != null)
                {
                    if (search.CreatedOn.before != null)
                    {
                        DateTimeOffset before = search.CreatedOn.before;
                        query = query.Where(x => x.CreatedOn <= before);
                    }

                    if (search.CreatedOn.after != null)
                    {
                        DateTimeOffset after = search.CreatedOn.after;
                        query = query.Where(x => x.CreatedOn >= after);
                    }
                }
            }

            var orders = query.ToSmartTableResult(
                param,
                order => new
                {
                    order.Id,
                    CustomerName = order.CreatedBy.FullName, order.SubTotal,
                    OrderStatus = order.OrderStatus.ToString(), order.CreatedOn
                });

            return Json(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var order = _orderRepository
                .Query()
                .Include(x => x.ShippingAddress).ThenInclude(x => x.District).ThenInclude(x => x.StateOrProvince)
                .Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.ThumbnailImage)
                .Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.OptionCombinations).ThenInclude(x => x.Option)
                .Include(x => x.CreatedBy)
                .FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return new NotFoundResult();
            }

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin") && order.VendorId != currentUser.VendorId)
            {
                return new BadRequestObjectResult(new { error = "You don't have permission to manage this order" });
            }

            var model = new OrderDetailVm
            {
                Id = order.Id,
                CreatedOn = order.CreatedOn,
                OrderStatus = (int) order.OrderStatus,
                OrderStatusString = order.OrderStatus.ToString(),
                CustomerName = order.CreatedBy.FullName,
                SubTotal = order.SubTotal,
                ShippingAddress = new ShippingAddressVm
                {
                    AddressLine1 = order.ShippingAddress.AddressLine1,
                    AddressLine2 = order.ShippingAddress.AddressLine2,
                    ContactName = order.ShippingAddress.ContactName,
                    DistrictName = order.ShippingAddress.District.Name,
                    StateOrProvinceName = order.ShippingAddress.StateOrProvince.Name,
                    Phone = order.ShippingAddress.Phone
                },
                OrderItems = order.OrderItems.Select(x => new OrderItemVm
                {
                    Id = x.Id,
                    ProductName = x.Product.Name,
                    ProductPrice = x.ProductPrice,
                    ProductImage = _mediaService.GetThumbnailUrl(x.Product.ThumbnailImage),
                    Quantity = x.Quantity,
                    VariationOptions = OrderItemVm.GetVariationOption(x.Product)
                }).ToList()
            };

            return Json(model);
        }

        [HttpPost("change-order-status/{id}")]
        public async Task<IActionResult> ChangeStatus(long id, [FromBody] int statusId)
        {
            var order = _orderRepository.Query().FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin") && order.VendorId != currentUser.VendorId)
            {
                return new BadRequestObjectResult(new { error = "You don't have permission to manage this order" });
            }

            if (Enum.IsDefined(typeof(OrderStatus), statusId))
            {
                order.OrderStatus = (OrderStatus) statusId;
                _orderRepository.SaveChange();
                return Ok();
            }
            return BadRequest(new {Error = "unsupported order status"});
        }

        [HttpGet("order-status")]
        public IActionResult GetOrderStatus()
        {
            var model = EnumHelper.ToDictionary(typeof(OrderStatus)).Select(x => new {Id = x.Key, Name = x.Value});
            return Json(model);
        }
    }
}