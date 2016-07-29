using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Infrastructure.Data
{
    public interface IRepository<T> : IRepositoryWithTypedId<T, long> where T : IEntityWithTypedId<long>
    {
    }
}
