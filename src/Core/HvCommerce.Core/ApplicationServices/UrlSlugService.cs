using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.IRepositories;

namespace HvCommerce.Core.ApplicationServices
{
    public class UrlSlugService : IUrlSlugService
    {
        private readonly IRepository<UrlSlug> urlSlugRepository;

        public UrlSlugService(IRepository<UrlSlug> urlSlugRepository)
        {
            this.urlSlugRepository = urlSlugRepository;
        }

        public void Add(UrlSlug urlSlug)
        {
            urlSlugRepository.Add(urlSlug);
        }
    }
}