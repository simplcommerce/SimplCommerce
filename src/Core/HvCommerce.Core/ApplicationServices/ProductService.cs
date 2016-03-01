using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.IRepositories;

namespace HvCommerce.Core.ApplicationServices
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
    }
}