using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Core.ApplicationServices
{
    public interface ICategoryService
    {
        void Create(Category category);

        void Update(Category category);

        void Delete(Category category);
    }
}