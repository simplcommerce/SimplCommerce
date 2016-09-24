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
        private readonly IUrlSlugService _urlSlugService;

        public BrandService(IRepository<Brand> brandRepository, IUrlSlugService urlSlugService)
        {
            _brandRepository = brandRepository;
            _urlSlugService = urlSlugService;
        }

        public void Create(Brand brand)
        {
            using (var transaction = _brandRepository.BeginTransaction())
            {
                _brandRepository.Add(brand);
                _brandRepository.SaveChange();

                _urlSlugService.Add(brand.SeoTitle, brand.Id, BrandEntityTypeId);
                _brandRepository.SaveChange();

                transaction.Commit();
            }
        }

        public void Update(Brand brand)
        {
            _urlSlugService.Update(brand.SeoTitle, brand.Id, BrandEntityTypeId);
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
            _urlSlugService.Remove(brand.Id, BrandEntityTypeId);
            _brandRepository.SaveChange();
        }
    }
}
