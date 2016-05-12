using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using SimplCommerce.Core.ApplicationServices;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Orders.ApplicationServices;
using SimplCommerce.Orders.Domain.Models;
using SimplCommerce.Web.ViewModels.Cart;

namespace SimplCommerce.Web.Controllers
{
    public class CartController : BaseController
    {
        private readonly IRepository<CartItem> cartItemRepository;
        private readonly ICartService cartService;
        private readonly IMediaService mediaService;

        public CartController(
            UserManager<User> userManager,
            IRepository<CartItem> cartItemRepository,
            ICartService cartService,
            IMediaService mediaService) : base(userManager)
        {
            this.cartItemRepository = cartItemRepository;
            this.cartService = cartService;
            this.mediaService = mediaService;
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] AddToCartModel model)
        {
            CartItem cartItem;
            if (HttpContext.User.IsSignedIn())
            {
                cartItem = cartService.AddToCart(CurrentUserId, null, model.ProductId, model.VariationName, model.Quantity);
            }
            else
            {
                cartItem = cartService.AddToCart(null, GetGuestId(), model.ProductId, model.VariationName, model.Quantity);
            }

            return RedirectToAction("AddToCartResult", new { cartItemId = cartItem.Id });
        }

        [HttpGet]
        public ActionResult AddToCartResult(long cartItemId)
        {
            var cartItem =
                cartItemRepository.Query()
                    .Include(x => x.Product)
                    .Include(x => x.ProductVariation)
                    .First(x => x.Id == cartItemId);

            var model = new AddToCartResult
            {
                ProductName = cartItem.Product.Name,
                ProductImage = mediaService.GetThumbnailUrl(cartItem.Product.ThumbnailImage),
                ProductPrice = cartItem.ProductPrice,
                Quantity = cartItem.Quantity
            };

            if (cartItem.ProductVariation != null)
            {
                model.VariationName = cartItem.ProductVariation.Name;
            }

            var cartItems = HttpContext.User.IsSignedIn()
                ? cartService.GetCartItems(CurrentUserId, null)
                : cartService.GetCartItems(null, GetGuestId());

            model.CartItemCount = cartItems.Count;
            model.CartAmount = cartItems.Sum(x => x.Quantity * x.ProductPrice);

            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            var cartItems = HttpContext.User.IsSignedIn()
                ? cartService.GetCartItems(CurrentUserId, null)
                : cartService.GetCartItems(null, GetGuestId());

            var model = new CartViewModel
            {
                CartItems = cartItems.Select(x => new CartListItem
                {
                    Id = x.Id,
                    ProductName = x.Product.Name,
                    ProductPrice = x.ProductPrice,
                    ProductImage = mediaService.GetThumbnailUrl(x.Product.ThumbnailImage),
                    Quantity = x.Quantity,
                    VariationOptions = CartListItem.GetVariationOption(x.ProductVariation)
                }).ToList()
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult UpdateQuantity([FromBody] CartQuantityUpdate model)
        {
            var cartItem = cartItemRepository.Get(model.CartItemId);
            cartItem.Quantity = model.Quantity;

            cartItemRepository.SaveChange();

            return List();
        }

        [HttpPost]
        public IActionResult Remove([FromBody] long itemId)
        {
            var cartItem = cartItemRepository.Get(itemId);
            if (cartItem == null)
            {
                return new HttpStatusCodeResult(400);
            }

            cartItemRepository.Remove(cartItem);
            cartItemRepository.SaveChange();

            return List();
        }
    }
}