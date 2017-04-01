using System;
using System.Collections.Generic;
using System.Text;
using SimplCommerce.Module.News.Models;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Services;
using System.Linq;

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
                    _newsItemRepository.SaveChange();

                    _entityService.Add(newsItem.Name, newsItem.SeoTitle, newsItem.Id, NewsItemEntityTypeId);
                    _newsItemRepository.SaveChange();

                    transaction.Commit();
                }
            }
        }

        public void Delete(long id)
        {
            var newsItem = _newsItemRepository.Query().First(x => x.Id == id);
            Delete(newsItem);
        }

        public void Delete(NewsItem newsItem)
        {
            if (newsItem != null)
            {
                newsItem.IsDeleted = true;
                _entityService.Remove(newsItem.Id, NewsItemEntityTypeId);
                _newsItemRepository.SaveChange();
            }
        }

        public void Update(NewsItem newsItem)
        {
            if( newsItem != null)
            {
                newsItem.SeoTitle = _entityService.ToSafeSlug(newsItem.SeoTitle, newsItem.Id, NewsItemEntityTypeId);
                _entityService.Update(newsItem.Name, newsItem.SeoTitle, newsItem.Id, NewsItemEntityTypeId);
                _newsItemRepository.SaveChange();
            }
        }
    }
}
