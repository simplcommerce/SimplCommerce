using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SimplCommerce.Orders.ApplicationServices;
using SimplCommerce.Web.Extensions;

namespace SimplCommerce.Web.Components
{
    public class CartBadgeViewComponent : ViewComponent
    {
        private ICartService _cartService;
        private IWorkContext _workContext;

        public CartBadgeViewComponent(ICartService cartService, IWorkContext workContext)
        {
            _cartService = cartService;
            _workContext = workContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cartItemCount = _cartService.GetCartItems(currentUser.Id).Count;
            return View(cartItemCount);
        }
    }
}