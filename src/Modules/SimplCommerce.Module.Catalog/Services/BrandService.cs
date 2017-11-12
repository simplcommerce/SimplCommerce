using System.Linq;
using System.Threading.Tasks;
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
                _brandRepository.SaveChanges();

                _entityService.Add(brand.Name, brand.SeoTitle, brand.Id, BrandEntityTypeId);
                _brandRepository.SaveChanges();

                transaction.Commit();
            }
        }

        public void Update(Brand brand)
        {
            brand.SeoTitle = _entityService.ToSafeSlug(brand.SeoTitle, brand.Id, BrandEntityTypeId);
            _entityService.Update(brand.Name, brand.SeoTitle, brand.Id, BrandEntityTypeId);
            _brandRepository.SaveChanges();
        }

        public async Task Delete(long id)
        {
            var brand = _brandRepository.Query().First(x => x.Id == id);
            await Delete(brand);
        }

        public async Task Delete(Brand brand)
        {
            brand.IsDeleted = true;
            await _entityService.Remove(brand.Id, BrandEntityTypeId);
            _brandRepository.SaveChanges();
        }
    }
}
