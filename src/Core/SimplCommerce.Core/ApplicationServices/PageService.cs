using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;

namespace SimplCommerce.Core.ApplicationServices
{
    public class PageService : IPageService
    {
        public const string PageEntityName = "Page";

        private readonly IRepository<Page> pageRepository;
        private readonly IUrlSlugService urlSlugService;

        public PageService(IRepository<Page> pageRepository, IUrlSlugService urlSlugService)
        {
            this.pageRepository = pageRepository;
            this.urlSlugService = urlSlugService;
        }

        public void Create(Page page)
        {
            pageRepository.Add(page);
            pageRepository.SaveChange();

            urlSlugService.Add(page.SeoTitle, page.Id, PageEntityName);
            pageRepository.SaveChange();
        }

        public void Update(Page page)
        {
            urlSlugService.Update(page.SeoTitle, page.Id, PageEntityName);
            pageRepository.SaveChange();
        }

        public void Delete(Page page)
        {
            pageRepository.Remove(page);
            urlSlugService.Remove(page.Id, PageEntityName);
            pageRepository.SaveChange();
        }
    }
}
