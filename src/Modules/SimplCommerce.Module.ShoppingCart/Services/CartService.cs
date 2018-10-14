using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public CartService(IRepository<Cart> cartRepository, IRepository<CartItem> cartItemRepository, ICouponService couponService, IMediaService mediaService, IConfiguration config)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _couponService = couponService;
            _mediaService = mediaService;
            _isProductPriceIncludeTax = config.GetValue<bool>("Catalog.IsProductPriceIncludeTax");
        }

        public async Task AddToCart(long userId, long productId, int quantity)
        {
            var cart = _cartRepository.Query().Include(x => x.Items).FirstOrDefault(x => x.UserId == userId && x.IsActive);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    IsProductPriceIncludeTax = _isProductPriceIncludeTax
                };

                _cartRepository.Add(cart);
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
                cartItem.Quantity = quantity;
            }

           await  _cartRepository.SaveChangesAsync();
        }

        // TODO separate getting product thumbnail, varation options from here
        public async Task<CartVm> GetCart(long userId)
        {
            var cart = _cartRepository.Query().FirstOrDefault(x => x.UserId == userId && x.IsActive);
            if (cart == null)
            {
                return new CartVm();
            }

            var cartVm = new CartVm()
            {
                Id = cart.Id,
                CouponCode = cart.CouponCode,
                IsProductPriceIncludeTax = cart.IsProductPriceIncludeTax,
                TaxAmount = cart.TaxAmount,
                ShippingAmount = cart.ShippingAmount
            };

            cartVm.Items = _cartItemRepository
                .Query()
                .Include(x => x.Product).ThenInclude(p => p.ThumbnailImage)
                .Include(x => x.Product).ThenInclude(p => p.OptionCombinations).ThenInclude(o => o.Option)
                .Where(x => x.CartId == cart.Id)
                .Select(x => new CartItemVm
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    ProductPrice = x.Product.Price,
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
                var couponValidationResult = await _couponService.Validate(cartVm.CouponCode, cartInfoForCoupon);
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

        public async Task<CouponValidationResult> ApplyCoupon(long userId, string couponCode)
        {
            var cart = _cartRepository.Query().Include(x => x.Items).FirstOrDefault(x => x.UserId == userId && x.IsActive);

            var cartInfoForCoupon = new CartInfoForCoupon
            {
                Items = cart.Items.Select(x => new CartItemForCoupon { ProductId = x.ProductId, Quantity = x.Quantity }).ToList()
            };
            var couponValidationResult = await _couponService.Validate(couponCode, cartInfoForCoupon);
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
            var cartFrom = _cartRepository.Query().Include(x => x.Items).FirstOrDefault(x => x.UserId == fromUserId && x.IsActive);
            if (cartFrom != null && cartFrom.Items.Any())
            {
                var cartTo = _cartRepository.Query().Include(x => x.Items).FirstOrDefault(x => x.UserId == toUserId && x.IsActive);
                if (cartTo == null)
                {
                    cartTo = new Cart
                    {
                        UserId = toUserId
                    };

                    _cartRepository.Add(cartTo);
                }

                foreach (var fromItem in cartFrom.Items)
                {
                    var toItem = cartTo.Items.FirstOrDefault(x => x.ProductId == fromItem.ProductId);
                    if(toItem == null)
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
