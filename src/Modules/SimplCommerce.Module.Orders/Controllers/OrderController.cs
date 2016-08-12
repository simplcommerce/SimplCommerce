using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Orders.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IRepository<Order> _orderRepository;
        private IWorkContext _workContext;
        private IMediaService _mediaService;

        public OrderController(IRepository<Order> orderRepository, IWorkContext workContext, IMediaService mediaService)
        {
            _orderRepository = orderRepository;
            _workContext = workContext;
            _mediaService = mediaService;
        }

        [HttpGet("user/order-history")]
        public async Task<IActionResult> OrderHistoryList()
        {
            var user = await _workContext.GetCurrentUser();
            var model = _orderRepository
                .Query()
                .Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.ThumbnailImage)
                .Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.OptionCombinations).ThenInclude(x => x.Option)
                .Select(x => new OrderHistoryListItem {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    SubTotal = x.SubTotal,
                    OrderStatus = x.OrderStatus,
                    OrderItems = x.OrderItems.Select(i => new OrderHistoryProductVm {
                        ProductId = i.ProductId,
                        ProductName = i.Product.Name,
                        Quantity = i.Quantity,
                        ThumbnailImage =i.Product.ThumbnailImage.FileName,
                        ProductOptions = i.Product.OptionCombinations.Select(o => o.Value)
                    }).ToList()
                })
                .OrderByDescending(x => x.CreatedOn).ToList();

            foreach(var item in model)
            {
                foreach(var product in item.OrderItems)
                {
                    product.ThumbnailImage = _mediaService.GetMediaUrl(product.ThumbnailImage);
                }
            }

            return View(model);
        }
    }
}
