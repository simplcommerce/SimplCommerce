using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Services
{
    public interface IBrandService
    {
        void Create(Brand brand);

        void Update(Brand brand);

        void Delete(long id);

        void Delete(Brand brand);
    }
}
