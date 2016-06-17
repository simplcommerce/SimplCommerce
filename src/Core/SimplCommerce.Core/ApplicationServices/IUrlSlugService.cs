using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Core.ApplicationServices
{
    public interface IUrlSlugService
    {
        UrlSlug Get(long entityId, string entityName);

        void Add(string name, long entityId, string entityName);

        void Update(string newName, long entityId, string entityName);

        void Remove(long entityId, string entityName);
    }
}