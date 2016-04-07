using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Core.ApplicationServices
{
    public interface IManufacturerService
    {
        void Delete(long id);

        void Delete(Manufacturer manufacturer);
    }
}
