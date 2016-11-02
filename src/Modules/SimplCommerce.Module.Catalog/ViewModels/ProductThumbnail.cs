using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class ProductThumbnail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string SeoTitle { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public Media ThumbnailImage { get; set; }

        public string ThumbnailUrl { get; set; }

        public int NumberVariation { get; set; }

        public int ReviewsCount { get; set; }

        public double? RatingAverage { get; set; }
    }
}
