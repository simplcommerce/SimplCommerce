using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Catalog.Services
{
    public class ProductService : IProductService
    {
        private const string ProductEntityName = "Product";

        private IRepository<Product> _productRepository;
        private IUrlSlugService _urlSlugService;

        public ProductService(IRepository<Product> productRepository, IUrlSlugService urlSlugService)
        {
            _productRepository = productRepository;
            _urlSlugService = urlSlugService;
        }

        public void Create(Product product)
        {
            using (var transaction = _productRepository.BeginTransaction())
            {
                _productRepository.Add(product);
                _productRepository.SaveChange();

                _urlSlugService.Add(product.SeoTitle, product.Id, ProductEntityName);
                _productRepository.SaveChange();

                transaction.Commit();
            }
        }

        public void Update(Product product)
        {
            var slug = _urlSlugService.Get(product.Id, ProductEntityName);
            if (product.IsVisibleIndividually)
            {
                if (slug != null)
                {
                    _urlSlugService.Update(product.SeoTitle, product.Id, ProductEntityName);
                }
                else
                {
                    _urlSlugService.Add(product.SeoTitle, product.Id, ProductEntityName);
                }
            }
            else
            {
                if (slug != null)
                {
                    _urlSlugService.Remove(product.Id, ProductEntityName);
                }
            }
            _productRepository.SaveChange();
        }

        public void Delete(Product product)
        {
            product.IsDeleted = true;
            _urlSlugService.Remove(product.Id, ProductEntityName);
            _productRepository.SaveChange();
        }
    }
}
