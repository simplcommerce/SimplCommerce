using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Orders.Areas.Orders.ViewModels;
using SimplCommerce.Module.Orders.Events;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Areas.Orders.Controllers
{
    [Area("Orders")]
    [Authorize(Roles = "admin, vendor")]
    [Route("api/orders")]
    public class OrderApiController : Controller
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IWorkContext _workContext;
        private readonly IMediator _mediator;
        private readonly ICurrencyService _currencyService;

        public OrderApiController(IRepository<Order> orderRepository, IWorkContext workContext, IMediator mediator, ICurrencyService currencyService)
        {
            _orderRepository = orderRepository;
            _workContext = workContext;
            _mediator = mediator;
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<ActionResult> Get(int status, int numRecords)
        {
            var orderStatus = (OrderStatus)status;
            if ((numRecords <= 0) || (numRecords > 100))
            {
                numRecords = 5;
            }

            var query = _orderRepository.Query();
            if (orderStatus != 0)
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
                    CustomerName = x.Customer.FullName,
                    x.OrderTotal,
                    OrderTotalString = _currencyService.FormatCurrency(x.OrderTotal),
                    OrderStatus = x.OrderStatus.ToString(),
                    x.CreatedOn
                });

            return Json(model);
        }

        [HttpPost("grid")]
        public async Task<ActionResult> List([FromBody] SmartTableParam param)
        {
            var query = _orderRepository
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
                    var status = (OrderStatus)search.Status;
                    query = query.Where(x => x.OrderStatus == status);
                }

                if (search.CustomerName != null)
                {
                    string customerName = search.CustomerName;
                    query = query.Where(x => x.Customer.FullName.Contains(customerName));
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
                    CustomerName = order.Customer.FullName,
                    order.OrderTotal,
                    OrderTotalString = _currencyService.FormatCurrency(order.OrderTotal),
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
                .Include(x => x.Customer)
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

            var model = new OrderDetailVm(_currencyService)
            {
                Id = order.Id,
                IsMasterOrder = order.IsMasterOrder,
                CreatedOn = order.CreatedOn,
                OrderStatus = (int)order.OrderStatus,
                OrderStatusString = order.OrderStatus.ToString(),
                CustomerId = order.CustomerId,
                CustomerName = order.Customer.FullName,
                CustomerEmail = order.Customer.Email,
                ShippingMethod = order.ShippingMethod,
                PaymentMethod = order.PaymentMethod,
                PaymentFeeAmount = order.PaymentFeeAmount,
                Subtotal = order.SubTotal,
                DiscountAmount = order.DiscountAmount,
                SubTotalWithDiscount = order.SubTotalWithDiscount,
                TaxAmount = order.TaxAmount,
                ShippingAmount = order.ShippingFeeAmount,
                OrderTotal = order.OrderTotal,
                OrderNote = order.OrderNote,
                ShippingAddress = new ShippingAddressVm
                {
                    AddressLine1 = order.ShippingAddress.AddressLine1,
                    CityName = order.ShippingAddress.City,
                    ZipCode = order.ShippingAddress.ZipCode,
                    ContactName = order.ShippingAddress.ContactName,
                    DistrictName = order.ShippingAddress.District?.Name,
                    StateOrProvinceName = order.ShippingAddress.StateOrProvince.Name,
                    Phone = order.ShippingAddress.Phone
                },
                OrderItems = order.OrderItems.Select(x => new OrderItemVm(_currencyService)
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
                order.OrderStatus = (OrderStatus)model.StatusId;
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

            return BadRequest(new { Error = "unsupported order status" });
        }

        [HttpGet("order-status")]
        public IActionResult GetOrderStatus()
        {
            var model = EnumHelper.ToDictionary(typeof(OrderStatus)).Select(x => new { Id = x.Key, Name = x.Value });
            return Json(model);
        }

        [HttpPost("export")]
        public async Task<IActionResult> Export([FromBody] SmartTableParam param)
        {
            var query = _orderRepository.Query();

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
                    var status = (OrderStatus)search.Status;
                    query = query.Where(x => x.OrderStatus == status);
                }

                if (search.CustomerName != null)
                {
                    string customerName = search.CustomerName;
                    query = query.Where(x => x.Customer.FullName.Contains(customerName));
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

            var orders = await query
                .Select(x => new OrderExportVm(_currencyService)
                {
                    Id = x.Id,
                    OrderStatus = (int)x.OrderStatus,
                    IsMasterOrder = x.IsMasterOrder,
                    DiscountAmount = x.DiscountAmount,
                    CreatedOn = x.CreatedOn,
                    OrderStatusString = x.OrderStatus.GetDisplayName(),
                    PaymentFeeAmount = x.PaymentFeeAmount,
                    OrderTotal = x.OrderTotal,
                    Subtotal = x.SubTotal,
                    SubTotalWithDiscount = x.SubTotalWithDiscount,
                    PaymentMethod = x.PaymentMethod,
                    ShippingAmount = x.ShippingFeeAmount,
                    ShippingMethod = x.ShippingMethod,
                    TaxAmount = x.TaxAmount,
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer.FullName,
                    CustomerEmail = x.Customer.Email,
                    LatestUpdatedOn = x.LatestUpdatedOn,
                    Coupon = x.CouponCode,
                    Items = x.OrderItems.Count(),
                    BillingAddressId = x.BillingAddressId,
                    BillingAddressAddressLine1 = x.BillingAddress.AddressLine1,
                    BillingAddressAddressLine2 = x.BillingAddress.AddressLine2,
                    BillingAddressContactName = x.BillingAddress.ContactName,
                    BillingAddressCountryName = x.BillingAddress.Country.Name,
                    BillingAddressDistrictName = x.BillingAddress.District.Name,
                    BillingAddressZipCode = x.BillingAddress.ZipCode,
                    BillingAddressPhone = x.BillingAddress.Phone,
                    BillingAddressStateOrProvinceName = x.BillingAddress.StateOrProvince.Name,
                    ShippingAddressAddressLine1 = x.ShippingAddress.AddressLine1,
                    ShippingAddressAddressLine2 = x.ShippingAddress.AddressLine2,
                    ShippingAddressId = x.ShippingAddressId,
                    ShippingAddressContactName = x.ShippingAddress.ContactName,
                    ShippingAddressCountryName = x.ShippingAddress.Country.Name,
                    ShippingAddressDistrictName = x.ShippingAddress.District.Name,
                    ShippingAddressPhone = x.ShippingAddress.Phone,
                    ShippingAddressStateOrProvinceName = x.ShippingAddress.StateOrProvince.Name,
                    ShippingAddressZipCode = x.ShippingAddress.ZipCode
                })
                .ToListAsync();

            var csvString = CsvConverter.ExportCsv(orders);
            var csvBytes = Encoding.UTF8.GetBytes(csvString);
            // MS Excel need the BOM to display UTF8 Correctly
            var csvBytesWithUTF8BOM = Encoding.UTF8.GetPreamble().Concat(csvBytes).ToArray();
            return File(csvBytesWithUTF8BOM, "text/csv", "orders-export.csv");
        }

        [HttpPost("lines-export")]
        public async Task<IActionResult> OrderLinesExport([FromBody] SmartTableParam param, [FromServices] IRepository<OrderItem> orderItemRepository)
        {
            var query = orderItemRepository.Query();

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin"))
            {
                query = query.Where(x => x.Order.VendorId == currentUser.VendorId);
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
                    var status = (OrderStatus)search.Status;
                    query = query.Where(x => x.Order.OrderStatus == status);
                }

                if (search.CustomerName != null)
                {
                    string customerName = search.CustomerName;
                    query = query.Where(x => x.Order.Customer.FullName.Contains(customerName));
                }

                if (search.CreatedOn != null)
                {
                    if (search.CreatedOn.before != null)
                    {
                        DateTimeOffset before = search.CreatedOn.before;
                        query = query.Where(x => x.Order.CreatedOn <= before);
                    }

                    if (search.CreatedOn.after != null)
                    {
                        DateTimeOffset after = search.CreatedOn.after;
                        query = query.Where(x => x.Order.CreatedOn >= after);
                    }
                }
            }

            var orderItems = await query
                            .Select(x => new OrderLineExportVm(_currencyService)
                            {
                                Id = x.Id,
                                OrderStatus = (int)x.Order.OrderStatus,
                                IsMasterOrder = x.Order.IsMasterOrder,
                                DiscountAmount = x.Order.DiscountAmount,
                                CreatedOn = x.Order.CreatedOn,
                                OrderStatusString = x.Order.OrderStatus.ToString(),
                                PaymentFeeAmount = x.Order.PaymentFeeAmount,
                                OrderTotal = x.Order.OrderTotal,
                                Subtotal = x.Order.SubTotal,
                                SubTotalWithDiscount = x.Order.SubTotalWithDiscount,
                                PaymentMethod = x.Order.PaymentMethod,
                                ShippingAmount = x.Order.ShippingFeeAmount,
                                ShippingMethod = x.Order.ShippingMethod,
                                TaxAmount = x.Order.TaxAmount,
                                CustomerId = x.Order.CustomerId,
                                CustomerName = x.Order.Customer.FullName,
                                CustomerEmail = x.Order.Customer.Email,
                                LatestUpdatedOn = x.Order.LatestUpdatedOn,
                                Coupon = x.Order.CouponCode,
                                Items = x.Order.OrderItems.Count(),
                                BillingAddressId = x.Order.BillingAddressId,
                                BillingAddressAddressLine1 = x.Order.BillingAddress.AddressLine1,
                                BillingAddressAddressLine2 = x.Order.BillingAddress.AddressLine2,
                                BillingAddressContactName = x.Order.BillingAddress.ContactName,
                                BillingAddressCountryName = x.Order.BillingAddress.Country.Name,
                                BillingAddressDistrictName = x.Order.BillingAddress.District.Name,
                                BillingAddressZipCode = x.Order.BillingAddress.ZipCode,
                                BillingAddressPhone = x.Order.BillingAddress.Phone,
                                BillingAddressStateOrProvinceName = x.Order.BillingAddress.StateOrProvince.Name,
                                ShippingAddressAddressLine1 = x.Order.ShippingAddress.AddressLine1,
                                ShippingAddressAddressLine2 = x.Order.ShippingAddress.AddressLine2,
                                ShippingAddressId = x.Order.ShippingAddressId,
                                ShippingAddressContactName = x.Order.ShippingAddress.ContactName,
                                ShippingAddressCountryName = x.Order.ShippingAddress.Country.Name,
                                ShippingAddressDistrictName = x.Order.ShippingAddress.District.Name,
                                ShippingAddressPhone = x.Order.ShippingAddress.Phone,
                                ShippingAddressStateOrProvinceName = x.Order.ShippingAddress.StateOrProvince.Name,
                                ShippingAddressZipCode = x.Order.ShippingAddress.ZipCode,
                                OrderLineDiscountAmount = x.DiscountAmount,
                                OrderLineQuantity = x.Quantity,
                                OrderLineTaxAmount = x.TaxAmount,
                                OrderLineTaxPercent = x.TaxPercent,
                                OrderLineId = x.Id,
                                ProductId = x.ProductId,
                                ProductName = x.Product.Name,
                                ProductPrice = x.ProductPrice
                            })
                            .ToListAsync();

            var csvString = CsvConverter.ExportCsv(orderItems);
            var csvBytes = Encoding.UTF8.GetBytes(csvString);
            // MS Excel need the BOM to display UTF8 Correctly
            var csvBytesWithUTF8BOM = Encoding.UTF8.GetPreamble().Concat(csvBytes).ToArray();
            return File(csvBytesWithUTF8BOM, "text/csv", "order-lines-export.csv");
        }
    }
}
