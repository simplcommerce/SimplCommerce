using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Core.ApplicationServices
{
    public interface ICategoryService
    {
        void Delete(long id);

        void Delete(Category category);
    }
}