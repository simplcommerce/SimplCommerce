using HvCommerce.Infrastructure.Domain.IRepositories;
using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Infrastructure.EntityFramework
{
    public class Repository<T> : RepositoryWithTypedId<T, long>, IRepository<T> where T : class, IEntityWithTypedId<long>
    {
        public Repository(HvDbContext context) : base(context)
        {
        }
    }
}
