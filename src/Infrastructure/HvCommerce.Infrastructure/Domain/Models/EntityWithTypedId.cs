using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvCommerce.Infrastructure.Domain.Models
{
    [Serializable]
    public abstract class EntityWithTypedId<TId> : ValidatableObject
    {
        public TId Id { get; protected set; }
    }
}
