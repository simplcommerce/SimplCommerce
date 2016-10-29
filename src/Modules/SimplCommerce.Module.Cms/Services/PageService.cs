using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Cms.Services
{
    public class PageService : IPageService
    {
        public const long PageEntityTypeId = 4;

        private readonly IRepository<Page> _pageRepository;
        private readonly IEntityService _entityService;

        public PageService(IRepository<Page> pageRepository, IEntityService entityService)
        {
            _pageRepository = pageRepository;
            _entityService = entityService;
        }

        public void Create(Page page)
        {
            using (var transaction = _pageRepository.BeginTransaction())
            {
                _pageRepository.Add(page);
                _pageRepository.SaveChange();

                _entityService.Add(page.Name, page.SeoTitle, page.Id, PageEntityTypeId);
                _pageRepository.SaveChange();

                transaction.Commit();
            }
        }

        public void Update(Page page)
        {
            _entityService.Update(page.Name, page.SeoTitle, page.Id, PageEntityTypeId);
            _pageRepository.SaveChange();
        }

        public void Delete(Page page)
        {
            _pageRepository.Remove(page);
            _entityService.Remove(page.Id, PageEntityTypeId);
            _pageRepository.SaveChange();
        }
    }
}
