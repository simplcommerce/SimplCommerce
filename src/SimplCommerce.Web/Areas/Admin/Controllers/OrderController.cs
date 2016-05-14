using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SimplCommerce.Core.ApplicationServices;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Orders.Domain.Models;
using SimplCommerce.Web.Areas.Admin.ViewModels.Orders;
using SimplCommerce.Web.Areas.Admin.ViewModels.SmartTable;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IMediaService mediaService;

        public OrderController(IRepository<Order> orderRepository, IMediaService mediaService)
        {
            this.orderRepository = orderRepository;
            this.mediaService = mediaService;
        }

        [HttpPost]
        public ActionResult List([FromBody] SmartTableParam param)
        {
            var query = orderRepository.Query();

            var orders = query.ToSmartTableResult(
                param,
                order => new OrderListItem
                {
                    Id = order.Id,
                    CustomerName = order.CreatedBy.FullName,
                    SubTotal = order.SubTotal,
                    CreatedOn = order.CreatedOn
                });

            return Json(orders);
        }

        public IActionResult Detail(long id)
        {
            var order = orderRepository
                .Query()
                .Include(x => x.ShippingAddress)
                .Include(x => x.OrderItems)
                .Include(x => x.CreatedBy)
                .FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return new HttpStatusCodeResult(400);
            }

            var model = new OrderDetailViewModel
            {
                Id = order.Id,
                CreatedOn = order.CreatedOn,
                CustomerName = order.CreatedBy.FullName,
                SubTotal = order.SubTotal,
                ShippingAddress = new ShippingAddressViewModel
                {
                    AddressLine1 = order.ShippingAddress.Address.AddressLine1,
                    AddressLine2 = order.ShippingAddress.Address.AddressLine2,
                    ContactName = order.ShippingAddress.Address.ContactName,
                    DistrictName = order.ShippingAddress.Address.District.Name,
                    StateOrProvinceName = order.ShippingAddress.Address.StateOrProvince.Name,
                    Phone = order.ShippingAddress.Address.Phone
                },

                OrderItems = order.OrderItems.Select(x => new OrderItemViewModel
                {
                    Id = x.Id,
                    ProductName = x.Product.Name,
                    ProductPrice = x.ProductPrice,
                    ProductImage = mediaService.GetThumbnailUrl(x.Product.ThumbnailImage),
                    Quantity = x.Quantity,
                    VariationOptions = OrderItemViewModel.GetVariationOption(x.ProductVariation)
                }).ToList()
            };

            return Json(model);
        }
    }
}