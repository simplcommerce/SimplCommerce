namespace HvCommerce.Infrastructure.Domain.Models
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}