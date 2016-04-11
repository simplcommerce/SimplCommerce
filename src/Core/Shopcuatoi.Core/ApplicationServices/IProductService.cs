using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Core.ApplicationServices
{
    public interface IProductService
    {
        void Create(Product product);

        void Update(Product product);

        void Delete(Product product);
    }
}