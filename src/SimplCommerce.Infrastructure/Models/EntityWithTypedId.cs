using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Infrastructure.Models
{
    public abstract class EntityWithTypedId<TId> : ValidatableObject, IEntityWithTypedId<TId>
    {
        public TId Id { get; protected set; }
    }
}
