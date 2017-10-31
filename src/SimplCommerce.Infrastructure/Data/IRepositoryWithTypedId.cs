using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Infrastructure.Data
{
    public interface IRepositoryWithTypedId<T, in TId> where T : IEntityWithTypedId<TId>
    {
        IQueryable<T> Query();

        void Add(T entity);

        IDbContextTransaction BeginTransaction();

        void SaveChange();

        Task SaveChangesAsync();

        void Remove(T entity);
    }
}
