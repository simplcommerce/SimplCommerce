using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;

namespace Shopcuatoi.Core.ApplicationServices
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IRepository<Manufacturer> manufacturerRepositiory;

        public ManufacturerService (IRepository<Manufacturer> manufacturerRepositiory)
        {
            this.manufacturerRepositiory = manufacturerRepositiory;
        }

        public void Delete(long id)
        {
            var manufacturer = manufacturerRepositiory.Get(id);
            Delete(manufacturer);
        }

        public void Delete (Manufacturer manufacturer)
        {
            manufacturer.IsDeleted = true;
        }
    }
}
