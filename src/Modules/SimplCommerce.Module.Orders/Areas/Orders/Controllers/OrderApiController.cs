using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.ViewModels;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Events;

namespace SimplCommerce.Module.Orders.Controllers
{
    [Area("Orders")]
    [Authorize(Roles = "admin, vendor")]
    [Route("api/orders")]
    public class OrderApiController : Controller
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IWorkContext _workContext;
        private readonly IMediator _mediator;

        public OrderApiController(IRepository<Order> orderRepository, IWorkContext workContext, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _workContext = workContext;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get(int status, int numRecords)
        {
            var orderStatus = (OrderStatus) status;
            if ((numRecords <= 0) || (numRecords > 100))
            {
                numRecords = 5;
            }

            var query = _orderRepository.Query();
            if(orderStatus != 0)
            {
                query = query.Where(x => x.OrderStatus == orderStatus);
            }

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
                    CustomerName = x.CreatedBy.FullName,
                    x.OrderTotal,
                    OrderTotalString = x.OrderTotal.ToString("C"),
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
                    CustomerName = order.CreatedBy.FullName,
                    order.OrderTotal,
                    OrderStatus = order.OrderStatus.ToString(),
                    order.CreatedOn
                });

            return Json(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var order = _orderRepository
                .Query()
                .Include(x => x.ShippingAddress).ThenInclude(x => x.District)
                .Include(x => x.ShippingAddress).ThenInclude(x => x.StateOrProvince)
                .Include(x => x.ShippingAddress).ThenInclude(x => x.Country)
                .Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.ThumbnailImage)
                .Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.OptionCombinations).ThenInclude(x => x.Option)
                .Include(x => x.CreatedBy)
                .FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin") && order.VendorId != currentUser.VendorId)
            {
                return BadRequest(new { error = "You don't have permission to manage this order" });
            }

            var model = new OrderDetailVm
            {
                Id = order.Id,
                IsMasterOrder = order.IsMasterOrder,
                CreatedOn = order.CreatedOn,
                OrderStatus = (int) order.OrderStatus,
                OrderStatusString = order.OrderStatus.ToString(),
                CustomerId = order.CreatedById,
                CustomerName = order.CreatedBy.FullName,
                CustomerEmail = order.CreatedBy.Email,
                ShippingMethod = order.ShippingMethod,
                PaymentMethod = order.PaymentMethod,
                PaymentFeeAmount = order.PaymentFeeAmount,
                Subtotal = order.SubTotal,
                DiscountAmount = order.DiscountAmount,
                SubTotalWithDiscount = order.SubTotalWithDiscount,
                TaxAmount = order.TaxAmount,
                ShippingAmount = order.ShippingFeeAmount,
                OrderTotal = order.OrderTotal,
                ShippingAddress = new ShippingAddressVm
                {
                    AddressLine1 = order.ShippingAddress.AddressLine1,
                    AddressLine2 = order.ShippingAddress.AddressLine2,
                    ContactName = order.ShippingAddress.ContactName,
                    DistrictName = order.ShippingAddress.District?.Name,
                    StateOrProvinceName = order.ShippingAddress.StateOrProvince.Name,
                    Phone = order.ShippingAddress.Phone
                },
                OrderItems = order.OrderItems.Select(x => new OrderItemVm
                {
                    Id = x.Id,
                    ProductId = x.Product.Id,
                    ProductName = x.Product.Name,
                    ProductPrice = x.ProductPrice,
                    Quantity = x.Quantity,
                    DiscountAmount = x.DiscountAmount,
                    TaxAmount = x.TaxAmount,
                    TaxPercent = x.TaxPercent,
                    VariationOptions = OrderItemVm.GetVariationOption(x.Product)
                }).ToList()
            };

            if (order.IsMasterOrder)
            {
                model.SubOrderIds = _orderRepository.Query().Where(x => x.ParentId == order.Id).Select(x => x.Id).ToList();
            }

            await _mediator.Publish(new OrderDetailGot { OrderDetailVm = model });

            return Json(model);
        }

        [HttpPost("change-order-status/{id}")]
        public async Task<IActionResult> ChangeStatus(long id, [FromBody] OrderStatusForm model)
        {
            var order = _orderRepository.Query().FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin") && order.VendorId != currentUser.VendorId)
            {
                return BadRequest(new { error = "You don't have permission to manage this order" });
            }

            if (Enum.IsDefined(typeof(OrderStatus), model.StatusId))
            {
                var oldStatus = order.OrderStatus;
                order.OrderStatus = (OrderStatus) model.StatusId;
                await _orderRepository.SaveChangesAsync();

                var orderStatusChanged = new OrderChanged
                {
                    OrderId = order.Id,
                    OldStatus = oldStatus,
                    NewStatus = order.OrderStatus,
                    Order = order,
                    UserId = currentUser.Id,
                    Note = model.Note
                };

                await _mediator.Publish(orderStatusChanged);
                return Accepted();
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
