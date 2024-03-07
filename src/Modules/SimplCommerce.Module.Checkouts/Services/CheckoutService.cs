using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels;
using SimplCommerce.Module.Checkouts.Models;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Pricing.Services;
using SimplCommerce.Module.ShippingPrices.Services;
using SimplCommerce.Module.Tax.Services;

namespace SimplCommerce.Module.Checkouts.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IRepositoryWithTypedId<Checkout, Guid> _checkoutRepository;
        private readonly IRepository<UserAddress> _userAddressRepository;
        private readonly IShippingPriceService _shippingPriceService;
        private readonly IRepository<CheckoutItem> _checkoutItemRepository;
        private readonly ITaxService _taxService;
        private readonly ICurrencyService _currencyService;
        private readonly IMediaService _mediaService;
        private readonly ICouponService _couponService;
        private readonly bool _isProductPriceIncludeTax;
        private readonly IProductPricingService _productPriceService;

        public CheckoutService(
            IRepositoryWithTypedId<Checkout, Guid> checkoutRepository,
            IRepository<UserAddress> userAddressRepository,
            IShippingPriceService shippingPriceService,
            IRepository<CheckoutItem> checkoutItemRepository,
            ITaxService taxService,
            ICurrencyService currencyService,
            IMediaService mediaService,
            ICouponService couponService,
            IConfiguration config,
            IProductPricingService productPriceService)
        {
            _checkoutRepository = checkoutRepository;
            _userAddressRepository = userAddressRepository;
            _shippingPriceService = shippingPriceService;
            _checkoutItemRepository = checkoutItemRepository;
            _taxService = taxService;
            _currencyService = currencyService;
            _mediaService = mediaService;
            _couponService = couponService;
            _isProductPriceIncludeTax = config.GetValue<bool>("Catalog.IsProductPriceIncludeTax");
            _productPriceService = productPriceService;
        }

        public async Task<Checkout> Create(long customerId, long createdById, IList<CartItemToCheckoutVm> cartItems, string couponCode)
        {
            var checkout = new Checkout
            {
                CustomerId = customerId,
                CreatedById = createdById,
                IsProductPriceIncludeTax = _isProductPriceIncludeTax,
                CouponCode = couponCode
            };
            
            foreach(var cartItem in cartItems)
            {
                var checkOutItem = new CheckoutItem
                {
                    Checkout = checkout,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    CreatedOn = DateTimeOffset.Now
                };

                checkout.CheckoutItems.Add(checkOutItem);
            }

            _checkoutRepository.Add(checkout);
            await _checkoutRepository.SaveChangesAsync();
            return checkout;
        }

        public async Task<CheckoutTaxAndShippingPriceVm> UpdateTaxAndShippingPrices(Guid checkoutId, TaxAndShippingPriceRequestVm model)
        {
            var checkout = await _checkoutRepository.Query().FirstOrDefaultAsync(x => x.Id == checkoutId);
            if (checkout == null)
            {
                throw new ApplicationException($"Checkout id {checkout} not found");
            }

            Address address;
            if (model.ExistingShippingAddressId != 0)
            {
                address = await _userAddressRepository.Query().Where(x => x.Id == model.ExistingShippingAddressId).Select(x => x.Address).FirstOrDefaultAsync();
                if (address == null)
                {
                    throw new ApplicationException($"Address id {model.ExistingShippingAddressId} not found");
                }
            }
            else
            {
                address = new Address
                {
                    CountryId = model.NewShippingAddress.CountryId,
                    StateOrProvinceId = model.NewShippingAddress.StateOrProvinceId,
                    DistrictId = model.NewShippingAddress.DistrictId,
                    ZipCode = model.NewShippingAddress.ZipCode,
                    AddressLine1 = model.NewShippingAddress.AddressLine1,
                };
            }

            var orderTaxAndShippingPrice = new CheckoutTaxAndShippingPriceVm
            {
                CheckoutVm = await GetCheckoutDetails(checkoutId)
            };

            checkout.TaxAmount = orderTaxAndShippingPrice.CheckoutVm.TaxAmount = await GetTax(checkoutId, address.CountryId, address.StateOrProvinceId, address.ZipCode);

            var request = new GetShippingPriceRequest
            {
                OrderAmount = orderTaxAndShippingPrice.CheckoutVm.OrderTotal,
                ShippingAddress = address
            };

            orderTaxAndShippingPrice.ShippingPrices = await _shippingPriceService.GetApplicableShippingPrices(request);
            var selectedShippingMethod = string.IsNullOrWhiteSpace(model.SelectedShippingMethodName)
                ? orderTaxAndShippingPrice.ShippingPrices.FirstOrDefault()
                : orderTaxAndShippingPrice.ShippingPrices.FirstOrDefault(x => x.Name == model.SelectedShippingMethodName);
            if (selectedShippingMethod != null)
            {
                checkout.ShippingAmount = orderTaxAndShippingPrice.CheckoutVm.ShippingAmount = selectedShippingMethod.Price;
                checkout.ShippingMethod = orderTaxAndShippingPrice.SelectedShippingMethodName = selectedShippingMethod.Name;
            }

            await _checkoutRepository.SaveChangesAsync();
            return orderTaxAndShippingPrice;
        }

        public async Task<decimal> GetTax(Guid checkoutId, string countryId, long stateOrProvinceId, string zipCode)
        {
            decimal taxAmount = 0;

            var checkoutItems = _checkoutItemRepository.Query()
                .Where(x => x.CheckoutId == checkoutId)
                .Select(x => new CheckoutItemWithTaxVm
                {
                    Quantity = x.Quantity,
                    Price = x.Product.Price,
                    TaxClassId = x.Product.TaxClass.Id
                }).ToList();

            foreach (var item in checkoutItems)
            {
                if (item.TaxClassId.HasValue)
                {
                    var taxRate = await _taxService.GetTaxPercent(item.TaxClassId, countryId, stateOrProvinceId, zipCode);
                    taxAmount = taxAmount + item.Quantity * item.Price * taxRate / 100;
                }
            }

            return taxAmount;
        }

        public async Task<CheckoutVm> GetCheckoutDetails(Guid checkoutId)
        {
            var checkout = await _checkoutRepository.Query().FirstOrDefaultAsync(x => x.Id == checkoutId);

            var checkoutVm = new CheckoutVm(_currencyService)
            {
                Id = checkout.Id,
                CouponCode = checkout.CouponCode,
                IsProductPriceIncludeTax = checkout.IsProductPriceIncludeTax,
                TaxAmount = checkout.TaxAmount,
                ShippingAmount = checkout.ShippingAmount,
                OrderNote = checkout.OrderNote
            };

            checkoutVm.Items = _checkoutItemRepository
                .Query()
                .Include(x => x.Product).ThenInclude(p => p.ThumbnailImage)
                .Include(x => x.Product).ThenInclude(p => p.OptionCombinations).ThenInclude(o => o.Option)
                .Where(x => x.CheckoutId == checkout.Id).ToList()
                .Select(x => new CheckoutItemVm(_currencyService)
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    CalculatedProductPrice = _productPriceService.CalculateProductPrice(x.Product),
                    ProductPrice = x.Product.Price,
                    ProductStockQuantity = x.Product.StockQuantity,
                    ProductStockTrackingIsEnabled = x.Product.StockTrackingIsEnabled,
                    IsProductAvailabeToOrder = x.Product.IsAllowToOrder && x.Product.IsPublished && !x.Product.IsDeleted,
                    ProductImage = _mediaService.GetThumbnailUrl(x.Product.ThumbnailImage),
                    Quantity = x.Quantity,
                    VariationOptions = CheckoutItemVm.GetVariationOption(x.Product)
                }).ToList();

            checkoutVm.SubTotal = checkoutVm.Items.Sum(x => x.Quantity * (x.CalculatedProductPrice.OldPrice ?? x.ProductPrice));
            if (!string.IsNullOrWhiteSpace(checkoutVm.CouponCode))
            {
                var cartInfoForCoupon = new CartInfoForCoupon
                {
                    Items = checkoutVm.Items.Select(x => new CartItemForCoupon { ProductId = x.ProductId, Quantity = x.Quantity }).ToList()
                };
                var couponValidationResult = await _couponService.Validate(checkout.CustomerId, checkout.CouponCode, cartInfoForCoupon);
                if (couponValidationResult.Succeeded)
                {
                    checkoutVm.Discount = couponValidationResult.DiscountAmount;
                }
                else
                {
                    checkoutVm.CouponValidationErrorMessage = couponValidationResult.ErrorMessage;
                }
            }

            checkoutVm.Discount += checkoutVm.Items
                .Where(x => x.CalculatedProductPrice.OldPrice.HasValue)
                .Sum(x => x.Quantity * (x.CalculatedProductPrice.OldPrice.Value - x.CalculatedProductPrice.Price)); 

            return checkoutVm;
        }
    }
}
