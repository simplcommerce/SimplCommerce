using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using System;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductThumbnail
    {
        private readonly ICurrencyService _currencyService;

        public ProductThumbnail(ICurrencyService currencySerivce)
        {
            _currencyService = currencySerivce;
        }
        public long Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public decimal Price { get; set; }

        public string PriceString => _currencyService.FormatCurrency(Price);

        public decimal? OldPrice { get; set; }

        public string OldPriceString => _currencyService.FormatCurrency(OldPrice);

        public decimal? SpecialPrice { get; set; }

        public string SpecialPriceString => _currencyService.FormatCurrency(SpecialPrice);

        public bool IsCallForPricing { get; set; }

        public bool IsAllowToOrder { get; set; }

        public int? StockQuantity { get; set; }

        public DateTimeOffset? SpecialPriceStart { get; set; }

        public DateTimeOffset? SpecialPriceEnd { get; set; }

        public Media ThumbnailImage { get; set; }

        public string ThumbnailUrl { get; set; }

        public int ReviewsCount { get; set; }

        public double? RatingAverage { get; set; }

        public CalculatedProductPrice CalculatedProductPrice { get; set; }

        public static ProductThumbnail FromProduct(Product product, ICurrencyService currencyService)
        {
            var productThumbnail = new ProductThumbnail(currencyService)
            {
                Id = product.Id,
                Name = product.Name,
                Slug = product.Slug,
                Price = product.Price,
                OldPrice = product.OldPrice,
                SpecialPrice = product.SpecialPrice,
                SpecialPriceStart = product.SpecialPriceStart,
                SpecialPriceEnd = product.SpecialPriceEnd,
                StockQuantity = product.StockQuantity,
                IsAllowToOrder = product.IsAllowToOrder,
                IsCallForPricing = product.IsCallForPricing,
                ThumbnailImage = product.ThumbnailImage,
                ReviewsCount = product.ReviewsCount,
                RatingAverage = product.RatingAverage
            };

            return productThumbnail;
        }
    }
}
