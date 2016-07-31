using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Services
{
    public interface IUrlSlugService
    {
        UrlSlug Get(long entityId, string entityName);

        void Add(string name, long entityId, string entityName);

        void Update(string newName, long entityId, string entityName);

        void Remove(long entityId, string entityName);
    }
}
