using SimplCommerce.Orders.ApplicationServices;
using SimplCommerce.Web.ViewModels.Cart;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Web.Components
{
    public class OrderSummaryViewComponent : ViewComponent
    {
        private readonly ICartService cartService;
        private readonly UserManager<User> userManager;

        public OrderSummaryViewComponent(ICartService cartService, UserManager<User> userManager)
        {
            this.cartService = cartService;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var userId = long.Parse(userManager.GetUserId(HttpContext.User));

            var cartItems = cartService.GetCartItems(userId, null);
            var model = new CartViewModel
            {
                CartItems = cartItems.Select(x => new CartListItem
                {
                    Id = x.Id,
                    ProductName = x.Product.Name,
                    ProductPrice = x.ProductPrice,
                    Quantity = x.Quantity,
                    VariationOptions = CartListItem.GetVariationOption(x.ProductVariation)
                }).ToList()
            };

            return View(model);
        }
    }
}