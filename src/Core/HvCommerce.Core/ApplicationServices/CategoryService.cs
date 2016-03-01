using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.IRepositories;

namespace HvCommerce.Core.ApplicationServices
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