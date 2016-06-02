using System.Linq;
using SimplCommerce.Core.ApplicationServices;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Orders.ApplicationServices;
using SimplCommerce.Orders.Domain.Models;
using SimplCommerce.Web.ViewModels.Cart;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Web.Extensions;
using System.Threading.Tasks;

namespace SimplCommerce.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly ICartService _cartService;
        private readonly IMediaService _mediaService;
        private readonly IWorkContext _workContext;

        public CartController(
            UserManager<User> userManager,
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

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartModel model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            CartItem cartItem = _cartService.AddToCart(currentUser.Id, model.ProductId, model.VariationName, model.Quantity);

            return RedirectToAction("AddToCartResult", new { cartItemId = cartItem.Id });
        }

        [HttpGet]
        public async Task<IActionResult> AddToCartResult(long cartItemId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cartItem =
                _cartItemRepository.Query()
                    .Include(x => x.Product).ThenInclude(x => x.ThumbnailImage)
                    .Include(x => x.ProductVariation)
                    .First(x => x.Id == cartItemId);

            var model = new AddToCartResult
            {
                ProductName = cartItem.Product.Name,
                ProductImage = _mediaService.GetThumbnailUrl(cartItem.Product.ThumbnailImage),
                ProductPrice = cartItem.ProductPrice,
                Quantity = cartItem.Quantity
            };

            if (cartItem.ProductVariation != null)
            {
                model.VariationName = cartItem.ProductVariation.Name;
            }

            var cartItems = _cartService.GetCartItems(currentUser.Id);
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
        public async Task<IActionResult> List()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cartItems = _cartService.GetCartItems(currentUser.Id);

            var model = new CartViewModel
            {
                CartItems = cartItems.Select(x => new CartListItem
                {
                    Id = x.Id,
                    ProductName = x.Product.Name,
                    ProductPrice = x.ProductPrice,
                    ProductImage = _mediaService.GetThumbnailUrl(x.Product.ThumbnailImage),
                    Quantity = x.Quantity,
                    VariationOptions = CartListItem.GetVariationOption(x.ProductVariation)
                }).ToList()
            };

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity([FromBody] CartQuantityUpdate model)
        {
            var cartItem = _cartItemRepository.Query().FirstOrDefault(x => x.Id == model.CartItemId);
            cartItem.Quantity = model.Quantity;

            _cartItemRepository.SaveChange();

            return await List();
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromBody] long itemId)
        {
            var cartItem = _cartItemRepository.Query().FirstOrDefault(x => x.Id == itemId);
            if (cartItem == null)
            {
                return new NotFoundResult();
            }

            _cartItemRepository.Remove(cartItem);
            _cartItemRepository.SaveChange();

            return await List();
        }
    }
}