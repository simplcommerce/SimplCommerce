using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Cms.Services
{
    public class PageService : IPageService
    {
        public const string PageEntityName = "Page";

        private readonly IRepository<Page> _pageRepository;
        private readonly IUrlSlugService _urlSlugService;

        public PageService(IRepository<Page> pageRepository, IUrlSlugService urlSlugService)
        {
            _pageRepository = pageRepository;
            _urlSlugService = urlSlugService;
        }

        public void Create(Page page)
        {
            using (var transaction = _pageRepository.BeginTransaction())
            {
                _pageRepository.Add(page);
                _pageRepository.SaveChange();

                _urlSlugService.Add(page.SeoTitle, page.Id, PageEntityName);
                _pageRepository.SaveChange();

                transaction.Commit();
            }
        }

        public void Update(Page page)
        {
            _urlSlugService.Update(page.SeoTitle, page.Id, PageEntityName);
            _pageRepository.SaveChange();
        }

        public void Delete(Page page)
        {
            _pageRepository.Remove(page);
            _urlSlugService.Remove(page.Id, PageEntityName);
            _pageRepository.SaveChange();
        }
    }
}
