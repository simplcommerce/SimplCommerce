namespace HvCommerce.Infrastructure.Domain.Events
{
    public interface IHandler<in T> where T : IDomainEvent
    {
        void Handle(T arg);
    }
}
