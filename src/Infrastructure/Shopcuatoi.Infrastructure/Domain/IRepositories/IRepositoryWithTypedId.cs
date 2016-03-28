using System.Linq;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Infrastructure.Domain.IRepositories
{
    public interface IRepositoryWithTypedId<T, in TId> where T : IEntityWithTypedId<TId>
    {
        /// <summary>
        /// Returns null if a row is not found matching the provided Id.
        /// </summary>
        T Get(TId id);

        IQueryable<T> Query();

        void Add(T entity);

        void SaveChange();

        void Remove(T entity);
    }
}
