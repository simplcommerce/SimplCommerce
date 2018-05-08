using System.Linq;
using System.Threading.Tasks;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Vendors.Services
{
    public class VendorService : IVendorService
    {
        private const long VendorEntityTypeId = 2;

        private readonly IRepository<Vendor> _vendorRepository;
        private readonly IEntityService _entityService;

        public VendorService(IRepository<Vendor> vendorRepository, IEntityService entityService)
        {
            _vendorRepository = vendorRepository;
            _entityService = entityService;
        }

        public async Task Create(Vendor vendor)
        {
            using (var transaction = _vendorRepository.BeginTransaction())
            {
                vendor.Slug = _entityService.ToSafeSlug(vendor.Slug, vendor.Id, VendorEntityTypeId);
                _vendorRepository.Add(vendor);
                await _vendorRepository.SaveChangesAsync();

                _entityService.Add(vendor.Name, vendor.Slug, vendor.Id, VendorEntityTypeId);
                await _vendorRepository.SaveChangesAsync();

                transaction.Commit();
            }
        }

        public async Task Update(Vendor vendor)
        {
            vendor.Slug = _entityService.ToSafeSlug(vendor.Slug, vendor.Id, VendorEntityTypeId);
            _entityService.Update(vendor.Name, vendor.Slug, vendor.Id, VendorEntityTypeId);
            await _vendorRepository.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var vendor = _vendorRepository.Query().First(x => x.Id == id);
            await Delete(vendor);
        }

        public async Task Delete(Vendor vendor)
        {
            vendor.IsDeleted = true;
            await _entityService.Remove(vendor.Id, VendorEntityTypeId);
            _vendorRepository.SaveChanges();
        }
    }
}
