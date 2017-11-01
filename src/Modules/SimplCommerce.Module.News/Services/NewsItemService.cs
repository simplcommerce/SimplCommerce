using System.Linq;
using System.Threading.Tasks;
using SimplCommerce.Module.News.Models;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.News.Services
{
    public class NewsItemService : INewsItemService
    {
        private const long NewsItemEntityTypeId = 7;

        private readonly IRepository<NewsItem> _newsItemRepository;
        private readonly IEntityService _entityService;

        public NewsItemService(IRepository<NewsItem> newsItemRepository, IEntityService entityService)
        {
            _newsItemRepository = newsItemRepository;
            _entityService = entityService;
        }

        public void Create(NewsItem newsItem)
        {
            if( newsItem != null)
            {
                using (var transaction = _newsItemRepository.BeginTransaction())
                {
                    newsItem.SeoTitle = _entityService.ToSafeSlug(newsItem.SeoTitle, newsItem.Id, NewsItemEntityTypeId);
                    _newsItemRepository.Add(newsItem);
                    _newsItemRepository.SaveChanges();

                    _entityService.Add(newsItem.Name, newsItem.SeoTitle, newsItem.Id, NewsItemEntityTypeId);
                    _newsItemRepository.SaveChanges();

                    transaction.Commit();
                }
            }
        }

        public void Update(NewsItem newsItem)
        {
            if (newsItem != null)
            {
                newsItem.SeoTitle = _entityService.ToSafeSlug(newsItem.SeoTitle, newsItem.Id, NewsItemEntityTypeId);
                _entityService.Update(newsItem.Name, newsItem.SeoTitle, newsItem.Id, NewsItemEntityTypeId);
                _newsItemRepository.SaveChanges();
            }
        }

        public async Task Delete(long id)
        {
            var newsItem = _newsItemRepository.Query().First(x => x.Id == id);
            await Delete(newsItem);
        }

        public async Task Delete(NewsItem newsItem)
        {
            if (newsItem != null)
            {
                newsItem.IsDeleted = true;
                await _entityService.Remove(newsItem.Id, NewsItemEntityTypeId);
                _newsItemRepository.SaveChanges();
            }
        }
    }
}
