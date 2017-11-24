using System;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Models;
using System.Linq;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class ProductThumbnail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string SeoTitle { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? SpecialPrice { get; set; }

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

        public string Departure { get; set; }

        public string Landing { get; set; }

        public string DepartureDate { get; set; }

        public string LandingDate { get; set; }

        public static ProductThumbnail FromProduct(Product product)
        {
            var productThumbnail = new ProductThumbnail
            {
                Id = product.Id,
                Name = product.Name,
                SeoTitle = product.SeoTitle,
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
                RatingAverage = product.RatingAverage,
                Departure = product.AttributeValues.FirstOrDefault(a => a.Attribute.Name == "Departure")?.Value,
                Landing = product.AttributeValues.FirstOrDefault(a => a.Attribute.Name == "Landing")?.Value,
                DepartureDate = product.AttributeValues.FirstOrDefault(a => a.Attribute.Name == "DepartureDate")?.Value,
                LandingDate = product.AttributeValues.FirstOrDefault(a => a.Attribute.Name == "LandingDate")?.Value

            };

            return productThumbnail;
        }
    }
}
