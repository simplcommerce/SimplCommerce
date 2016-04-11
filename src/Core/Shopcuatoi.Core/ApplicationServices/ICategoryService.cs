using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Core.ApplicationServices
{
    public interface ICategoryService
    {
        void Create(Category category);

        void Update(Category category);

        void Delete(long id);

        void Delete(Category category);
    }
}