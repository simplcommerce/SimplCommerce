using System;
using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Infrastructure.Domain.IRepositories
{
    public interface IRepository<T> : IRepositoryWithTypedId<T, long>, IDisposable where T : IEntityWithTypedId<long>
    {
    }
}
