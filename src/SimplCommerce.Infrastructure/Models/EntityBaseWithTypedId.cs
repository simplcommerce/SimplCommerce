namespace SimplCommerce.Infrastructure.Models
{
    public abstract class EntityBaseWithTypedId<TId> : ValidatableObject, IEntityWithTypedId<TId>
    {
        public TId Id { get; protected set; }
    }
}
