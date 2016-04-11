using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;

namespace Shopcuatoi.Core.ApplicationServices
{
    public class ManufacturerService : IManufacturerService
    {
        private const string ManufacturerEntityName = "Manufacturer";

        private readonly IRepository<Manufacturer> manufacturerRepository;
        private readonly IUrlSlugService urlSlugService;

        public ManufacturerService (IRepository<Manufacturer> manufacturerRepository, IUrlSlugService urlSlugService)
        {
            this.manufacturerRepository = manufacturerRepository;
            this.urlSlugService = urlSlugService;
        }

        public void Create(Manufacturer manufacturer)
        {
            manufacturerRepository.Add(manufacturer);
            manufacturerRepository.SaveChange();

            urlSlugService.Add(manufacturer.SeoTitle, manufacturer.Id, ManufacturerEntityName);
            manufacturerRepository.SaveChange();
        }

        public void Update(Manufacturer manufacturer)
        {
            urlSlugService.Update(manufacturer.SeoTitle, manufacturer.Id, ManufacturerEntityName);
            manufacturerRepository.SaveChange();
        }

        public void Delete(long id)
        {
            var manufacturer = manufacturerRepository.Get(id);
            Delete(manufacturer);
        }

        public void Delete (Manufacturer manufacturer)
        {
            manufacturer.IsDeleted = true;
            urlSlugService.Remove(manufacturer.Id, ManufacturerEntityName);
            manufacturerRepository.SaveChange();
        }
    }
}
