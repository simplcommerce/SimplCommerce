using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.ShoppingCart.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Pricing.Services;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;

namespace SimplCommerce.Module.ShoppingCart.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IMediaService _mediaService;
        private readonly ICouponService _couponService;
        private readonly bool _isProductPriceIncludeTax;
        private readonly ICurrencyService _currencyService;

        public CartService(IRepository<Cart> cartRepository, IRepository<CartItem> cartItemRepository, ICouponService couponService,
            IMediaService mediaService, IConfiguration config, ICurrencyService currencyService)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _couponService = couponService;
            _mediaService = mediaService;
            _currencyService = currencyService;
            _isProductPriceIncludeTax = config.GetValue<bool>("Catalog.IsProductPriceIncludeTax");
        }

        public IQueryable<Cart> Query()
        {
            return _cartRepository.Query();
        }

        public Task<Cart> GetActiveCart(long customerId)
        {
            return GetActiveCart(customerId, customerId);
        }

        public async Task<Cart> GetActiveCart(long customerId, long createdById)
        {
            return await _cartRepository.Query()
                .Include(x => x.Items)
                .Where(x => x.CustomerId == customerId && x.CreatedById == createdById && x.IsActive).FirstOrDefaultAsync();
        }

        public async Task<Result> AddToCart(long customerId, long productId, int quantity)
        {
            return await AddToCart(customerId, customerId, productId, quantity);
        }

        public async Task<Result> AddToCart(long customerId, long createdById, long productId, int quantity)
        {
            var cart = await GetActiveCart(customerId, createdById);
            if (cart == null)
            {
                cart = new Cart
                {
                    CustomerId = customerId,
                    CreatedById = createdById,
                    IsProductPriceIncludeTax = _isProductPriceIncludeTax
                };

                _cartRepository.Add(cart);
            }
            else
            {
                if (cart.LockedOnCheckout)
                {
                    return Result.Fail("Cart is being locked for checkout. Please complete the checkout first");
                }

                cart = await _cartRepository.Query().Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == cart.Id);
            }

            var cartItem = cart.Items.FirstOrDefault(x => x.ProductId == productId);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Cart = cart,
                    ProductId = productId,
                    Quantity = quantity,
                    CreatedOn = DateTimeOffset.Now
                };

                cart.Items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity = cartItem.Quantity + quantity;
            }

            await  _cartRepository.SaveChangesAsync();

            return Result.Ok();
        }

        public async Task<CartVm> GetActiveCartDetails(long customerId)
        {
            return await GetActiveCartDetails(customerId, customerId);
        }

        // TODO separate getting product thumbnail, varation options from here
        public async Task<CartVm> GetActiveCartDetails(long customerId, long createdById)
        {
            var cart = await GetActiveCart(customerId, createdById);
            if (cart == null)
            {
                return null;
            }

            var cartVm = new CartVm(_currencyService)
            {
                Id = cart.Id,
                CouponCode = cart.CouponCode,
                IsProductPriceIncludeTax = cart.IsProductPriceIncludeTax,
                TaxAmount = cart.TaxAmount,
                ShippingAmount = cart.ShippingAmount,
                OrderNote = cart.OrderNote
            };

            cartVm.Items = _cartItemRepository
                .Query()
                .Include(x => x.Product).ThenInclude(p => p.ThumbnailImage)
                .Include(x => x.Product).ThenInclude(p => p.OptionCombinations).ThenInclude(o => o.Option)
                .Where(x => x.CartId == cart.Id)
                .Select(x => new CartItemVm(_currencyService)
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    ProductPrice = x.Product.Price,
                    ProductStockQuantity = x.Product.StockQuantity,
                    ProductStockTrackingIsEnabled = x.Product.StockTrackingIsEnabled,
                    IsProductAvailabeToOrder = x.Product.IsAllowToOrder && x.Product.IsPublished && !x.Product.IsDeleted,
                    ProductImage = _mediaService.GetThumbnailUrl(x.Product.ThumbnailImage),
                    Quantity = x.Quantity,
                    VariationOptions = CartItemVm.GetVariationOption(x.Product)
                }).ToList();

            cartVm.SubTotal = cartVm.Items.Sum(x => x.Quantity * x.ProductPrice);
            if (!string.IsNullOrWhiteSpace(cartVm.CouponCode))
            {
                var cartInfoForCoupon = new CartInfoForCoupon
                {
                    Items = cartVm.Items.Select(x => new CartItemForCoupon { ProductId = x.ProductId, Quantity = x.Quantity }).ToList()
                };
                var couponValidationResult = await _couponService.Validate(customerId, cartVm.CouponCode, cartInfoForCoupon);
                if (couponValidationResult.Succeeded)
                {
                    cartVm.Discount = couponValidationResult.DiscountAmount;
                }
                else
                {
                    cartVm.CouponValidationErrorMessage = couponValidationResult.ErrorMessage;
                }
            }

            return cartVm;
        }

        public async Task<CouponValidationResult> ApplyCoupon(long cartId, string couponCode)
        {
            var cart = _cartRepository.Query().Include(x => x.Items).FirstOrDefault(x => x.Id == cartId);

            var cartInfoForCoupon = new CartInfoForCoupon
            {
                Items = cart.Items.Select(x => new CartItemForCoupon { ProductId = x.ProductId, Quantity = x.Quantity }).ToList()
            };
            var couponValidationResult = await _couponService.Validate(cart.CustomerId, couponCode, cartInfoForCoupon);
            if (couponValidationResult.Succeeded)
            {
                cart.CouponCode = couponCode;
                cart.CouponRuleName = couponValidationResult.CouponRuleName;
                _cartItemRepository.SaveChanges();
            }

            return couponValidationResult;
        }

        public async Task MigrateCart(long fromUserId, long toUserId)
        {
            var cartFrom = await GetActiveCart(fromUserId);
            if (cartFrom != null && cartFrom.Items.Any())
            {
                var cartTo = await GetActiveCart(toUserId);
                if (cartTo == null)
                {
                    cartTo = new Cart
                    {
                        CustomerId = toUserId,
                        CreatedById = toUserId
                    };

                    _cartRepository.Add(cartTo);
                }

                foreach (var fromItem in cartFrom.Items)
                {
                    var toItem = cartTo.Items.FirstOrDefault(x => x.ProductId == fromItem.ProductId);
                    if (toItem == null)
                    {
                        toItem = new CartItem
                        {
                            Cart = cartTo,
                            ProductId = fromItem.ProductId,
                            Quantity = fromItem.Quantity,
                            CreatedOn = DateTimeOffset.Now
                        };
                        cartTo.Items.Add(toItem);
                    }
                    else
                    {
                        toItem.Quantity = toItem.Quantity + fromItem.Quantity;
                    }
                }

               await _cartRepository.SaveChangesAsync();
            }
        }
    }
}
