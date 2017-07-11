using System.Linq;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.ActivityLog.Models;

namespace SimplCommerce.Module.ProductRecentlyViewed.Data
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private const long EntityViewedActivityTypeId = 1;
        private const long ProductEntityTypeId = 3;

        public ProductRepository(SimplDbContext context) : base(context)
        {
        }

        public IQueryable<Product> GetRecentlyViewedProduct(long userId)
        {
            return from product in DbSet
                   join e in Context.Set<Activity>() on  product.Id equals e.EntityId
                   where e.ActivityTypeId == EntityViewedActivityTypeId 
                        && e.EntityTypeId == ProductEntityTypeId
                        && e.UserId == userId
                   orderby e.CreatedOn descending
                   select product;
        }
    }
}
