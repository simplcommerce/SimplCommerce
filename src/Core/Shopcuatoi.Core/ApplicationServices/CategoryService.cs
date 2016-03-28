using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;

namespace Shopcuatoi.Core.ApplicationServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void Delete(long id)
        {
            var category = categoryRepository.Get(id);
            Delete(category);
        }

        public void Delete(Category category)
        {
            category.IsDeleted = true;

            foreach (var childCategory in category.Child)
            {
                Delete(childCategory);
            }
        }
    }
}