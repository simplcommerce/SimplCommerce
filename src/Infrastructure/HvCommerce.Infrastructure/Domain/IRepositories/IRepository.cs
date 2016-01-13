using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Infrastructure.Domain.IRepositories
{
    public interface IRepository<T> : IRepositoryWithTypedId<T, long> where T : EntityWithTypedId<long>
    {
    }
}
