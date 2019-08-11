using System;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Tax.Services;

namespace SimplCommerce.Module.Catalog.Services
{
    public class ProductPricingService : IProductPricingService
    {
        private ICurrencyService _currencyService;
        private readonly ITaxService _taxService;
        private readonly IWorkContext _workContext;
        private readonly bool _isProductPriceIncludeTax;
        private readonly string _defaultTaxCountryCode;

        public ProductPricingService(ICurrencyService currencyService,
            ITaxService taxService,
            IWorkContext workContext,
            IConfiguration configuration)
        {
            _currencyService = currencyService;
            _taxService = taxService;
            _workContext = workContext;
            _isProductPriceIncludeTax = configuration.GetValue<bool>("Catalog.IsProductPriceIncludeTax");
            _defaultTaxCountryCode = configuration.GetValue<string>("Catalog.DefaultTaxCountryCode");
        }

        public CalculatedProductPrice CalculateProductPrice(ProductThumbnail productThumbnail)
        {
            return CalculateProductPrice(productThumbnail.Price, productThumbnail.OldPrice, productThumbnail.SpecialPrice, productThumbnail.SpecialPriceStart, productThumbnail.SpecialPriceEnd, productThumbnail.TaxClassId);
        }

        public CalculatedProductPrice CalculateProductPrice(Product product)
        {
            return CalculateProductPrice(product.Price, product.OldPrice, product.SpecialPrice, product.SpecialPriceStart, product.SpecialPriceEnd, product.TaxClassId);
        }

        public CalculatedProductPrice CalculateProductPrice(decimal price, decimal? oldPrice, decimal? specialPrice, DateTimeOffset? specialPriceStart, DateTimeOffset? specialPriceEnd, long? taxClassId)
        {
            var percentOfSaving = 0;
            var calculatedPrice = price;

            if (specialPrice.HasValue && specialPriceStart < DateTimeOffset.Now && DateTimeOffset.Now < specialPriceEnd)
            {
                calculatedPrice = specialPrice.Value;

                if (!oldPrice.HasValue || oldPrice < price)
                {
                    oldPrice = price;
                }
            }

            if (oldPrice.HasValue && oldPrice.Value > 0 && oldPrice > calculatedPrice)
            {
                percentOfSaving = (int)(100 - Math.Ceiling((calculatedPrice / oldPrice.Value) * 100));
            }

            if (!_isProductPriceIncludeTax)
            {
                string defaultTaxCountryId = _workContext.GetCurrentUser().Result.DefaultBillingAddress?.Address?.CountryId ?? _defaultTaxCountryCode;
                decimal taxRate = _taxService.GetTaxPercent(taxClassId, defaultTaxCountryId, default, default).Result;

                return new CalculatedProductPrice(_currencyService)
                {
                    PriceExcludingTax = calculatedPrice,
                    TaxAmount = CalculateProductTaxAmount(calculatedPrice, taxRate),
                    OldPriceExcludingTax = oldPrice,
                    OldTaxAmount = CalculateProductTaxAmount(oldPrice, taxRate),
                    PercentOfSaving = percentOfSaving
                };
            }

            return new CalculatedProductPrice(_currencyService)
            {
                PriceExcludingTax = calculatedPrice,
                TaxAmount = 0,
                OldPriceExcludingTax = oldPrice,
                OldTaxAmount = 0,
                PercentOfSaving = percentOfSaving
            };
        }

        private static decimal? CalculateProductTaxAmount(decimal? price, decimal taxRate)
        {
            if (price.HasValue)
            {
                return CalculateProductTaxAmount(price.Value, taxRate);
            }

            return null;
        }

        private static decimal CalculateProductTaxAmount(decimal price, decimal taxRate)
        {
            if (taxRate == 0)
            {
                return price;
            }

            return price * taxRate / 100;
        }
    }
}
