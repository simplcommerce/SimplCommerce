using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Data
{
    public class Repository<T> : RepositoryWithTypedId<T, long>, IRepository<T>
       where T : class, IEntityWithTypedId<long>
    {
        public Repository(SimplDbContext context) : base(context)
        {
        }
    }
}
