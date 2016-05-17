using System.Linq;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;

namespace SimplCommerce.Core.ApplicationServices
{
    public class BrandService : IBrandService
    {
        private const string BrandEntityName = "Brand";

        private readonly IRepository<Brand> brandRepository;
        private readonly IUrlSlugService urlSlugService;

        public BrandService (IRepository<Brand> brandRepository, IUrlSlugService urlSlugService)
        {
            this.brandRepository = brandRepository;
            this.urlSlugService = urlSlugService;
        }

        public void Create(Brand brand)
        {
            brandRepository.Add(brand);
            brandRepository.SaveChange();

            urlSlugService.Add(brand.SeoTitle, brand.Id, BrandEntityName);
            brandRepository.SaveChange();
        }

        public void Update(Brand brand)
        {
            urlSlugService.Update(brand.SeoTitle, brand.Id, BrandEntityName);
            brandRepository.SaveChange();
        }

        public void Delete(long id)
        {
            var brand = brandRepository.Query().First(x => x.Id == id);
            Delete(brand);
        }

        public void Delete (Brand brand)
        {
            brand.IsDeleted = true;
            urlSlugService.Remove(brand.Id, BrandEntityName);
            brandRepository.SaveChange();
        }
    }
}
