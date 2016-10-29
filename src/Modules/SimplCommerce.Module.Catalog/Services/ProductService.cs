using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Catalog.Services
{
    public class ProductService : IProductService
    {
        private const long ProductEntityTypeId = 3;

        private readonly IRepository<Product> _productRepository;
        private readonly IEntityService _entityService;

        public ProductService(IRepository<Product> productRepository, IEntityService entityService)
        {
            _productRepository = productRepository;
            _entityService = entityService;
        }

        public void Create(Product product)
        {
            using (var transaction = _productRepository.BeginTransaction())
            {
                _productRepository.Add(product);
                _productRepository.SaveChange();

                _entityService.Add(product.SeoTitle, product.Id, ProductEntityTypeId);
                _productRepository.SaveChange();

                transaction.Commit();
            }
        }

        public void Update(Product product)
        {
            var slug = _entityService.Get(product.Id, ProductEntityTypeId);
            if (product.IsVisibleIndividually)
            {
                if (slug != null)
                {
                    _entityService.Update(product.SeoTitle, product.Id, ProductEntityTypeId);
                }
                else
                {
                    _entityService.Add(product.SeoTitle, product.Id, ProductEntityTypeId);
                }
            }
            else
            {
                if (slug != null)
                {
                    _entityService.Remove(product.Id, ProductEntityTypeId);
                }
            }
            _productRepository.SaveChange();
        }

        public void Delete(Product product)
        {
            product.IsDeleted = true;
            _entityService.Remove(product.Id, ProductEntityTypeId);
            _productRepository.SaveChange();
        }
    }
}
