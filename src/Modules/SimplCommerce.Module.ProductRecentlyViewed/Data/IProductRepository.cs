using System.Linq;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.ProductRecentlyViewed.Data
{
    public interface IProductRepository
    {
        IQueryable<Product> GetRecentlyViewedProduct(long userId);
    }
}
