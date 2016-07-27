using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Infrastructure.Domain.IRepositories
{
    public interface IRepositoryWithTypedId<T, in TId> where T : IEntityWithTypedId<TId>
    {
        IQueryable<T> Query();

        void Add(T entity);

        IDbContextTransaction BeginTransaction();

        void SaveChange();

        void Remove(T entity);
    }
}
