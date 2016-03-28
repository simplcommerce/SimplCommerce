using System.Data.Entity;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Core.Infrastructure.EntityFramework
{
    public class Repository<T> : RepositoryWithTypedId<T, long>, IRepository<T>
        where T : class, IEntityWithTypedId<long>
    {
        public Repository(DbContext context) : base(context)
        {
        }
    }
}