using System.Linq;
using System.Threading.Tasks;
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

        public async Task Create(NewsCategory category)
        {
            using (var transaction = _categoryRepository.BeginTransaction())
            {
                category.Slug = _entityService.ToSafeSlug(category.Slug, category.Id, NewsCategoryEntityTypeId);
                _categoryRepository.Add(category);
                await _categoryRepository.SaveChangesAsync();

                _entityService.Add(category.Name, category.Slug, category.Id, NewsCategoryEntityTypeId);
                await _categoryRepository.SaveChangesAsync();

                transaction.Commit();
            }
        }

        public async Task Update(NewsCategory category)
        {
            category.Slug = _entityService.ToSafeSlug(category.Slug, category.Id, NewsCategoryEntityTypeId);
            _entityService.Update(category.Name, category.Slug, category.Id, NewsCategoryEntityTypeId);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var category = _categoryRepository.Query().First(x => x.Id == id);
            await Delete(category);
        }

        public async Task Delete(NewsCategory category)
        {
            category.IsDeleted = true;
            await _entityService.Remove(category.Id, NewsCategoryEntityTypeId);
            _categoryRepository.SaveChanges();
        }
    }
}
