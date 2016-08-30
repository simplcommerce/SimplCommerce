using System.Collections.Generic;
using System.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.ViewModels;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private const long CategoryEntityTypeId = 1;

        private readonly IRepository<Category> _categoryRepository;
        private readonly IUrlSlugService _urlSlugService;

        public CategoryService(IRepository<Category> categoryRepository, IUrlSlugService urlSlugService)
        {
            _categoryRepository = categoryRepository;
            _urlSlugService = urlSlugService;
        }

        public IList<CategoryListItem> GetAll()
        {
            var categories = _categoryRepository.Query().Where(x => !x.IsDeleted).ToList();
            var categoriesList = new List<CategoryListItem>();
            foreach (var category in categories)
            {
                var categoryListItem = new CategoryListItem
                {
                    Id = category.Id,
                    IsPublished = category.IsPublished,
                    Name = category.Name
                };

                var parentCategory = category.Parent;
                while (parentCategory != null)
                {
                    categoryListItem.Name = $"{parentCategory.Name} >> {categoryListItem.Name}";
                    parentCategory = parentCategory.Parent;
                }

                categoriesList.Add(categoryListItem);
            }

            return categoriesList.OrderBy(x => x.Name).ToList();
        }

        public void Create(Category category)
        {
            using (var transaction = _categoryRepository.BeginTransaction())
            {
                _categoryRepository.Add(category);
                _categoryRepository.SaveChange();

                _urlSlugService.Add(category.SeoTitle, category.Id, CategoryEntityTypeId);
                _categoryRepository.SaveChange();

                transaction.Commit();
            }
        }

        public void Update(Category category)
        {
            _urlSlugService.Update(category.SeoTitle, category.Id, CategoryEntityTypeId);
            _categoryRepository.SaveChange();
        }

        public void Delete(Category category)
        {
            _categoryRepository.Remove(category);
            _categoryRepository.SaveChange();
        }
    }
}
