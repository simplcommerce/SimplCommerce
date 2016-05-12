using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Core.ApplicationServices
{
    public interface IBrandService
    {
        void Create(Brand brand);

        void Update(Brand brand);

        void Delete(long id);

        void Delete(Brand brand);
    }
}
