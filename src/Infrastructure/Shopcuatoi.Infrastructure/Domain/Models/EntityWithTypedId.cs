using System;

namespace Shopcuatoi.Infrastructure.Domain.Models
{
    [Serializable]
    public abstract class EntityWithTypedId<TId> : ValidatableObject, IEntityWithTypedId<TId>
    {
        public TId Id { get; protected set; }
    }
}