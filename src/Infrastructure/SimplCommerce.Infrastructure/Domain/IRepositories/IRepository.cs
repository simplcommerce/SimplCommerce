using System;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Infrastructure.Domain.IRepositories
{
    public interface IRepository<T> : IRepositoryWithTypedId<T, long> where T : IEntityWithTypedId<long>
    {
    }
}
