using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;
using SimplCommerce.Module.ShoppingCart.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.Controllers
{
    [Area("ShoppingCart")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CartController : Controller
    {
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly ICartService _cartService;
        private readonly IMediaService _mediaService;
        private readonly IWorkContext _workContext;

        public CartController(
            IRepository<CartItem> cartItemRepository,
            ICartService cartService,
            IMediaService mediaService,
            IWorkContext workContext)
        {
            _cartItemRepository = cartItemRepository;
            _cartService = cartService;
            _mediaService = mediaService;
            _workContext = workContext;
        }

        [HttpPost("cart/addtocart")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartModel model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            await _cartService.AddToCart(currentUser.Id, model.ProductId, model.Quantity);

            return RedirectToAction("AddToCartResult", new { productId = model.ProductId });
        }

        [HttpGet]
        public async Task<IActionResult> AddToCartResult(long productId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(currentUser.Id);

            var model = new AddToCartResult
            {
                CartItemCount = cart.Items.Count,
                CartAmount = cart.SubTotal
            };

            var addedProduct = cart.Items.First(x => x.ProductId == productId);
            model.ProductName = addedProduct.ProductName;
            model.ProductImage = addedProduct.ProductImage;
            model.ProductPrice = addedProduct.ProductPrice;
            model.Quantity = addedProduct.Quantity;

            return PartialView(model);
        }

        [HttpGet("cart")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("cart/list")]
        public async Task<IActionResult> List()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(currentUser.Id);

            return Json(cart);
        }

        [HttpPost("cart/update-quantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] CartQuantityUpdate model)
        {
            var cartItem = _cartItemRepository.Query().FirstOrDefault(x => x.Id == model.CartItemId);
            if (cartItem == null)
            {
                return NotFound();
            }

            cartItem.Quantity = model.Quantity;
            _cartItemRepository.SaveChanges();

            return await List();
        }

        [HttpPost("cart/apply-coupon")]
        public async Task<ActionResult> ApplyCoupon([FromBody] ApplyCouponForm model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = _cartService.GetActiveCart(currentUser.Id).FirstOrDefault();
            if(cart == null)
            {
                return NotFound();
            }

            var validationResult =  await _cartService.ApplyCoupon(cart.Id, model.CouponCode);
            if (validationResult.Succeeded)
            {
                var cartVm = await _cartService.GetActiveCartDetails(currentUser.Id);
                return Json(cartVm);
            }

            return Json(validationResult);
        }

        [HttpPost("cart/save-ordernote")]
        public async Task<IActionResult> SaveOrderNote([FromBody] SaveOrderNote model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = _cartService.GetActiveCart(currentUser.Id).FirstOrDefault();
            if(cart == null)
            {
                return NotFound();
            }

            cart.OrderNote = model.OrderNote;
            await _cartItemRepository.SaveChangesAsync();
            return Accepted();
        }

        [HttpPost("cart/remove")]
        public async Task<IActionResult> Remove([FromBody] long itemId)
        {
            var cartItem = _cartItemRepository.Query().FirstOrDefault(x => x.Id == itemId);
            if (cartItem == null)
            {
                return NotFound();
            }

            _cartItemRepository.Remove(cartItem);
            _cartItemRepository.SaveChanges();

            return await List();
        }
    }
}
