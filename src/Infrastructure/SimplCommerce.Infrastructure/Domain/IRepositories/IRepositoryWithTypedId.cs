using System.Linq;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Infrastructure.Domain.IRepositories
{
    public interface IRepositoryWithTypedId<T, in TId> where T : IEntityWithTypedId<TId>
    {
        IQueryable<T> Query();

        void Add(T entity);

        void SaveChange();

        void Remove(T entity);
    }
}
