using System;

namespace SimplCommerce.Infrastructure.Domain.Models
{
    public abstract class EntityWithTypedId<TId> : ValidatableObject, IEntityWithTypedId<TId>
    {
        public TId Id { get; protected set; }
    }
}