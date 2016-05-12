using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;

namespace SimplCommerce.Core.ApplicationServices
{
    public class CategoryService : ICategoryService
    {
        private const string CategoryEntityName = "Category";

        private readonly IRepository<Category> categoryRepository;
        private readonly IUrlSlugService urlSlugService;

        public CategoryService(IRepository<Category> categoryRepository, IUrlSlugService urlSlugService)
        {
            this.categoryRepository = categoryRepository;
            this.urlSlugService = urlSlugService;
        }

        public void Create(Category category)
        {
            categoryRepository.Add(category);
            categoryRepository.SaveChange();

            urlSlugService.Add(category.SeoTitle, category.Id, CategoryEntityName);
            categoryRepository.SaveChange();
        }

        public void Update(Category category)
        {
            urlSlugService.Update(category.SeoTitle, category.Id, CategoryEntityName);
            categoryRepository.SaveChange();
        }

        public void Delete(long id)
        {
            var category = categoryRepository.Get(id);
            DeleteSimple(category);
            categoryRepository.SaveChange();
        }

        public void Delete(Category category)
        {
            DeleteSimple(category);
            categoryRepository.SaveChange();
        }

        private void DeleteSimple(Category category)
        {
            category.IsDeleted = true;
            urlSlugService.Remove(category.Id, CategoryEntityName);

            foreach (var childCategory in category.Child)
            {
                DeleteSimple(childCategory);
            }
        }
    }
}