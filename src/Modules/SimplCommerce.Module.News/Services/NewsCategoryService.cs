using System.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.News.Models;

namespace SimplCommerce.Module.News.Services
{
    public class NewsCategoryService : INewsCategoryService
    {
        private const long NewsCategoryEntityTypeId = 6;

        private readonly IRepository<NewsCategory> _categoryRepository;
        private readonly IEntityService _entityService;

        public NewsCategoryService(IRepository<NewsCategory> categoryRepository, IEntityService entityService)
        {
            _categoryRepository = categoryRepository;
            _entityService = entityService;
        }

        public void Create(NewsCategory category)
        {
            using (var transaction = _categoryRepository.BeginTransaction())
            {
                category.SeoTitle = _entityService.ToSafeSlug(category.SeoTitle, category.Id, NewsCategoryEntityTypeId);
                _categoryRepository.Add(category);
                _categoryRepository.SaveChange();

                _entityService.Add(category.Name, category.SeoTitle, category.Id, NewsCategoryEntityTypeId);
                _categoryRepository.SaveChange();

                transaction.Commit();
            }
        }

        public void Update(NewsCategory category)
        {
            category.SeoTitle = _entityService.ToSafeSlug(category.SeoTitle, category.Id, NewsCategoryEntityTypeId);
            _entityService.Update(category.Name, category.SeoTitle, category.Id, NewsCategoryEntityTypeId);
            _categoryRepository.SaveChange();
        }

        public void Delete(long id)
        {
            var category = _categoryRepository.Query().First(x => x.Id == id);
            Delete(category);
        }

        public void Delete(NewsCategory category)
        {
            category.IsDeleted = true;
            _entityService.Remove(category.Id, NewsCategoryEntityTypeId);
            _categoryRepository.SaveChange();
        }
    }
}
