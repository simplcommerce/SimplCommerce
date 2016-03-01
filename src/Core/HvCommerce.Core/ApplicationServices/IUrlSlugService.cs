namespace HvCommerce.Core.ApplicationServices
{
    public interface IUrlSlugService
    {
        void Add(string name, long entityId, string entityName);

        void Update(string newName, long entityId, string entityName);

        void Remove(long entityId, string entityName);
    }
}