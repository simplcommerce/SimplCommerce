using System.Linq;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;

namespace Shopcuatoi.Core.ApplicationServices
{
    public class UrlSlugService : IUrlSlugService
    {
        private readonly IRepository<UrlSlug> urlSlugRepository;

        public UrlSlugService(IRepository<UrlSlug> urlSlugRepository)
        {
            this.urlSlugRepository = urlSlugRepository;
        }

        public void Add(string slug, long entityId, string entityName)
        {
            var urlSlug = new UrlSlug
            {
                Slug = slug,
                EntityId = entityId,
                EntityName = entityName
            };

            urlSlugRepository.Add(urlSlug);
        }

        public void Update(string newName, long entityId, string entityName)
        {
            var urlSlug =
                urlSlugRepository.Query().First(x => x.EntityId == entityId && x.EntityName == entityName);
            urlSlug.Slug = newName;
        }

        public void Remove(long entityId, string entityName)
        {
            var urlSlug =
               urlSlugRepository.Query().First(x => x.EntityId == entityId && x.EntityName == entityName);
            urlSlugRepository.Remove(urlSlug);
        }
    }
}