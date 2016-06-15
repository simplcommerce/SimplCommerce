using Microsoft.EntityFrameworkCore;
using SimplCommerce.Core.Domain.IRepositories;
using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Core.Infrastructure.EntityFramework
{
    // TODO This is just a temporary workaround because EF Core 1.0 hasn't support many-many without an entity class to represent the join table
    public class ProductTemplateProductAttributeRepository : IProductTemplateProductAttributeRepository 
    {
        private readonly DbContext dbContext; 

        public ProductTemplateProductAttributeRepository(SimplDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Remove(ProductTemplateProductAttribute item)
        {
            dbContext.Set<ProductTemplateProductAttribute>().Remove(item);
        }
    }
}
