using System;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Infrastructure.Domain.IRepositories
{
    public interface IRepository<T> : IRepositoryWithTypedId<T, long> where T : IEntityWithTypedId<long>
    {
    }
}
