using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Web.ViewModels.Catalog
{
    public class ProductListItem
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string SeoTitle { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public Media ThumbnailImage { get; set; }

        public string ThumbnailUrl { get; set; }

        public int NumberVariation { get; set; }
    }
}