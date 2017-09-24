using System.Threading.Tasks;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Vendors.Services
{
    public interface IVendorService
    {
        void Create(Vendor brand);

        void Update(Vendor brand);

        Task Delete(long id);

        Task Delete(Vendor brand);
    }
}
