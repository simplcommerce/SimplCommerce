namespace SimplCommerce.Module.ProductComparison.Services
{
    public interface IComparingProductService
    {
        void AddToComparison(long userId, long productId);

        void MigrateComparingProduct(long fromUserId, long toUserId);
    }
}
