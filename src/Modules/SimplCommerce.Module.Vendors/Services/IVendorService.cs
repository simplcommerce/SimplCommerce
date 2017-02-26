using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Vendors.Services
{
    public interface IVendorService
    {
        void Create(Vendor brand);

        void Update(Vendor brand);

        void Delete(long id);

        void Delete(Vendor brand);
    }
}
