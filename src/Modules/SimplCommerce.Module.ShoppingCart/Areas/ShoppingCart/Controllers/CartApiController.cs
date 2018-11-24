using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("api/customers/{customerId}/cart")]
        public async Task<IActionResult> List(long customerId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(customerId, currentUser.Id);

            return Json(cart);
        }

        [HttpPost("api/customers/{customerId}/add-cart-item")]
        public async Task<IActionResult> AddToCart(long customerId, [FromBody] AddToCartModel model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            await _cartService.AddToCart(customerId, currentUser.Id, model.ProductId, model.Quantity);

            return Accepted();
        }

        [HttpPut("api/carts/items/{itemId}")]
        public async Task<IActionResult> UpdateQuantity(long itemId, [FromBody] CartQuantityUpdate model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cartItem = _cartItemRepository.Query().FirstOrDefault(x => x.Id == itemId && x.Cart.CreatedById == currentUser.Id);
            if (cartItem == null)
            {
                return NotFound();
            }

            cartItem.Quantity = model.Quantity;
            _cartItemRepository.SaveChanges();

            return Accepted();
        }

        [HttpPost("api/carts/{cartId}/apply-coupon")]
        public async Task<ActionResult> ApplyCoupon(long cartId, [FromBody] ApplyCouponForm model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.Query().FirstOrDefaultAsync(x => x.Id == cartId && x.CreatedById == currentUser.Id);
            if (cart == null)
            {
                return NotFound();
            }

            var validationResult = await _cartService.ApplyCoupon(cart.Id, model.CouponCode);
            if (validationResult.Succeeded)
            {
                var cartVm = await _cartService.GetActiveCartDetails(currentUser.Id);
                return Json(cartVm);
            }

            return Json(validationResult);
        }

        [HttpPost("api/carts/{cartId}/save-ordernote")]
        public async Task<IActionResult> SaveOrderNote(long cartId, [FromBody] SaveOrderNote model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.Query().FirstOrDefaultAsync(x => x.Id == cartId && x.CreatedById == currentUser.Id);
            if (cart == null)
            {
                return NotFound();
            }

            cart.OrderNote = model.OrderNote;
            await _cartItemRepository.SaveChangesAsync();
            return Accepted();
        }

        [HttpDelete("api/carts/items/{itemId}")]
        public async Task<IActionResult> Remove(long itemId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cartItem = _cartItemRepository.Query().FirstOrDefault(x => x.Id == itemId && x.Cart.CreatedById == currentUser.Id);
            if (cartItem == null)
            {
                return NotFound();
            }

            _cartItemRepository.Remove(cartItem);
            _cartItemRepository.SaveChanges();

            return NoContent();
        }
    }
}
