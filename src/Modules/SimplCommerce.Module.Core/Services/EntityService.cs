using System.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Services
{
    public class EntityService : IEntityService
    {
        private readonly IRepository<Entity> _entityRepository;

        public EntityService(IRepository<Entity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public Entity Get(long entityId, long entityTypeId)
        {
            return _entityRepository.Query().FirstOrDefault(x => x.EntityId == entityId && x.EntityTypeId == entityTypeId);
        }

        public void Add(string name, string slug, long entityId, long entityTypeId)
        {
            var entity = new Entity
            {
                Name = name,
                Slug = slug,
                EntityId = entityId,
                EntityTypeId = entityTypeId
            };

            _entityRepository.Add(entity);
        }

        public void Update(string newName, string newSlug, long entityId, long entityTypeId)
        {
            var entity = _entityRepository.Query().First(x => x.EntityId == entityId && x.EntityTypeId == entityTypeId);
            entity.Name = newName;
            entity.Slug = newSlug;
        }

        public void Remove(long entityId, long entityTypeId)
        {
            var entity = _entityRepository.Query().FirstOrDefault(x => x.EntityId == entityId && x.EntityTypeId == entityTypeId);
            if (entity != null)
            {
                _entityRepository.Remove(entity);
            }
        }
    }
}
