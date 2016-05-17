using SimplCommerce.Orders.ApplicationServices;
using SimplCommerce.Web.ViewModels.Cart;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SimplCommerce.Web.Components
{
    public class OrderSummaryViewComponent : ViewComponent
    {
        private readonly ICartService cartService;

        public OrderSummaryViewComponent(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = long.Parse(HttpContext.User.Identity.Name);

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