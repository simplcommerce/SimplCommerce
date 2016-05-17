using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Core.Infrastructure.EntityFramework
{
    public class Repository<T> : RepositoryWithTypedId<T, long>, IRepository<T>
        where T : class, IEntityWithTypedId<long>
    {
        public Repository(HvDbContext context) : base(context)
        {
        }
    }
}