using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Core.Infrastructure.EntityFramework;
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

        public async Task<bool> CheckExistBySeoTitle(string seoTitle)
        {
            using (this.productRepository = new Repository<Product>(new HvDbContext()))
            {
                return await productRepository.Query().AnyAsync(x => !x.IsDeleted && x.SeoTitle == seoTitle);
            }
        }
    }
}