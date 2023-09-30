using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Orders.Areas.Orders.ViewModels;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Areas.Orders.Controllers
{
    [Area("Orders")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IMediaService _mediaService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IWorkContext _workContext;
        private readonly ICurrencyService _currencyService;

        public OrderController(IRepository<Order> orderRepository, IWorkContext workContext, IMediaService mediaService, ICurrencyService currencyService)
        {
            _orderRepository = orderRepository;
            _workContext = workContext;
            _mediaService = mediaService;
            _currencyService = currencyService;
        }

        [HttpGet("user/orders")]
        public async Task<IActionResult> OrderHistoryList()
        {
            var user = await _workContext.GetCurrentUser();
            var model = await _orderRepository
                .Query()
                .Where(x => x.CustomerId == user.Id && x.ParentId == null)
                .Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.ThumbnailImage)
                .Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.OptionCombinations).ThenInclude(x => x.Option)
                .OrderByDescending(x => x.CreatedOn).ToListAsync();

             var model2 = model.Select(x => new OrderHistoryListItem(_currencyService)
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    SubTotal = x.SubTotal,
                    OrderStatus = x.OrderStatus,
                    OrderItems = x.OrderItems.Select(i => new OrderHistoryProductVm
                    {
                        ProductId = i.ProductId,
                        ProductName = i.Product.Name,
                        Quantity = i.Quantity,
                        ThumbnailImage = i.Product.ThumbnailImage.FileName,
                        ProductOptions = i.Product.OptionCombinations.Select(o => o.Value)
                    }).ToList()
                }).ToList();

            foreach (var item in model2)
            {
                foreach (var product in item.OrderItems)
                {
                    product.ThumbnailImage = _mediaService.GetMediaUrl(product.ThumbnailImage);
                }
            }

            return View(model2);
        }

        [HttpGet("user/orders/{orderId}")]
        public async Task<IActionResult> OrderDetails(long orderId)
        {
            var user = await _workContext.GetCurrentUser();

            var order = _orderRepository
                .Query()
                .Include(x => x.ShippingAddress).ThenInclude(x => x.District)
                .Include(x => x.ShippingAddress).ThenInclude(x => x.StateOrProvince)
                .Include(x => x.ShippingAddress).ThenInclude(x => x.Country)
                .Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.ThumbnailImage)
                .Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.OptionCombinations).ThenInclude(x => x.Option)
                .Include(x => x.Customer)
                .FirstOrDefault(x => x.Id == orderId);

            if (order == null)
            {
                return NotFound();
            }

            if (order.CustomerId != user.Id)
            {
                return BadRequest(new { error = "You don't have permission to view this order" });
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
                    ProductImage = x.Product.ThumbnailImage.FileName,
                    TaxAmount = x.TaxAmount,
                    TaxPercent = x.TaxPercent,
                    VariationOptions = OrderItemVm.GetVariationOption(x.Product)
                }).ToList()
            };

            foreach (var item in model.OrderItems)
            {
                item.ProductImage = _mediaService.GetMediaUrl(item.ProductImage);
            }

            return View(model);
        }
    }
}
