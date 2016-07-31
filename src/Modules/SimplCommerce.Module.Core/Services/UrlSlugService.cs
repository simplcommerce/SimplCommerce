using System.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Services
{
    public class UrlSlugService : IUrlSlugService
    {
        private readonly IRepository<UrlSlug> _urlSlugRepository;

        public UrlSlugService(IRepository<UrlSlug> urlSlugRepository)
        {
            _urlSlugRepository = urlSlugRepository;
        }

        public UrlSlug Get(long entityId, string entityName)
        {
            return _urlSlugRepository.Query().FirstOrDefault(x => x.EntityId == entityId && x.EntityName == entityName);
        }

        public void Add(string slug, long entityId, string entityName)
        {
            var urlSlug = new UrlSlug
            {
                Slug = slug,
                EntityId = entityId,
                EntityName = entityName
            };

            _urlSlugRepository.Add(urlSlug);
        }

        public void Update(string newName, long entityId, string entityName)
        {
            var urlSlug =
                _urlSlugRepository.Query().First(x => x.EntityId == entityId && x.EntityName == entityName);
            urlSlug.Slug = newName;
        }

        public void Remove(long entityId, string entityName)
        {
            var urlSlug =
               _urlSlugRepository.Query().First(x => x.EntityId == entityId && x.EntityName == entityName);
            _urlSlugRepository.Remove(urlSlug);
        }
    }
}
