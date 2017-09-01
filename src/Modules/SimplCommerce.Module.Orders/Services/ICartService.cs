using System.Threading.Tasks;
using SimplCommerce.Module.Orders.ViewModels;
using SimplCommerce.Module.Pricing.Services;

namespace SimplCommerce.Module.Orders.Services
{
    public interface ICartService
    {
        void AddToCart(long userId, long productId, int quantity);

        Task<CartVm> GetCart(long userId);

        Task<CouponValidationResult> ApplyCoupon(long userId, string couponCode);

        void MigrateCart(long fromUserId, long toUserId);
    }
}
