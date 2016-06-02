using SimplCommerce.Orders.ApplicationServices;
using SimplCommerce.Web.ViewModels.Cart;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Web.Extensions;
using System.Threading.Tasks;

namespace SimplCommerce.Web.Components
{
    public class OrderSummaryViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly IWorkContext _workContext;

        public OrderSummaryViewComponent(ICartService cartService, IWorkContext workContext)
        {
            _cartService = cartService;
            _workContext = workContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var curentUser = await _workContext.GetCurrentUser();

            var cartItems = _cartService.GetCartItems(curentUser.Id);
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