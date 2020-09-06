using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
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
        private readonly ICurrencyService _currencyService;
        private readonly IStringLocalizer _localizer;

        public CartController(
            IRepository<CartItem> cartItemRepository,
            ICartService cartService,
            IMediaService mediaService,
            IWorkContext workContext,
            ICurrencyService currencyService,
            IStringLocalizerFactory stringLocalizerFactory)
        {
            _cartItemRepository = cartItemRepository;
            _cartService = cartService;
            _mediaService = mediaService;
            _workContext = workContext;
            _currencyService = currencyService;
            _localizer = stringLocalizerFactory.Create(null);
        }

        [HttpPost("cart/add-item")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartModel model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var result = await _cartService.AddToCart(currentUser.Id, model.ProductId, model.Quantity);
            if (result.Success)
            {
                return RedirectToAction("AddToCartResult", new { productId = model.ProductId });
            }
            else
            {
                return Ok(new { Error = true, Message = result.Error });
            }
        }

        [HttpGet("cart/add-item-result")]
        public async Task<IActionResult> AddToCartResult(long productId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(currentUser.Id);

            var model = new AddToCartResult(_currencyService)
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

        [HttpPost("cart/update-item-quantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] CartQuantityUpdate model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCart(currentUser.Id);

            if (cart == null)
            {
                return NotFound();
            }

            if (cart.LockedOnCheckout)
            {
                return CreateCartLockedResult();
            }

            var cartItem = _cartItemRepository.Query().Include(x => x.Product).FirstOrDefault(x => x.Id == model.CartItemId && x.Cart.CreatedById == currentUser.Id);
            if (cartItem == null)
            {
                return NotFound();
            }

            if(model.Quantity > cartItem.Quantity) // always allow user to descrease the quality
            {
                if (cartItem.Product.StockTrackingIsEnabled && cartItem.Product.StockQuantity < model.Quantity)
                {
                    return Ok(new { Error = true, Message = _localizer["There are only {0} items available for {1}.", cartItem.Product.StockQuantity, cartItem.Product.Name].Value });
                }
            }

            cartItem.Quantity = model.Quantity;
            _cartItemRepository.SaveChanges();

            return await List();
        }

        [HttpPost("cart/apply-coupon")]
        public async Task<IActionResult> ApplyCoupon([FromBody] ApplyCouponForm model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCart(currentUser.Id);
            if(cart == null)
            {
                return NotFound();
            }

            if (cart.LockedOnCheckout)
            {
                return CreateCartLockedResult();
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
            var cart = await _cartService.GetActiveCart(currentUser.Id);
            if(cart == null)
            {
                return NotFound();
            }

            cart.OrderNote = model.OrderNote;
            await _cartItemRepository.SaveChangesAsync();
            return Accepted();
        }

        [HttpPost("cart/remove-item")]
        public async Task<IActionResult> Remove([FromBody] long itemId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCart(currentUser.Id);
            if (cart == null)
            {
                return NotFound();
            }

            if (cart.LockedOnCheckout)
            {
                return CreateCartLockedResult();
            }

            var cartItem = _cartItemRepository.Query().FirstOrDefault(x => x.Id == itemId && x.Cart.CreatedById == currentUser.Id);
            if (cartItem == null)
            {
                return NotFound();
            }

            _cartItemRepository.Remove(cartItem);
            _cartItemRepository.SaveChanges();

            return await List();
        }

        [HttpPost("cart/unlock")]
        public async Task<IActionResult> Unlock()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCart(currentUser.Id);
            if (cart == null)
            {
                return NotFound();
            }

            await _cartService.UnlockCart(cart);
            return Accepted();
        }

        private IActionResult CreateCartLockedResult()
        {
            return Ok(new { Error = true, Message = _localizer["Cart is locked for checkout. Please complete or cancel the checkout first."].Value });
        }
    }
}
