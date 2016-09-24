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

        public UrlSlug Get(long entityId, long entityTypeId)
        {
            return _urlSlugRepository.Query().FirstOrDefault(x => x.EntityId == entityId && x.EntityTypeId == entityTypeId);
        }

        public void Add(string slug, long entityId, long entityTypeId)
        {
            var urlSlug = new UrlSlug
            {
                Slug = slug,
                EntityId = entityId,
                EntityTypeId = entityTypeId
            };

            _urlSlugRepository.Add(urlSlug);
        }

        public void Update(string newName, long entityId, long entityTypeId)
        {
            var urlSlug =
                _urlSlugRepository.Query().First(x => x.EntityId == entityId && x.EntityTypeId == entityTypeId);
            urlSlug.Slug = newName;
        }

        public void Remove(long entityId, long entityTypeId)
        {
            var urlSlug =
               _urlSlugRepository.Query().FirstOrDefault(x => x.EntityId == entityId && x.EntityTypeId == entityTypeId);
            if (urlSlug != null)
            {
                _urlSlugRepository.Remove(urlSlug);
            }
        }
    }
}
