using System.Collections.Generic;
using System.Linq;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Core.Infrastructure.EntityFramework;
using HvCommerce.Infrastructure.Domain.IRepositories;

namespace HvCommerce.Core.ApplicationServices
{
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class UrlSlugService : IUrlSlugService
    {
        private IRepository<UrlSlug> urlSlugRepository;

        public UrlSlugService(IRepository<UrlSlug> urlSlugRepository)
        {
            this.urlSlugRepository = urlSlugRepository;
        }

        public async Task<List<UrlSlug>> Query()
        {
            using (urlSlugRepository = new Repository<UrlSlug>(new HvDbContext()))
            {
                return await urlSlugRepository.Query().ToListAsync();
            }
        }

        public void Add(UrlSlug urlSlug)
        {
            urlSlugRepository.Add(urlSlug);
        }
    }
}