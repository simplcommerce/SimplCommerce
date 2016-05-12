using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Core.ApplicationServices
{
    public interface IProductService
    {
        void Create(Product product);

        void Update(Product product);

        void Delete(Product product);
    }
}