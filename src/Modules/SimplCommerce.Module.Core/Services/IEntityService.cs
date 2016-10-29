using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Services
{
    public interface IEntityService
    {
        Entity Get(long entityId, long entityTypeId);

        void Add(string name, long entityId, long entityTypeId);

        void Update(string newName, long entityId, long entityTypeId);

        void Remove(long entityId, long entityTypeId);
    }
}
