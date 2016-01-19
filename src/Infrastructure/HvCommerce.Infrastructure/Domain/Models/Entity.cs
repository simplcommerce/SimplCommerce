using System;

namespace HvCommerce.Infrastructure.Domain.Models
{
    /// <summary>
    ///     Provides a base class for your objects which will be persisted to the database.
    ///     Benefits include the addition of an Id property along with a consistent manner for comparing
    ///     entities.
    ///     Since nearly all of the entities you create will have a type of int Id, this
    ///     base class leverages this assumption.  If you want an entity with a type other
    ///     than int, such as string, then use <see cref="EntityWithTypedId{IdT}" /> instead.
    /// </summary>
    [Serializable]
    public abstract class Entity : EntityWithTypedId<long>
    {
    }
}