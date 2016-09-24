namespace SimplCommerce.Infrastructure.Models
{
    public abstract class EntityWithTypedId<TId> : ValidatableObject, IEntityWithTypedId<TId>
    {
        public TId Id { get; protected set; }
    }
}
