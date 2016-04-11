using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Core.ApplicationServices
{
    public interface IManufacturerService
    {
        void Create(Manufacturer manufacturer);

        void Update(Manufacturer manufacturer);

        void Delete(long id);

        void Delete(Manufacturer manufacturer);
    }
}
