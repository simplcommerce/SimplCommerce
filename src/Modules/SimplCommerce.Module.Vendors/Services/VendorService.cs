using System.Linq;
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

        public void Create(Vendor vendor)
        {
            using (var transaction = _vendorRepository.BeginTransaction())
            {
                vendor.SeoTitle = _entityService.ToSafeSlug(vendor.SeoTitle, vendor.Id, VendorEntityTypeId);
                _vendorRepository.Add(vendor);
                _vendorRepository.SaveChange();

                _entityService.Add(vendor.Name, vendor.SeoTitle, vendor.Id, VendorEntityTypeId);
                _vendorRepository.SaveChange();

                transaction.Commit();
            }
        }

        public void Update(Vendor vendor)
        {
            vendor.SeoTitle = _entityService.ToSafeSlug(vendor.SeoTitle, vendor.Id, VendorEntityTypeId);
            _entityService.Update(vendor.Name, vendor.SeoTitle, vendor.Id, VendorEntityTypeId);
            _vendorRepository.SaveChange();
        }

        public void Delete(long id)
        {
            var vendor = _vendorRepository.Query().First(x => x.Id == id);
            Delete(vendor);
        }

        public void Delete(Vendor vendor)
        {
            vendor.IsDeleted = true;
            _entityService.Remove(vendor.Id, VendorEntityTypeId);
            _vendorRepository.SaveChange();
        }
    }
}
