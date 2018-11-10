using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;
using SimplCommerce.Module.ShoppingCart.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.Controllers
{
    [Area("ShoppingCart")]
    [Authorize(Roles = "admin")]
    public class CartApiController : Controller
    {
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly ICartService _cartService;
        private readonly IWorkContext _workContext;

        public CartApiController(
            IRepository<CartItem> cartItemRepository,
            ICartService cartService,
            IWorkContext workContext)
        {
            _cartItemRepository = cartItemRepository;
            _cartService = cartService;
            _workContext = workContext;
        }

        [HttpGet("api/customer/{customerId}/cart")]
        public async Task<IActionResult> List(long customerId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(currentUser.Id);

            return Json(cart);
        }

        [HttpPost("api/customer/{customerId}/add-cart-item")]
        public async Task<IActionResult> AddToCart(long customerId, [FromBody] AddToCartModel model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            await _cartService.AddToCart(customerId, currentUser.Id, model.ProductId, model.Quantity);

            return Accepted();
        }
    }
}
