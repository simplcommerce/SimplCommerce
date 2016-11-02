using System.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Catalog.Services
{
    public class BrandService : IBrandService
    {
        private const long BrandEntityTypeId = 2;

        private readonly IRepository<Brand> _brandRepository;
        private readonly IEntityService _entityService;

        public BrandService(IRepository<Brand> brandRepository, IEntityService entityService)
        {
            _brandRepository = brandRepository;
            _entityService = entityService;
        }

        public void Create(Brand brand)
        {
            using (var transaction = _brandRepository.BeginTransaction())
            {
                brand.SeoTitle = _entityService.ToSafeSlug(brand.SeoTitle, brand.Id, BrandEntityTypeId);
                _brandRepository.Add(brand);
                _brandRepository.SaveChange();

                _entityService.Add(brand.Name, brand.SeoTitle, brand.Id, BrandEntityTypeId);
                _brandRepository.SaveChange();

                transaction.Commit();
            }
        }

        public void Update(Brand brand)
        {
            brand.SeoTitle = _entityService.ToSafeSlug(brand.SeoTitle, brand.Id, BrandEntityTypeId);
            _entityService.Update(brand.Name, brand.SeoTitle, brand.Id, BrandEntityTypeId);
            _brandRepository.SaveChange();
        }

        public void Delete(long id)
        {
            var brand = _brandRepository.Query().First(x => x.Id == id);
            Delete(brand);
        }

        public void Delete(Brand brand)
        {
            brand.IsDeleted = true;
            _entityService.Remove(brand.Id, BrandEntityTypeId);
            _brandRepository.SaveChange();
        }
    }
}
